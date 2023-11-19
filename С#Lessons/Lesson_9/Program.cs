namespace Lesson_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Ex41_1(Ex41()));

            int n = 3;
            int m = 4;
            int k = 2;

            int ind = 1;
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < m; j++) 
                {
                    matrix[i, j] = ind;
                    ind += k;
                }
            }

            int n1 = matrix.GetLength(0);
            int m1 = matrix.GetLength(1);
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int l1 = matrix.GetLength(0);
            int l2 = matrix.GetLength(1);
            double[] res = new double[l2];
            for (int i = 0; i < l2; i++)
            {
                for (int j = 0; j < l1; j++)
                {
                    res[i] += matrix[j, i];
                }
                res[i] = res[i] / l1;
            }

            Console.WriteLine("The averages in columns are:");
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] % 1 == 0)
                {
                    Console.Write(res[i] + ".00\t");
                }
                else
                    Console.Write(res[i].ToString("#.##") + "\t");
            }
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