using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //B1: Khởi tạo Socket 
                Socket client = new Socket(SocketType.Dgram, ProtocolType.Udp);
                //B2: Xác định IPEndPoint của Sokcet Server
                EndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                //B3: Liên kết socket server với s_iep
                //B3.1: Tạo gói tin gửi
                string send = " Hello world !";
                byte[] sendData = ASCIIEncoding.ASCII.GetBytes(send);
                //B3.2: 
                client.SendTo(sendData, s_iep);
                Console.WriteLine("Da gui goi tin len server");
                //B3.3;
                byte[] receiveData = new byte[1024];
                EndPoint iep = new IPEndPoint(IPAddress.None, 0);
                int Ien = client.ReceiveFrom(receiveData, ref iep);
                string message = ASCIIEncoding.ASCII.GetString(receiveData, 0, Ien);
                Console.WriteLine("Server: " + message);
                //B4: Thực hiện gói tinh với Client

                //B?: Đóng kết nối 
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
