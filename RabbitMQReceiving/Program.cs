﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace RabbitMQReceiving
{
    class Program
    {
        static void Main(string[] args)
        {
            //HelloWorld.Receiving();
            WorkQueues.Receiving();
            Console.ReadLine();
        }
    }
}
