using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Lesson_13
{
    internal class Program
    {
        enum TypeOfXml
        {
            Attributes,
            InnerText
        }
        static void Main(string[] args)
        {
            User user1 = new User() { ID = 1, Name = "Bob", SurName = "Smit", Birthday = new DateTime(2000, 6, 22), City = "London" };

            string result = GetJson(user1);
            Console.WriteLine(result + "\n");
            User? user1_1 = GetUserFromJson(result);
            Console.WriteLine(user1_1 + "\n");
            Console.WriteLine(GetXmlFromJson(result, TypeOfXml.Attributes) + "\n");;
            Console.WriteLine(GetXmlFromJson(result, TypeOfXml.InnerText) + "\n");
            Console.WriteLine(ConvertJsonToXml(result) + "\n");
        }
        static string GetJson(User user)
        {
            string result = JsonSerializer.Serialize(user);
            //Console.WriteLine(result);
            return result;
        }
        static User? GetUserFromJson(string? json)
        {
            User user = (User)JsonSerializer.Deserialize(JsonDocument.Parse(json), typeof(User));
            return user;
        }
        static string GetXmlFromJson(string json, TypeOfXml typeOfXml)
        {
            JsonDocument jd = JsonDocument.Parse(json);
            var r = jd.RootElement;
            //Console.WriteLine(r.GetProperty("ID"));
            //Console.WriteLine(r.GetProperty("Name"));
            //Console.WriteLine(r.GetProperty("SurName"));
            //Console.WriteLine(r.GetProperty("Birthday"));
            //Console.WriteLine(r.GetProperty("City"));

           Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("ID", r.GetProperty("ID").ToString());
            data.Add("Name", r.GetProperty("Name").ToString());
            data.Add("SurName", r.GetProperty("SurName").ToString());
            data.Add("Birthday", r.GetProperty("Birthday").ToString());
            data.Add("City", r.GetProperty("City").ToString());

            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            xmlDocument.AppendChild(xmlDeclaration);
            XmlElement xmlElementUser = xmlDocument.CreateElement("User");
            xmlDocument.AppendChild(xmlElementUser);
            foreach (var (name, value) in data)
            {
                if (typeOfXml.Equals(TypeOfXml.InnerText))
                {
                    XmlElement xmlElement = xmlDocument.CreateElement(name);
                    xmlElement.InnerText = value;
                    xmlElementUser.AppendChild(xmlElement);
                }
                else if (typeOfXml.Equals(TypeOfXml.Attributes))
                {
                    XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(name);
                    xmlAttribute.Value = value;
                    xmlElementUser.Attributes.Append(xmlAttribute);
                }
            }
            StringBuilder sb = new StringBuilder();
            xmlDocument.Save(new StringWriter(sb));
            //xmlDocument.Save(Console.Out);
            return sb.ToString();
        }
        static string ConvertJsonToXml(string json)
        { 
            User? user = GetUserFromJson(json);
            XmlSerializer xml = new XmlSerializer(typeof(User));
            StringBuilder sb = new StringBuilder();
            xml.Serialize(new StringWriter(sb), user);
            //Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

    }
}