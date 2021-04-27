using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    public class Chat
    {
        public void Process()
        {
            //新建客户端套接字  
            Socket socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //连接服务器  
            socket.Bind(new IPEndPoint(IPAddress.Any, 8001));
            socket.Listen(1024);
            socket.NoDelay = false;


            work w = new work();
            
            while (true)
            {
                w.socket = socket.Accept();
                Thread t = new Thread(new ThreadStart(w.Receive));
                t.Start();
                Thread t1 = new Thread(new ThreadStart(w.Send));
                t1.Start();
            }
          
        }
    }
    class session
    {
        private byte[] _buffer;
        private string _datagram;
        private byte[] _bufferLength;

        private Socket _clientSock;
        public session()
        {

        }
    }
    class work
    {
        public Socket socket;

        public void Receive()
        {
            while (true)
            {
                //接受服务器返回的消息  
                byte[] back = new byte[100];
                //基本接受信息
                //socket.Receive(back, SocketFlags.None);
                
                MyMethod m1 = method;
                socket.BeginReceive(back,0, back.Length, SocketFlags.None,new AsyncCallback(HandleMessage), socket);
                string inBufferStr = Encoding.UTF8.GetString(back); 
                Console.Write(inBufferStr);
            }
        }
        private delegate string MyMethod();
        private static string method()
        {
           
            
            return "什么意思";
        }
        public void HandleMessage(IAsyncResult arg)
        {
            if (arg == null || arg.AsyncState == null)
            {
                Console.WriteLine("回调失败！！！");
                return;
            }
            int receiveBuffer = (arg.AsyncState as Socket).EndReceive(arg);
          
            Console.WriteLine("任务完成，结果：" + receiveBuffer);
        }
        public void Send()
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("输入要发送的消息");
                    //读入要传输的字符  
                    string str = Console.ReadLine();

                    //得到流  
                    byte[] b = Encoding.ASCII.GetBytes(str);
                    socket.Send(b, b.Length, SocketFlags.None);
                }
                catch
                {
                    //关闭连接  
                    socket.Close();
                    break;
                }
            }
        }
    }
}
