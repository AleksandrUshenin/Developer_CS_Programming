using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    enum Gender
    {
        Man,
        Woman
    }
    internal class Person
    {
        public string Name { get; private set; }
        public Gender GenderPerson { get; private set; }
        public Person Mother { get; private set; }
        public Person Father { get; private set; }
        public Person Partner { get; private set; }
        public Children Children { get; private set; }
        public Person(string name, Gender gender, Person mother, Person father)
        {
            this.Name = name;
            this.GenderPerson = gender;
            this.Mother = mother;
            this.Father = father;
        }
        public override string ToString()
        {
            string res = "Name:{0}, Gender:{1}{2}{3}";
            if (this.Partner != null)
            {
                string part = this.GenderPerson == Gender.Man ? ", Wife:" : ", Husband:";
                res = String.Format(res, Name, GenderPerson, part, Partner.Name);
            }
            else
                res = String.Format(res, Name, GenderPerson, "", Partner);
            return res;
        }
        public void PrintParants()
        {
            string res = "Person:{0}\n\tMother:{1};  Father:{2}";
            Console.WriteLine(String.Format(res, Name, Mother == null ? "None" : Mother, Father));
        }
        public void PrintPartner()
        {
            string res = "Partner:{0}";
            Console.WriteLine(String.Format(res, Partner));
        }
        public void AddPartner(Person person)
        {
            Partner = person;
        }
        public void AddChildren(Children children)
        {
            this.Children = children;
        }
    }
}
