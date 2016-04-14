using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    public class FlyWeightFactory
    {
        public Dictionary<string, ConcreteFlyWeight> list = new Dictionary<string, ConcreteFlyWeight>();
        public FlyWeightFactory()
        {
            list.Add("A",new ConcreteFlyWeight("A"));
            list.Add("B", new ConcreteFlyWeight("B"));
            list.Add("C", new ConcreteFlyWeight("C"));
        }
        public ConcreteFlyWeight GetFlyWeight(string key)
        {
            if (list.ContainsKey(key))
            {
                return list[key];
            }
            else
            {
                return null;
            }
        }
    }
}
