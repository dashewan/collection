using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMSQ”。
    [MessageContract]
    public class IMSQ
    {
        private string localResponse = string.Empty;
        private string extra = string.Empty;
        [MessageBodyMember(
            Name="ResponseToGreeting",
            Namespace="http://wangtao.cnblogs.com"
            )]
        public string Response
        { 
            get{return localResponse;}
            set{localResponse=value;}
        }
        [MessageBodyMember(
            Name = "AAAA",
            Namespace = "http://wangtao.com"
            )]
        public string ExtraValues
        {
            get { return extra; }
            set { this.extra=value;}
        }
        
    }
}
