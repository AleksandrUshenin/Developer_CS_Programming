using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    internal class Bits : IBitsNumber
    {
        public int GetBit(int value, int index)
        {
            if (index > 7 || index < 0)
                return 0;
            return (value >> index) & 1;
        }

        public int SetBit(int value, int index, bool bit)
        {
            if (index > 7 || index < 0) return 0;
            if (bit == true)
                value = (byte)(value | (1 << index));
            else
            {
                var mask = (byte)(1 << index);
                mask = (byte)(0xff ^ mask);
                value &= (byte)(value & mask);
            }
            return value;
        }
    }
}
