using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Network_1
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string NameUserFrom { get; set; }
        public string NameUserTo { get; set; }

        public string SearializMessageToJson()
        {
            return JsonSerializer.Serialize(this);  
        }
        public static Message? DeSearializMessageFromJson(string data)
        {
            return JsonSerializer.Deserialize<Message>(data);
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"Get messge {Text} from {NameUserFrom} to {NameUserTo} time {Time}" ;
        }
    }
}
