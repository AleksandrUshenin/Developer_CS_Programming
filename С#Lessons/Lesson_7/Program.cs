namespace Lesson_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRate(3, 5));
            Console.WriteLine(GetRate(2, 4));

            Console.WriteLine(GetSumNumbers(452));
            Console.WriteLine(GetSumNumbers(82));
            Console.WriteLine(GetSumNumbers(9012));

            Console.WriteLine(GetArray(1, 2, 5, 7, 19));
            Console.WriteLine(GetArray(6, 1, 33));

        }   
        static int GetRate(int number, int rate)
        {
            int res = number;
            for (int i = 0; i < rate - 1; i++) 
            {
                res *= number;
            }
            return res;
        }
        static int GetSumNumbers(int number)
        {
            string strNum = number.ToString();
            int res = 0;
            foreach ( char c in strNum ) 
            {
                res += int.Parse(c.ToString());
            }
            return res;
        }
        static int[] GetArray(params int[] numbers)
        {
            int[] res = numbers;
            Console.Write("[");
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.Write($" {numbers[i]}" + (i != numbers.Length - 1 ? "," : " "));
            }
            Console.Write("]\n");
            return res;
        }
    }
}