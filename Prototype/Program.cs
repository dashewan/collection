using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "dsfsdf";
            student.Age = "22";
            MonkeyKingPrototype prototype = new ConcretePrototype("test", student);
            prototype.id = "sddf";
            MonkeyKingPrototype prototype1=prototype.Clone();
            Console.WriteLine(prototype1.id+"===="+prototype1.student.Name);
            prototype1.student.Name = "fsdfsdf";
            MonkeyKingPrototype prototype2 = prototype.Clone();
            Console.WriteLine(prototype2.id + "====" + prototype2.student.Name);
        }
    }
}
