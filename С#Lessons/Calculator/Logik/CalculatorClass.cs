using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Logik
{
    class CalculatorClass : ICalculator
    {
        private double result;
        public double Result { get { return result; } }
        public event EventHandler<EventArgs>? MyEventHandler;
        private Stack<double> stack;

        internal CalculatorClass() 
        {
            result = 0;
            stack = new Stack<double>(10);
        }
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }

        public void Divide(double x)
        {
            if (x == 0)
                return;
            stack.Push(result);
            result /= x;
            PrintResult();
        }

        public void Multy(double x)
        {
            stack.Push(result);
            result *= x;
            PrintResult();
        }

        public void Sub(double x)
        {
            stack.Push(result);
            result -= x;
            PrintResult();
        }

        public void Sum(double x)
        {
            stack.Push(result);
            result += x;
            PrintResult();
        }

        public void Cansale()
        {
            if (stack.Count == 0)
                return;
            result = stack.Pop();
            PrintResult();
        }
    }
}
