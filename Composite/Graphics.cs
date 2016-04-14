using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class Graphics
    {
        public abstract void Add(Graphics g);
        public abstract void Draw();
        public abstract void Remove(Graphics g);
    }
}
