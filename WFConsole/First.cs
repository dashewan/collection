using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFConsole
{

    public sealed class First : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> myIn { get; set; }
        public OutArgument<string> myOut { get; set; }
        public InOutArgument<string> test { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
           
            string s1 = context.GetValue(this.myIn);
            context.SetValue(test, Guid.NewGuid().ToString());
            //myIn.Set(context, s1 + "修改");
            //myOut.Set(context, s1 + "返回的");
            //string s2=context.GetValue(myOut);
            context.SetValue(myOut, s1 + "返回的");



        }
    }
}
