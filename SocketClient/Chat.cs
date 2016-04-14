using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketClient
{
    public class Chat
    {
        public void Process()
        {
            //新建客户端套接字  
            TcpClient tclient = new TcpClient();
            //连接服务器  
            tclient.Connect("127.0.0.1", 8001);
            work w = new work();
            w.tclient = tclient;

            Thread t = new Thread(new ThreadStart(w.Receive));
            t.Start();
            Thread t1 = new Thread(new ThreadStart(w.Send));
            t1.Start();
        }
    }
    class work
    {
        public TcpClient tclient;

        public void Receive()
        {
            while (true)
            {
                //接受服务器返回的消息  
                byte[] back = new byte[100];
                Stream stm = tclient.GetStream();
                int k = stm.Read(back, 0, 100);
                //输出服务器返回的消息  
                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(back[i]));
                }
            }
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
                    Stream stm = tclient.GetStream();
                    //发送字符串  
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] data = asen.GetBytes(str);
                    stm.Write(data, 0, data.Length);
                }
                catch
                {

                    //关闭连接  
                    tclient.Close();
                    break;
                }
            }
        }
    }
}
