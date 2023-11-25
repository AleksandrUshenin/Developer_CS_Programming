namespace Lesson_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task64(1, 5);
            //Console.WriteLine();
            //Task64(4, 8);
            //Console.WriteLine();
            Console.WriteLine(Task66(1, 15));
            Console.WriteLine(Task66(4, 8));
        }
        private static void Task64(int M, int N)
        {
            if (M % 2 == 0)
                Console.Write(M + "\t");
            if (N != M)
                Task64(M + 1, N);
        }
        public static int Task66(int M, int N)
        {
            if (M == N)
                return N;
            int result = M + Task66(M + 1, N);
            return result;
        }
        public static int Task68()
        { return 0; }
    }
}