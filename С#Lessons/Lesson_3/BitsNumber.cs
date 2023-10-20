using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    internal interface IBitsNumber
    {
        int SetBit(int value, int index, bool bit);
        int GetBit(int value, int index);
    }
}
