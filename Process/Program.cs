using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Threading;

namespace Process
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateMSMQ("aaaa");
            //SendMsg("aaaa");
            //ReceiveMsg("aaaa");
           
            //DeleteMSMQ("aaaa");
        }
        public static void CreateMSMQ(string name)
        {
            if (!MessageQueue.Exists(@".\private$\" + name))
            {
                MessageQueue mq = MessageQueue.Create(@".\private$\" +name);
                mq.Label = "name";
                Console.WriteLine("创建成功");
            }
            else
            {
                Console.WriteLine("已存在");
            }
            
        }
        public static void DeleteMSMQ(string name)
        {
            
                MessageQueue.Delete(@".\private$\" + name);
               
                Console.WriteLine("删除成功");
        }
        public static void SendMsg(string name)
        {
            MessageQueue mq = new MessageQueue(@".\private$\" + name);
            for (int i = 0; i < 10; i++)
            {
                Book book = new Book(2,"book",(decimal)Math.Round(3.0)*1000);
                Message message = new Message();
                message.Body = book;
                message.Formatter = new XmlMessageFormatter(new Type[] { typeof(Book) });
                mq.Send(message);

            }
            Console.WriteLine("发送成功");
        }
        public static void SendMsgLog(string name)
        {
            MessageQueue mq = new MessageQueue(@".\"+name+"\\Joumal$" );
            for (int i = 0; i < 10; i++)
            {
                Book book = new Book(2, "book", (decimal)Math.Round(3.0) * 1000);
                Message message = new Message();
                message.Body = book;
                message.Formatter = new XmlMessageFormatter(new Type[] { typeof(Book) });
                mq.Send(message);

            }
            Console.WriteLine("发送成功");
        }
        public static void ReceiveMsg(string name)
        {
            MessageQueue mq = new MessageQueue(@".\private$\" + name);
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(Book) });
            for (int i = 0; i < 10; i++)
            {
                Message message = mq.Receive();
                Book book = (Book)message.Body; //获取消息的内容 
                Console.WriteLine("消息内容为：" + book.ID + "\n" + book.Name + "\n" + book.CreateTime + "\n" + book.Money);
            }
        }
    }
    [Serializable]
    public class Book
    {
        public Book()
        {
            
        }
        public Book(int id,string name,decimal money)
        {
            this.ID = id;
            this.Name = name;
            this.CreateTime = DateTime.Now;
            this.Money = money;
        }
        public int ID { set; get; }
        public string Name { set; get; }
        public DateTime CreateTime { set; get; }
        public decimal Money { set; get; }

    }
}
