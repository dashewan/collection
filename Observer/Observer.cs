using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Observer
    {

        List<Subject> list = new List<Subject>();
        public void Add(Subject subject) {
            list.Add(subject);
        }
        public void Remove(Subject subject) {
            list.Remove(subject);
        }
        public void Notify()
        {
            foreach(Subject subject in list)
            {
                subject.Inform();
            }
        }
        
    }
}
