using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistor
{
    public interface IVistor
    {
        void Vistor(ElementA A);
        void Vistor(ElementB B);
    }
}
