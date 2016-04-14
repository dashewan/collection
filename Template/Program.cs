﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Vegetable spinach = new Spinach();
            spinach.CookVegetabel();
            Vegetable cc = new ChinaCabage();
            cc.CookVegetabel();
        }
    }
}
