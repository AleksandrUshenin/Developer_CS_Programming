using System.Globalization;

namespace SorterArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };

            var result = Sorter(a);

            Console.ReadLine();
        }
        static int[,] Sorter(int[,] array) 
        {
            int[] result = new int[array.GetLength(0) * array.GetLength(1)];
            int index = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    result[index++] = array[i, j];
                }
            }

            index = 0;
            Array.Sort(result);

            int[,] result2 = new int[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    result2[i, j] = result[index++];
                }
            }

            return result2;
        }
    }
}