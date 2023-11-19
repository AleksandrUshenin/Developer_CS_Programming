using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_10
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CustomNameAttribute : Attribute
    {
        public string Name { get; }
        public CustomNameAttribute(string name)
        {
            Name = name;
        }
    }
}
