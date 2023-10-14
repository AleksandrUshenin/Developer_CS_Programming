using System;

namespace С_Lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Exe10(456));
            Console.WriteLine(Exe10(782));
            Console.WriteLine(Exe10(918));

            Console.WriteLine(Exe13(645));
            Console.WriteLine(Exe13(78));
            Console.WriteLine(Exe13(32679));

            Console.WriteLine(Exe15(6));
            Console.WriteLine(Exe15(7));
            Console.WriteLine(Exe15(1));



            Console.ReadLine();
        }
        static char Exe10(int num)
        {
            string res = num.ToString();
            if (res.Length > 1)
                return res[1];
            return ' ';
        }
        static string Exe13(int num)
        {
            string res = num.ToString();
            if (res.Length > 2)
                return res[2].ToString();
            else if (string.IsNullOrEmpty(res))
                return "empty";
            return "третьей цифры нет";
        }
        static string Exe15(int num)
        {
            string res = num.ToString();
            if (string.IsNullOrEmpty(res))
                return "empty";
            else if (res == "6" || res == "7")
                return "да";
            return "нет";
        }
    }
}