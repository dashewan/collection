using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketClient
{
    class Program
    {
        public static void Main()
        {
            OnLine line = new OnLine();
            Thread thread = new Thread(new ThreadStart(line.SendOnLine));
            thread.Start();
            Thread thread1 = new Thread(new ThreadStart(line.ReceiveOnLine));
            thread1.Start();
            Console.Read();
        }
          
    }
    

}
