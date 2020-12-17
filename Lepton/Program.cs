using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lepton
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов

        static byte[] GetBytes(double[] values)
        {
            return values.SelectMany(value => BitConverter.GetBytes(value)).ToArray();
        }

        static void Main(string[] args)
        {

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string str1 = " тестирование lepton";
            double max, min, mean;
            double sysMax, sysMin, sysCenterMax, sysCenterMin;
            double q1, q2, meanPoint;

            Console.WriteLine(str1);

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

                    Console.WriteLine("Сервер запущен. Ожидание подключений...");

                    while (true)
                    {
                        Socket handler = listenSocket.Accept();
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

                       
                        var videoRoi = CCIHandle0.sys.GetSceneRoi();
                        videoRoi.startCol = 0;
                        videoRoi.endCol = 79;
                        videoRoi.startRow = 0;
                        videoRoi.endRow = 59;
                        CCIHandle0.sys.SetSceneRoi(videoRoi);
                        var histogram = CCIHandle0.agc.GetHistogramStatistics();
                        max = (0.0214 * (histogram.maxIntensity - 8192) + 304 - 273);
                        min = (0.0214 * (histogram.minIntensity - 8192) + 304 - 273);
                        mean = (0.0214 * (histogram.meanIntensity - 8192) + 304 - 273);

                        

                        var histogramCenter = CCIHandle0.sys.GetSceneStatistics();
                        sysCenterMax = histogramCenter.maxIntensity;
                        sysCenterMin = histogramCenter.minIntensity;

                        for (int i = 0; i < 100000000; i++)
                            ;

                        videoRoi.startCol = 40;
                        videoRoi.endCol = 40;
                        videoRoi.startRow = 29;
                        videoRoi.endRow = 29;
                        CCIHandle0.sys.SetSceneRoi(videoRoi);

                        var histogramPoint = CCIHandle0.sys.GetSceneStatistics();
                        sysMax = histogramPoint.maxIntensity;
                        sysMin = histogramPoint.minIntensity;

                        q1 = ((sysCenterMax + sysCenterMin) / 2) * 100 / (sysMax - sysMin);
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                //var temp = CCIHandle0.sys.GetSceneRoi();
                //var temp1 = CCIHandle0.sys.GetSceneStatistics();
                

            }
           

            Console.ReadKey();
        }
    }
}
