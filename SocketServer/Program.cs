using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace SocketServer
{
    class Program
    {
        public static void Main()
        {
          
            Chat chat = new Chat();
            chat.Process();
        }
    }
}
