using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ContactPerson> persons = new List<ContactPerson>()
            {
                new ContactPerson() { Name= "Learning Hard", MobileNum = "123445"},
                new ContactPerson() { Name = "Tony", MobileNum = "234565"},
                new ContactPerson() { Name = "Jock", MobileNum = "231455"}
            };
            MobileOwner owner = new MobileOwner(persons);
            owner.Show();
            Caretaker cTaker = new Caretaker();
            cTaker.contactMemento.Add(DateTime.Now.ToString(), owner.CreateMemento());
            Console.WriteLine("-------删除一条-------");
            owner.ContactPerson.RemoveAt(2);
            owner.Show();
            Console.WriteLine("-------删除一条-------");
            Thread.Sleep(1000);
            cTaker.contactMemento.Add(DateTime.Now.ToString(), owner.CreateMemento());
            foreach(string s in cTaker.contactMemento.Keys)
            {
                Console.WriteLine("key={0}", s);
            }
            var collection = cTaker.contactMemento.Keys;
            while (true)
            {
                int l=int.Parse(Console.ReadLine());
                ContactMemento memeto = null;
                if (l < collection.Count && cTaker.contactMemento.TryGetValue(collection.ElementAt(l), out memeto))
                {
                    owner.RestoreMemento(memeto);
                    owner.Show();
                }
            }
           
           

        }
    }
}
