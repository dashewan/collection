using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketClient
{
    public class OnLine
    {
        
       
        
        public void Receive()
        {
            Socket socket1 = new Socket(SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 2255);
            socket1.Bind(iep);
            EndPoint endPoint = (EndPoint)iep;
            Console.WriteLine("Ready to receive…");
            byte[] b = new byte[1024];
            int rev = socket1.ReceiveFrom(b,ref endPoint);
            string content=Encoding.ASCII.GetString(b,0, rev);
            Console.WriteLine("received: {0} from: {1}", content, iep.ToString());
            socket1.Close();
        }
        public void Send()
        {

            Socket socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Broadcast, 2255);
            string hostName = Dns.GetHostName();
            byte[] data = Encoding.ASCII.GetBytes(hostName);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, ipPoint);
           
            socket.Close();
        }
        //300毫秒发送一次消息
        public void SendOnLine()
        {

            while (true)
            {
                Send();
                Thread.Sleep(300);
            }
        }
        public void ReceiveOnLine()
        {
            while (true)
            {
                Receive();
                Thread.Sleep(300);
            }
           
        }

    }
}
