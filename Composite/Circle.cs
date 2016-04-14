using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Circle : Graphics
    {
        public override void Add(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            Console.WriteLine("画个圆");
        }

        public override void Remove(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
