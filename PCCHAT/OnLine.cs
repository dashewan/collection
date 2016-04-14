using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PCCHAT
{
    public class OnLine
    {


        List<User> receiveList = new List<User>();
        public User Receive()
        {
            lock (this)
            {
                Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 2255);
                socket1.Bind(iep);
                EndPoint endPoint = (EndPoint)iep;

                byte[] b = new byte[1024];
                int rev = socket1.ReceiveFrom(b, ref endPoint);
                string content = Encoding.ASCII.GetString(b, 0, rev);
                User user = JsonConvert.DeserializeObject<User>(content);

                socket1.Close();
            
            return user;
            }
        }
        public void Send()
        {
            lock (this)
            {
                Socket socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Broadcast, 2255);
                User user = new User(Dns.GetHostName(), Dns.GetHostAddresses(Dns.GetHostName())[0].ToString(), 999, User.ENUMSTATUS.ON);
                string json = JsonConvert.SerializeObject(user);

                byte[] data = ASCIIEncoding.ASCII.GetBytes(json);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                socket.SendTo(data, ipPoint);

                socket.Close();
            }
        }
        //程序退出，发送下线消息
        public void SendOffLine()
        {
           
                Socket socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Broadcast, 2255);
                User user = new User(Dns.GetHostName(), Dns.GetHostAddresses(Dns.GetHostName())[0].ToString(), 999, User.ENUMSTATUS.OFF);
                string json = JsonConvert.SerializeObject(user);

                byte[] data = ASCIIEncoding.ASCII.GetBytes(json);
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
                User user=Receive();
                int index=receiveList.FindIndex(e => e.IP == user.IP);
                if (index < 0)
                {
                    receiveList.Add(user);
                }
                else
                {
                    //if (user.STATUS == User.ENUMSTATUS.OFF)
                    //{
                        receiveList[index].STATUS = user.STATUS;
                    //}
                }
                Thread.Sleep(300);
            }

        }
        //获取信息
        public  List<User> OnLineUser()
        {
            lock (receiveList)
            {
                return receiveList;
            }
        }

    }
}
