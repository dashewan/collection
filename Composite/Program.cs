using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphics g = new Line();
            g.Draw();
            Graphics g2 = new Circle();
            g2.Draw();
            Graphics g1 = new ComplexComposite();
            g1.Add(g); g1.Add(g2);
            g1.Draw();
            g1.Remove(g);
            g1.Draw();
        }
    }
}
