using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace splitwords
{
    static class Program
    {


        //  [STAThread]
        static void Main()
        {
            Task task1 = Task.Factory.StartNew(() => a());
            Task task2 = Task.Factory.StartNew(() => b());
            
            Task.WaitAll(task1, task2);

        }

        static void a()
            {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static void b()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("25.34.193.9"), 9050);


            Console.WriteLine("Waiting for a client...");
            byte[] data = new byte[1024];
            string nameFile;
            while (true)
            {
                UdpClient newsock = new UdpClient(ipep);
             
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 9050);

                data = newsock.Receive(ref sender);

                nameFile = (Encoding.ASCII.GetString(data, 0, data.Length));


                data = newsock.Receive(ref sender);
                while (data.Length != 0)
                {
                    StreamWriter sw;
                    sw = File.AppendText("C:\\Users\\ZRL\\source\\repos\\splitwords\\Clients\\" + nameFile);
                    sw.BaseStream.Write(data, 0, data.Length);
                    sw.Flush();
                    sw.Close();

                    data = newsock.Receive(ref sender);

                }

                newsock.Close();
            }
        }
    }
}
