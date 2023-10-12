using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calculate
    {
        public int Run(string data)
        {
            int result = 0;
            return Calc(result, data);
        }
        private int Calc(int result, string data)
        {
            char[] znak = new char[] { '*', '/', '+', '-' };
            foreach (var z in znak)
            {
                int zz = data.IndexOf(z);
                int len = data.Length - data.IndexOf(z) - 1;
                if (data.IndexOf(z) > 0)
                {
                    int left = ParseInt(data.Substring(0, data.IndexOf(z)));
                    int right = ParseInt(data.Substring(data.IndexOf(z) + 1, data.Length - data.IndexOf(z) - 1));
                    result = Math(left, right, z);
                }
            }
            return result;
        }
        private int ParseInt(string data)
        {
            int result = 0;
            int.TryParse(data, out result);
            return result;
        }
        private int Math(int a, int b, char znak)
        {
            switch (znak)
            {
                case '*':
                    return a * b;
                case '/':
                    if (b > 0)
                        return a / b;
                    return 0;
                case '+':
                    return a + b;
                case '-':
                    return a - b;
            }
            return 0;
        }
    }
}
