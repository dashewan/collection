using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFConsole
{

    public sealed class CollectionActivity : CodeActivity
    {
        public OutArgument<System.Collections.Generic.List<string>> myOutCollection { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            System.Collections.Generic.List<string> list = new List<string>();

            list.Add("wxd");

            list.Add("lzm");

            list.Add("wxwinter");

            context.SetValue(this.myOutCollection, list);
        }
    }
}
