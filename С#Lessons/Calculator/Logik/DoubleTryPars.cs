using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Logik
{
    public class MyDouble
    {
        public static bool DoubleTryPars(string data, out double result)
        {
            result = 0;
            try
            {
                result = Convert.ToDouble(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckingForPositiveNumber(double number)
        {
            if (number < 0)
            {
                throw new Exception("Отрицательное число");
                return true;   
            } 
            return true;
        }
    }
}
