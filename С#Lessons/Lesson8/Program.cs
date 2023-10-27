namespace Lesson8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrLen = 15;
            int FindSumNum = 11;
            
            int[] arr = new int[arrLen];
            for (int i = 0; i < arrLen; i++)
            {
                arr[i] = new Random().Next(-20, 20);
            }
            arr.ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            TestMethods(Get2Num(arr, FindSumNum), FindSumNum);
            TestMethods(Get3Num(arr, FindSumNum), FindSumNum);

        }
        static bool TestMethods(List<Tuple<int, int>> result, int num)
        {
            Console.WriteLine($"Num = {num}");
            bool test = true;

            Console.WriteLine("count-List:" + result.Count);
            foreach (var d in result)
            {
                Console.WriteLine(d);
                if (d.Item1 + d.Item2 != num)
                    test = false;
            }

            Console.WriteLine("==================" + test);
            return test;
        }
        static bool TestMethods(List<Tuple<int, int, int>> result, int num)
        {
            Console.WriteLine($"Num = {num}");
            bool test = true;

            Console.WriteLine("count-List:" + result.Count);
            foreach (var d in result)
            {
                Console.WriteLine(d);
                if (d.Item1 + d.Item2 + d.Item3 != num)
                    test = false;
            }

            Console.WriteLine("==================" + test);
            return test;
        }
        static List<Tuple<int, int>> Get2Num(int[] arr, int num)
        {
            int target = num;
            var s = new HashSet<int>();
            List<Tuple<int, int>> result = new List<Tuple<int, int>>(arr.Length / 2);
            for (int i = 0; i < arr.Length; i++)
            {
                int x = target - arr[i];
                if (s.Contains(arr[i]))
                {
                    result.Add(new Tuple<int, int>(arr[i], x));
                }
                else
                {
                    s.Add(x);
                }
            }
            return result;
        }
        static List<Tuple<int, int, int>> Get3Num(int[] arr, int num)
        {
            int target = num;
            var s = new HashSet<int>();
            List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>(arr.Length / 3);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int x = target - arr[j] - arr[i];
                    if (arr[i] != x && arr[j] != x && s.Contains(arr[i]) && arr.Contains(x))//&& s.Contains(arr[j]) 
                    {
                        result.Add(new Tuple<int, int, int>(arr[i], arr[j], x));
                    }
                    else
                    {
                        s.Add(x);
                    }
                }
            }
            return result;
        }
    }
}