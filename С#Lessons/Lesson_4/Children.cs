using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    internal class Children
    {
        public Person Mother { get; set; }
        public Person Father { get; set; }
        private Person[] ArrChildren;
        public Children(Person mother, Person father)
        {
            Mother = mother;
            Father = father;
        }
        public void Add(Person persone)
        {
            if (this.ArrChildren == null)
            {
                this.ArrChildren = new Person[] { persone };
                return;
            }
            Person[] children = new Person[this.ArrChildren.Length + 1];
            Array.Copy(this.ArrChildren, children, this.ArrChildren.Length);
            children[children.Length - 1] = persone;
            this.ArrChildren = children;
        }
        public void Print()
        {
            foreach (var obj in ArrChildren)
            {
                //Console.Write("\t");
                Console.WriteLine(obj);
                Console.Write("\t");
                obj.PrintParants();
            }
        }
    }
}
