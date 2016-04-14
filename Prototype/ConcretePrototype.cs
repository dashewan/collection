using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id, Student student) : base(id,student)
        {

        }
        public override MonkeyKingPrototype Clone()
        {
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }
}
