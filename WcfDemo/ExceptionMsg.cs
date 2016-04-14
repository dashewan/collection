using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfDemo
{
    [DataContract] 
    public class ExceptionMsg
    {
        /// <summary> 

        /// 异常消息文本 

        /// </summary> 

        [DataMember]
        
        public string Message { get; set; }



        /// <summary> 

        /// 异常编码 

        /// </summary> 

        [DataMember]

        public string Code { get; set; } 

 
    }
}