namespace Lesson_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long l = 1234;
            int i = 3333;
            byte b = 32;
            Bits res1 = (Bits)l;
            Bits res2 = (Bits)i;
            Bits res3 = (Bits)b;

            Console.WriteLine(res1);
            Console.WriteLine(res1.Value);
            Console.WriteLine(res2);
            Console.WriteLine(res2.Value);
            Console.WriteLine(res3);
            Console.WriteLine(res3.Value);
        }
    }
}