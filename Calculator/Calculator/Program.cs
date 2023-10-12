namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate caulc = new Calculate();

            Console.WriteLine("Result: " + caulc.Run(Run()));

            Console.ReadLine();
        }
        private static string Run()
        {
            Console.Write("Write: ");
            return Console.ReadLine()!;
        }
    }
}