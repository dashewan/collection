using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClient.WCF;
namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IService1 service = new Service1Client();
            string aa= service.GetData(2);
            Console.WriteLine(aa);
            CompositeType type = new CompositeType();
            type.StringValue = "TEST";
            type=service.GetDataUsingDataContract(type);
            type.BoolValue = true;
            Console.WriteLine(type.StringValue);
            type=service.GetDataUsingDataContract(type);
            Console.WriteLine(type.StringValue);
            //try
            //{
            //    WCF.IService1 client = new WCF.Service1Client();
            //    Console.Write(client.ThrowException(true));
            //}
            //catch (FaultException e)
            //{
            //    Console.Write(e.Message);
            //}
            //WCF.CompositeType type = new WCF.CompositeType();
            //type.StringValue = "wangtao";
            //type.BoolValue = true;
            //type=client.GetDataUsingDataContract(type);
            //Console.WriteLine(type.StringValue);
            //WCF.GetMSGRequest request=new WCF.GetMSGRequest();

            //WCF.IMSQ msq= client.GetMSG(request);
            //Console.WriteLine(msq.ResponseToGreeting);

            //Console.WriteLine(msq.AAAA);
        }
    }
}
