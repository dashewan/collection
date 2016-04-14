﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ApplePhone:Phone
    {
       
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }
}
