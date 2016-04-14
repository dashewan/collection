using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class MonkeyKingPrototype
    {
        public string id { set; get; }
        public Student student { set; get; }
        public MonkeyKingPrototype(string id,Student student)
        {
            this.id = id;
            this.student = student;
        }
        public abstract MonkeyKingPrototype Clone();
       
    }
    public class Student
    {
        public string Name { set; get; }
        public string Age { set; get; }
    }
}
