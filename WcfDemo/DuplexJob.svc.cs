using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class DuplexJob : IDuplexJob
    {
        public string DoWork(string jobName)
        {

            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            Console.Write("服务" + AppDomain.CurrentDomain.FriendlyName + "执行任务：" + jobName);
            callback.DoWork();
            return "成功";
        }
    }
}
