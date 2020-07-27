using System.Net.Sockets;
using System.Net;
using System;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip,8080);
            TcpClient client = default(TcpClient);

            try
            {
                server.Start();
                Console.WriteLine("server started!");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            while(true)
            {
                client = server.AcceptTcpClient();

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                StringBuilder msg = new StringBuilder();
                foreach (var item in receivedBuffer)
                {
                    if (item.Equals(59))
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(item).ToString());
                    }
                }

                Console.Write(msg.ToString()+msg.Length);
            }
        }
    }
}


