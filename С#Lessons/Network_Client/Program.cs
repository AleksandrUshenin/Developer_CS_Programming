using System.Net;
using System.Net.Sockets;
using System.Text;
using Network_1;

namespace Network_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SentMessage("192.168.1.147");
            SentMessage("127.0.0.1");

        }
        public static void SentMessage(string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            string messageText;
            do
            {
                Console.Clear();
                Console.WriteLine("Write message:");
                messageText = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(messageText));

            Message message = new Message() { Text = messageText, Time = DateTime.Now, NameUserFrom = "User 1", NameUserTo = "Server" };
            string json = message.SearializMessageToJson();
            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);
            SentMessage(ip);
        } 
    }
}