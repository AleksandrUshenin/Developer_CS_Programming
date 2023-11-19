using System.Reflection;
using System.Security.AccessControl;
using System.Text;

namespace Lesson_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass(100, "this is text", 100.123m, new char[] { 'a', 'b', 'c', 'd' });
            var result = ObjectToString(testClass);
            Console.WriteLine(result);
        }
        //        Урок 7. Рефлексия
        //Разработайте атрибут позволяющий методу ObjectToString сохранять поля классов с использованием произвольного имени.

        //Метод StringToObject должен также уметь работать с этим атрибутом для записи значение в свойство по имени его атрибута.

        //[CustomName(“CustomFieldName”)]
        //public int I = 0.

        //Если использовать формат строки с данными использованной нами для предыдущего примера то пара ключ значение для свойства I выглядела бы CustomFieldName:0

        //Подсказка:

        //Если GetProperty(propertyName) вернул null то очевидно свойства с таким именем нет и возможно имя является алиасом заданным с помощью CustomName.Возможно,
        //если перебрать все поля с таким атрибутом то для одного из них propertyName = совпадает с таковым заданным атрибутом.

        static string ObjectToString(object o)
        {
            if (o == null)
                return null;

            var type = o.GetType();
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name class: {type.Name}\n");

            var dataClass2 = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var item in dataClass2)
            {
                var resSelectAttribute = item.GetCustomAttributes(typeof(CustomNameAttribute), true).FirstOrDefault() as CustomNameAttribute;
                if (resSelectAttribute != null) 
                {
                    sb.Append($"({item.PropertyType.ToString().Split('.')[1]}) ");
                    sb.Append(resSelectAttribute.Name);

                    if (item.PropertyType == typeof(char[]))
                    {
                        var ch = item.GetValue(o) as char[];
                        sb.Append(" = ");
                        foreach (var c in ch)
                        {
                            sb.Append(c.ToString() + ' ');
                        }
                        sb.Append("\n");
                    }
                    else
                    {
                        sb.Append($" = {item.GetValue(o)}\n");
                    } 
                }
            }
            return sb.ToString();
        }
    }
}