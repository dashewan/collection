﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfDemo
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int ThrowException(bool b)
        {

            if (b)
            {
                ExceptionMsg msg = new ExceptionMsg();
                msg.Message = "自己抛出错误";
                msg.Code = "001";
                throw new FaultException<ExceptionMsg>(msg);
            }
            return 1;
        }
       

        public string GetException()
        {
            throw new NotImplementedException();
        }


        public IMSQ GetMSG()
        {
            IMSQ msq = new IMSQ();
            msq.ExtraValues = "sdfsdfsf";
            msq.Response = "dddd";
            return msq;
        }
    }
}
