namespace Lesson_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Ex41_1(Ex41()));
        }
        static string[] Ex41()
        {
            Console.WriteLine("Введите числа :");
            string? str = Console.ReadLine();
            string[] numbers = str != null ? str.Split(',', ' ') : null;
            return numbers;
        }
        static int Ex41_1(string[] numbers)
        {
            int count = 0;
            foreach (string number in numbers)
            {
                int.TryParse(number, out int result);
                if (result > 0)
                    count++;
            }
            return count;
        }
    }
}