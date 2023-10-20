using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    internal class Famaly
    {
        public static void Widing(Person person1, Person person2)
        {
            Children ch;
            if (person1.GenderPerson == Gender.Man)
                ch = new Children(person2, person1);
            else
                ch = new Children(person1, person2);
            person1.AddPartner(person2);
            person2.AddPartner(person1);
            person1.AddChildren(ch);
            person2.AddChildren(ch);
        }
    }
}
