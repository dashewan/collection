﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class ConcreteAggregate : Aggregate
    {
        Interator interator;
        public override Interator GetIterator()
        {
            return new ConcreteInterator(this);
        }
    }
}
