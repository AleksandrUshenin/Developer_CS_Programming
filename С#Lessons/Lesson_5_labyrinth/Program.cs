using System.Drawing;

namespace Lesson_5_labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1},// 0
                { 1, 0, 0, 0, 0, 0, 0, 0, 1},// 1
                { 1, 0, 1, 1, 1, 0, 1, 0, 1},// 2
                { 1, 0, 1, 0, 1, 1, 1, 0, 1},// 3
                { 0, 0, 0, 0, 0, 0, 1, 0, 2},// 4
                { 1, 0, 1, 0, 1, 0, 1, 0, 1},// 5
                { 1, 0, 1, 0, 1, 0, 1, 0, 1},// 6
                { 1, 0, 1, 0, 1, 0, 1, 0, 1},// 7
                { 1, 1, 1, 2, 1, 1, 1, 2, 1} // 8
            };
            Console.WriteLine(OutToLabirint(arr, 4, 0));
        }
        public static int OutToLabirint(int[,] arr, int indexX, int indexY)
        {
            int count = 0;
            if (arr[indexX, indexY] == 1)
            {
                Console.WriteLine("Мы в стине!");
                return 0;
            }
            else if (arr[indexX, indexY] == 2)
            {
                Console.WriteLine($"Мы в вышли! {indexX} {indexY}");
                count++;
            }
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>(10);
            stack.Push(new Tuple<int, int>(indexX, indexY));
            while (stack.Count != 0)
            {
                var point = stack.Pop();
                if (arr[point.Item1, point.Item2] == 2)
                {
                    Console.WriteLine($"Мы в вышли! {point.Item1} {point.Item2}");
                    count++;
                }
                arr[point.Item1, point.Item2] = 1;
                if (point.Item2 - 1 >= 0 && arr[point.Item1, point.Item2 - 1] != 1) //left
                {
                    stack.Push(new Tuple<int, int>(point.Item1, point.Item2 - 1));
                }
                if (point.Item1 - 1 >= 0 && arr[point.Item1 - 1, point.Item2] != 1) //Up
                {
                    stack.Push(new Tuple<int, int>(point.Item1 - 1, point.Item2));
                }
                if (point.Item2 + 1 < arr.GetLength(1) && arr[point.Item1, point.Item2 + 1] != 1) //Right
                {
                    stack.Push(new Tuple<int, int>(point.Item1, point.Item2 + 1));
                }
                if (point.Item1 + 1 < arr.GetLength(0) && arr[point.Item1 + 1, point.Item2] != 1) //Down
                {
                    stack.Push(new Tuple<int, int>(point.Item1 + 1, point.Item2));
                }
            }
            if (count > 0)
                return count;
            return 0;
        }
    }
}