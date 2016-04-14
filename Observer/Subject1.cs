using System;

namespace Observer
{
    public class Subject1:Subject
    {
        public override void Inform()
        {
            Console.WriteLine("Subject1通知");
        }

        public override void Test()
        {
            throw new NotImplementedException();
        }
        public new void Test(string aa)
        {

        }
    }
}
