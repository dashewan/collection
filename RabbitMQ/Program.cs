using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQSend
{
    class Program
    {
        static void Main(string[] args)
        {
            //HelloWorld.Send();
            WorkQueues.Send(args);
            Console.ReadLine();
        }
    }
}
