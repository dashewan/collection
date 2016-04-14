using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            FlyWeightFactory factory = new FlyWeightFactory();
            FlyWeight fwA= factory.GetFlyWeight("A");
            if (fwA != null)
            {
                fwA.Oparetor();
            }
            FlyWeight fwB = factory.GetFlyWeight("B");
            if (fwB != null)
            {
                fwB.Oparetor();
            }
            FlyWeight fwC = factory.GetFlyWeight("C");
            if (fwC != null)
            {
                fwC.Oparetor();
            }
            FlyWeight fwD = factory.GetFlyWeight("D");
            if (fwD != null)
            {
                fwD.Oparetor();
            }
            else
            {
                ConcreteFlyWeight cfw = new ConcreteFlyWeight("D");
                factory.list.Add("D", cfw);
            }
            FlyWeight fw  = factory.GetFlyWeight("D");
            if (fw  != null)
            {
                fw.Oparetor();
            }
        }
    }
}
