using System;
using Microsoft.Speech.Recognition;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
//using System.Timers;

namespace Lepton
{
    class Program
    {

        static double[] coefPT = new double[9];    
        static SerialPort serialPortLepton;
        static SpeechRecognitionEngine sre;


        static FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        static int cameraCount = filterInfoCollection.Count;

        static byte[] GetBytes(double[] values)
        {
            return values.SelectMany(value => BitConverter.GetBytes(value)).ToArray();
        }

        private static void TimerCallback(Object o)
        {
            
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Console.WriteLine("In TimerCallback: " + DateTime.Now + " count = " + cameraCount);

            if (cameraCount < filterInfoCollection.Count)
            {                
                try
                {
                    //C:\\Program Files\\CameraCOT\\CameraCOT
                    //C:\\Users\\Andrei\\Desktop\\CameraCOT
                    Process.Start("C:\\Program Files\\CameraCOT\\CameraCOT");                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            cameraCount = filterInfoCollection.Count;
        }
       
        private static void restartFunc()
        {
           
            if (serialPortLepton != null && serialPortLepton.IsOpen != true)
            {
                try
                {
                    serialPortLepton.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex " + ex.Message);
                }
            }
        }


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args) //async Task
        {

            if (args.Length == 0)
            {
                System.Console.WriteLine("No enter a coef.");
                coefPT[0] = 1;
                coefPT[1] = 0;
                coefPT[2] = 0;
                coefPT[3] = 0;
                coefPT[4] = 1;
                coefPT[5] = 0;
                coefPT[6] = 0;
                coefPT[7] = 0;
                coefPT[8] = 0;
            }
            if (args.Length == 9)
            {
                double.TryParse(args[0], out coefPT[0]);
                double.TryParse(args[1], out coefPT[1]);
                double.TryParse(args[2], out coefPT[2]);
                double.TryParse(args[3], out coefPT[3]);
                double.TryParse(args[4], out coefPT[4]);
                double.TryParse(args[5], out coefPT[5]);
                double.TryParse(args[6], out coefPT[6]);
                double.TryParse(args[7], out coefPT[7]);
                double.TryParse(args[8], out coefPT[8]);

            }

            Timer t = new Timer(TimerCallback, null, 0, 3000);
            

            // --------------- Скрыть окно -------------------------------------------------

            //ShowWindow(GetConsoleWindow(), 0);             


            //com3 - pc      planhet - com8
            serialPortLepton = new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One); //COM3

            if (serialPortLepton != null)
            {
                try
                {
                    serialPortLepton.Open();
                    serialPortLepton.ReadTimeout = 500;
                    serialPortLepton.WriteTimeout = 500;
                    serialPortLepton.DataReceived += SerialPortLepton_DataReceived;
                    Console.WriteLine("\nserialPortLepton open" + Environment.NewLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

       
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


            Choices numbers = new Choices();
            numbers.Add(new string[] { "главная", "эндо", "термо", "дабл", "фотография","фото", "запись", "стоп", "пауза", "плюс", "минус", "заметка", "альбом", "помощь", "вспышка", "двойной" });


            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);
            Grammar grammar = new Grammar(gb);
            sre.LoadGrammar(grammar);

            //sre.RecognizeAsync(RecognizeMode.Multiple);


            Console.ReadKey();
        }

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string temp = "";
            if (e.Result.Confidence > 0.6)
            {

                switch(e.Result.Text)
                {
                    case "главная":     temp = "1";    break;
                    case "эндо":        temp = "2";    break;
                    case "термо":       temp = "3";    break;
                    case "фотография":  temp = "4";    break;
                    case "запись":      temp = "5";    break;
                    case "стоп":        temp = "6";    break;
                    case "пауза":       temp = "7";    break;
                    case "плюс":        temp = "8";    break;
                    case "минус":       temp = "9";    break;
                    case "заметка":     temp = "10";   break;
                    case "альбом":      temp = "11";   break;
                    case "помощь":      temp = "12";   break;
                    case "вспышка":     temp = "13";   break;
                    case "двойной":     temp = "14";   break;
                    case "фото":        temp = "15";   break;
                    case "дабл":        temp = "16";   break;
                }

                Console.WriteLine(e.Result.Text);

                if (serialPortLepton.IsOpen)
                    serialPortLepton.Close();                                
                
                try
                {
                    serialPortLepton.Open();
                    serialPortLepton.WriteLine("voice "+ temp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
                                                       

            }
        }


        private static void SerialPortLepton_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {


            Console.WriteLine("\n data received open" + Environment.NewLine);
            var serialPort = (SerialPort)sender;

            try

            {
                var request = serialPort.ReadLine();

                if (request.IndexOf("on") >= 0)
                {
                    sre.RecognizeAsync(RecognizeMode.Multiple);
                    Console.WriteLine("On\n");
                    serialPort.WriteLine("on");
                    serialPort.DiscardInBuffer();
                    return;
                }
                if (request.IndexOf("off") >= 0)
                {
                    sre.RecognizeAsyncStop();
                    Console.WriteLine("Off\n");
                    serialPort.WriteLine("off");
                    serialPort.DiscardInBuffer();
                    return;
                }
                if (request == "request")
                {
                    TemperatureResponce(serialPort);
                    serialPort.DiscardInBuffer();
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           

        }

        //private async Task SpeechRecognize()
        //{

        //}

        private static void TemperatureResponce(SerialPort serialPort)
        {
            serialPort.Close();

            double max, min;
            var devices = Lepton.CCI.GetDevices();
            CCI.Rad.Enable radState = CCI.Rad.Enable.ENABLE;


            if (devices.Count == 0)
            {
                Console.WriteLine("no Lepton CCI Devices...");
                restartFunc();
            }
            else
            {
                var device = devices[0];
                var CCIHandle0 = device.Open();

                try
                {

                    if (CCIHandle0.rad.GetEnableState() != radState)
                        CCIHandle0.rad.SetEnableState(radState);


                    var histogram = CCIHandle0.agc.GetHistogramStatistics();
                    var leptonFPA = CCIHandle0.sys.GetFpaTemperatureCelsius();

                    if (CCIHandle0.rad.GetEnableState() != radState)
                        CCIHandle0.rad.SetEnableState(radState);


                    var xMax = histogram.maxIntensity;
                    var xMin = histogram.minIntensity;
                    var xMean = histogram.meanIntensity;

                    //temp = lepton_raw * b1 + c1 + fpa * fpa * d1 + e1 * fpa

                    var coefPT_Celsius = (coefPT[8] - (coefPT[1] + leptonFPA * leptonFPA * coefPT[2] + leptonFPA * coefPT[3])) / coefPT[0];



                    if (xMax > coefPT_Celsius)
                        max = xMax * coefPT[0] + coefPT[1] + leptonFPA * leptonFPA * coefPT[2] + leptonFPA * coefPT[3];
                    else
                        max = xMax * coefPT[4] + coefPT[5] + leptonFPA * leptonFPA * coefPT[6] + leptonFPA * coefPT[7];


                    if (xMin > coefPT_Celsius)
                        min = xMin * coefPT[0] + coefPT[1] + leptonFPA * leptonFPA * coefPT[2] + leptonFPA * coefPT[3];
                    else
                        min = xMin * coefPT[4] + coefPT[5] + leptonFPA * leptonFPA * coefPT[6] + leptonFPA * coefPT[7];


                    Console.WriteLine("max = {0}  min = {1}  mean = {2} fpa = {3}", max, min, xMean, leptonFPA);

                    string strSendPoint = string.Format("{0:0.#}:{1:0.#}:{2:0.#} temperature\n", min, max, xMean);


                    serialPort.Open();
                    if (serialPort.IsOpen)
                        serialPort.WriteLine(strSendPoint);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
