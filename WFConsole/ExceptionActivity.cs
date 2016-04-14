using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFConsole
{

    public sealed class ExceptionActivity : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            int v = 1 - 1;

            double i = 1 / v;
        }
    }
}
