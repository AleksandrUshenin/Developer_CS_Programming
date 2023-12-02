using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Message msg = new Message() { Text = "Hello", Time = DateTime.Now, NameUserFrom = "User 1", NameUserTo = "User 2" };
            //string json = msg.SearializMessageToJson();
            //Console.WriteLine(json);
            //Message? msg2 = Message.DeSearializMessageFromJson(json);
            //Console.WriteLine($"{msg2.Text}\n{msg2.Time}\n{msg2.NameUserFrom}\n{msg2.NameUserFrom}");
            Server("Server 1");
        }
        static void Server(string Name)
        {
            UdpClient udp = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Server wait message from client"); 
            while (true) 
            {
                byte[] buffer = udp.Receive(ref iPEndPoint);
                if (buffer == null) break;
                var messageText = Encoding.UTF8.GetString(buffer);
                var message = Message.DeSearializMessageFromJson(messageText);
                message.Print();
            }
        }
    }
}