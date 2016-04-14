using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
   public class ComplexComposite : Graphics
    {
        List<Graphics> graphicsList = new List<Graphics>();
        public override void Add(Graphics g)
        {
            graphicsList.Add(g);
        }

        public override void Draw()
        {
            foreach(Graphics g in graphicsList)
            {
                g.Draw();
            }
        }

        public override void Remove(Graphics g)
        {
            graphicsList.Remove(g);
        }
    }
}
