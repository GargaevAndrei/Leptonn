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
//using System.Timers;

namespace Lepton
{
    class Program
    {

        static double[] coefPT = new double[9];    
        static SerialPort serialPortLepton;
       // public static DeviceInformationCollection cameraDeviceList;
       // public static DeviceInformationCollection cameraDeviceListOld;
        //static VideoCaptureDevice Device;

        static byte[] GetBytes(double[] values)
        {
            return values.SelectMany(value => BitConverter.GetBytes(value)).ToArray();
        }

        private static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            //cameraDeviceList = await FindCameraDeviceAsync();

            //if (cameraDeviceList.Count != cameraDeviceListOld.Count)
            //{

            //}
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

            //Timer t = new Timer(TimerCallback, null, 0, 2000);



            // --------------- Скрыть окно -------------------------------------------------

            //ShowWindow(GetConsoleWindow(), 0);             


            //com3 - pc      planhet - com8
            serialPortLepton = new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One); //COM3

            if (serialPortLepton != null)
            {
                try
                {
                    serialPortLepton.Open();
                    serialPortLepton.ReadTimeout = 2000;
                    serialPortLepton.WriteTimeout = 2000;
                    serialPortLepton.DataReceived += SerialPortLepton_DataReceived;
                    Console.WriteLine("\nserialPortLepton open" + Environment.NewLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            #region old code tcp server
            /*static async Task Main(string[] args)
            {

                //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), localPort);

                //IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                //IPAddress ipAddr = ipHost.AddressList[0];
                //IPEndPoint ipPoint = new IPEndPoint(ipAddr, 61111);       

                //Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //AddressFamily.InterNetwork,      //ipAddr.AddressFamily
                //Socket handler;

                //Timer t = new Timer(TimerCallback, null, 0, 10000);

                string str1 = " тестирование lepton";
                double max, min, mean;
                double sysMax, sysMin, sysCenterMax, sysCenterMin, sysCenterMean;
                double q, q1, q2, meanPoint;



                Console.WriteLine(str1);

                while (true)
                {

                    var devices = Lepton.CCI.GetDevices();
                    if (devices.Count == 0)
                    {
                        Console.WriteLine("no Lepton CCI Devices...");
                    }
                    else
                    {
                        // get the first device
                        var device = devices[0];
                        var CCIHandle0 = device.Open();


                        try
                        {

                            listenSocket.Bind(ipPoint);
                            listenSocket.Listen(100);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("err bind" + ex.Message);
                        }


                        try
                        {

                            Console.WriteLine("Сервер запущен. Ожидание подключений...");

                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("before accept\n");
                                    handler = listenSocket.Accept();
                                    Console.WriteLine("after accept\n");

                                    var temp = listenSocket.LocalEndPoint;
                                    Console.WriteLine(temp);
                                    var temp1 = handler.RemoteEndPoint;
                                    Console.WriteLine(temp1);



                                    //// получаем сообщение
                                    StringBuilder builder = new StringBuilder();
                                    int bytes = 0; // количество полученных байтов
                                    byte[] data = new byte[256]; // буфер для получаемых данных

                                    //do
                                    //{
                                    //    bytes = handler.Receive(data);
                                    //    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                                    //}
                                    //while (handler.Available > 0);


                                    var histogram = CCIHandle0.agc.GetHistogramStatistics();


                                    max = (0.0214 * (histogram.maxIntensity - 8192) + 304 - 273);
                                    min = (0.0214 * (histogram.minIntensity - 8192) + 304 - 273);
                                    mean = (0.0214 * (histogram.meanIntensity - 8192) + 304 - 273);

                                    var videoRoi = CCIHandle0.sys.GetSceneRoi();
                                    videoRoi.startCol = 0;
                                    videoRoi.endCol = 79;
                                    videoRoi.startRow = 0;
                                    videoRoi.endRow = 59;
                                    CCIHandle0.sys.SetSceneRoi(videoRoi);
                                    videoRoi = CCIHandle0.sys.GetSceneRoi();

                                    await Task.Delay(200);

                                    var histogramScene = CCIHandle0.sys.GetSceneStatistics();
                                    sysMax = histogramScene.maxIntensity;
                                    sysMin = histogramScene.minIntensity;


                                    videoRoi.startCol = 71;
                                    videoRoi.endCol = 75;
                                    videoRoi.startRow = 28;
                                    videoRoi.endRow = 30;
                                    CCIHandle0.sys.SetSceneRoi(videoRoi);
                                    videoRoi = CCIHandle0.sys.GetSceneRoi();

                                    await Task.Delay(200);

                                    var histogramCenter = CCIHandle0.sys.GetSceneStatistics();
                                    sysCenterMax = histogramCenter.maxIntensity;
                                    sysCenterMin = histogramCenter.minIntensity;
                                    sysCenterMean = histogramCenter.meanIntensity;

                                    //q1 = ((sysCenterMax + sysCenterMin) / 2) * 100 / (sysMax - sysMin);
                                    //q = (sysMax - sysMin) * sysCenterMax / (sysCenterMax - sysCenterMin) + sysMin;
                                    //q2 = ((histogram.maxIntensity - histogram.minIntensity) / ((sysMax - sysMin)) * q / 100) + histogram.minIntensity;

                                    q1 = sysCenterMean * 100 / (sysMax - sysMin);
                                    q2 = ((histogram.maxIntensity - histogram.minIntensity) * q1 / 100) + histogram.minIntensity;
                                    meanPoint = (0.0214 * (q2 - 8192) + 304 - 273);

                                    Console.WriteLine("max = {0}  min = {1}  mean = {2} meanPoint = {3} ", max, min, mean, meanPoint);

                                    string strSend = string.Format("{0}:{1}", min, max);
                                    string strSendPoint = string.Format("{0}:{1}:{2}", min, max, meanPoint);

                                    data = Encoding.ASCII.GetBytes(strSendPoint);

                                    var count = handler.Send(data);

                                    handler.Shutdown(SocketShutdown.Both);
                                    handler.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }


                        catch (Exception ex)
                        {
                            Console.WriteLine("err " + ex.Message);
                        }
                    }
                }

                Console.ReadKey();
            }*/


            /*static Socket listeningSocket;
            static  Task Main(string[] args)
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), localPort);
                listeningSocket.Bind(localIP);

                //byte[] data = new byte[256]; // буфер для получаемых данных
                ////адрес, с которого пришли данные
                //EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
                //int bytes = listeningSocket.ReceiveFrom(data, ref remoteIp);


                byte[] data1;// = { 1, 2, 3, 4, 5, 6, 7, 8 };
                EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), remotePort);
                //listeningSocket.SendTo(data1, remotePoint);

                while (true)
                {
                    string message = Console.ReadLine();
                    data1 = Encoding.Unicode.GetBytes(message);
                    listeningSocket.SendTo(data1, remotePoint);
                    Console.WriteLine("отправленно \n");
                }
                    //EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), remotePort);

                    //listeningSocket.SendTo(data, remotePoint);

                    //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                    //Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    Timer t = new Timer(TimerCallback, null, 0, 10000);

                string str1 = " тестирование lepton";
                double max, min, mean;
                double sysMax, sysMin, sysCenterMax, sysCenterMin, sysCenterMean;
                double q, q1, q2, meanPoint;

                Socket handler;

                Console.WriteLine(str1);

                /*while (true)
                {

                    var devices = Lepton.CCI.GetDevices();
                    if (devices.Count == 0)
                    {
                        Console.WriteLine("no Lepton CCI Devices...");
                    }
                    else
                    {
                        // get the first device
                        var device = devices[0];
                        var CCIHandle0 = device.Open();


                        try
                        {

                            listenSocket.Bind(ipPoint);
                            listenSocket.Listen(10);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("err bind" + ex.Message);
                        }


                        try
                        {

                            Console.WriteLine("Сервер запущен. Ожидание подключений...");

                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("before accept\n");
                                    handler = listenSocket.Accept();
                                    Console.WriteLine("after accept\n");

                                    var temp = listenSocket.LocalEndPoint;
                                    Console.WriteLine(temp);
                                    var temp1 = handler.RemoteEndPoint;
                                    Console.WriteLine(temp1);



                                    // получаем сообщение
                                    StringBuilder builder = new StringBuilder();
                                    int bytes = 0; // количество полученных байтов
                                    byte[] data = new byte[256]; // буфер для получаемых данных

                                    do
                                    {
                                        bytes = handler.Receive(data);
                                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                                    }
                                    while (handler.Available > 0);


                                    var histogram = CCIHandle0.agc.GetHistogramStatistics();


                                    max = (0.0214 * (histogram.maxIntensity - 8192) + 304 - 273);
                                    min = (0.0214 * (histogram.minIntensity - 8192) + 304 - 273);
                                    mean = (0.0214 * (histogram.meanIntensity - 8192) + 304 - 273);

                                    var videoRoi = CCIHandle0.sys.GetSceneRoi();
                                    videoRoi.startCol = 0;
                                    videoRoi.endCol = 79;
                                    videoRoi.startRow = 0;
                                    videoRoi.endRow = 59;
                                    CCIHandle0.sys.SetSceneRoi(videoRoi);
                                    videoRoi = CCIHandle0.sys.GetSceneRoi();

                                    await Task.Delay(200);

                                    var histogramScene = CCIHandle0.sys.GetSceneStatistics();
                                    sysMax = histogramScene.maxIntensity;
                                    sysMin = histogramScene.minIntensity;


                                    videoRoi.startCol = 71;
                                    videoRoi.endCol = 75;
                                    videoRoi.startRow = 28;
                                    videoRoi.endRow = 30;
                                    CCIHandle0.sys.SetSceneRoi(videoRoi);
                                    videoRoi = CCIHandle0.sys.GetSceneRoi();

                                    await Task.Delay(200);

                                    var histogramCenter = CCIHandle0.sys.GetSceneStatistics();
                                    sysCenterMax = histogramCenter.maxIntensity;
                                    sysCenterMin = histogramCenter.minIntensity;
                                    sysCenterMean = histogramCenter.meanIntensity;

                                    //q1 = ((sysCenterMax + sysCenterMin) / 2) * 100 / (sysMax - sysMin);
                                    //q = (sysMax - sysMin) * sysCenterMax / (sysCenterMax - sysCenterMin) + sysMin;
                                    //q2 = ((histogram.maxIntensity - histogram.minIntensity) / ((sysMax - sysMin)) * q / 100) + histogram.minIntensity;

                                    q1 = sysCenterMean * 100 / (sysMax - sysMin);
                                    q2 = ((histogram.maxIntensity - histogram.minIntensity) * q1 / 100) + histogram.minIntensity;
                                    meanPoint = (0.0214 * (q2 - 8192) + 304 - 273);

                                    Console.WriteLine("max = {0}  min = {1}  mean = {2} meanPoint = {3} ", max, min, mean, meanPoint);

                                    string strSend = string.Format("{0}:{1}", min, max);
                                    string strSendPoint = string.Format("{0}:{1}:{2}", min, max, meanPoint);

                                    data = Encoding.ASCII.GetBytes(strSendPoint);
                                    var count = handler.Send(data);

                                    handler.Shutdown(SocketShutdown.Both);
                                    handler.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }


                        catch (Exception ex)
                        {
                            Console.WriteLine("err " + ex.Message);
                        }
                    }
                }

                Console.ReadKey();
            }*/

            #endregion



       
            /*System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


            Choices numbers = new Choices();
            numbers.Add(new string[] { "камера", "эндо", "термо", "фото", "запись", "стоп", "пауза", "плюс", "минус", "метка", "альбом", "помощь", "вспышка" });


            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);
            Grammar grammar = new Grammar(gb);
            sre.LoadGrammar(grammar);
            sre.RecognizeAsync(RecognizeMode.Multiple);*/


            Console.ReadKey();
        }

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string temp = "";
            if (e.Result.Confidence > 0.8)
            {

                switch(e.Result.Text)
                {
                    case "камера":   temp = "1";    break;
                    case "эндо":     temp = "2";    break;
                    case "термо":    temp = "3";    break;
                    case "фото":     temp = "4";    break;
                    case "запись":   temp = "5";    break;
                    case "стоп":     temp = "6";    break;
                    case "пауза":    temp = "7";    break;
                    case "плюс":     temp = "8";    break;
                    case "минус":    temp = "9";    break;
                    case "метка":    temp = "10";   break;
                    case "альбом":   temp = "11";   break;
                    case "помощь":   temp = "12";   break;
                    case "вспышка":  temp = "13";   break;
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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            serialPort.Close();

            double max, min, mean;
            

            var devices = Lepton.CCI.GetDevices();
            CCI.Rad.Enable radState = CCI.Rad.Enable.ENABLE;
            CCI.Rad.Enable TLinerState = CCI.Rad.Enable.ENABLE;

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

                    Task.Delay(100);

                    if (CCIHandle0.rad.GetTLinearEnableState() != TLinerState)
                        CCIHandle0.rad.SetTLinearEnableState(TLinerState);

                    //------------------------------

                    var videoRoi = CCIHandle0.sys.GetSceneRoi();
                    videoRoi.startCol = 39;
                    videoRoi.endCol = 41;
                    videoRoi.startRow = 29;
                    videoRoi.endRow = 31;
                    CCIHandle0.sys.SetSceneRoi(videoRoi);

                    var histogram = CCIHandle0.agc.GetHistogramStatistics();
                    max  = histogram.maxIntensity ;
                    min  = histogram.minIntensity ;
                    mean = histogram.meanIntensity;



                    

                    Console.WriteLine("max = {0}  min = {1}  mean = {2} \n", max, min, mean);

                    //string strSend = string.Format("{0}:{1}", min, max);
                    //string strSendPoint = string.Format("{0}:{1}:{2}", min, max, meanPoint);

                    //------------------------------


                    #region old
                    /* 
                     
                    var histogram = CCIHandle0.agc.GetHistogramStatistics();
                    var leptonFPA = CCIHandle0.sys.GetFpaTemperatureCelsius();

                    if (CCIHandle0.rad.GetEnableState() != radState)
                        CCIHandle0.rad.SetEnableState(radState);
                     
                      
                     var xMax = histogram.maxIntensity;
                     var xMin = histogram.minIntensity;
                     var xMean = histogram.meanIntensity;

                     //temp = lepton_raw * b1 + c1 + fpa * fpa * d1 + e1 * fpa

                     var coefPT_Celsius = (coefPT[8] - (coefPT[1] + leptonFPA * leptonFPA * coefPT[2] +  leptonFPA * coefPT[3]) ) / coefPT[0];



                     if (xMax > coefPT_Celsius)
                         max = xMax * coefPT[0] + coefPT[1] + leptonFPA * leptonFPA * coefPT[2] + leptonFPA * coefPT[3];
                     else
                         max = xMax * coefPT[4] + coefPT[5] + leptonFPA * leptonFPA * coefPT[6] + leptonFPA * coefPT[7];


                     if (xMin > coefPT_Celsius)
                         min = xMin * coefPT[0] + coefPT[1] + leptonFPA * leptonFPA * coefPT[2] + leptonFPA * coefPT[3];
                     else
                         min = xMin * coefPT[4] + coefPT[5] + leptonFPA * leptonFPA * coefPT[6] + leptonFPA * coefPT[7];

                    */
                    #endregion


                    //Console.WriteLine("max = {0}  min = {1}  mean = {2} fpa = {3}", max, min, xMean, leptonFPA);

                    //string strSendPoint = string.Format("{0:0.#}:{1:0.#}:{2:0.#}\n", min, max, xMean);

 

                    string strSendPoint = string.Format("{0:0.#}:{1:0.#}\n", min, max);

                    serialPort.Open();
                    if(serialPort.IsOpen)
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
