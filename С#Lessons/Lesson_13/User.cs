using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"{ID} {Name} {SurName} {Birthday} {City}";
        }
    }
}
