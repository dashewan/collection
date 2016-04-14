using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFConsole
{

    public sealed class rollbackTransactionActivity : NativeActivity
    {
        public InArgument<string> Text { get; set; }



        protected override void Execute(NativeActivityContext context)
        {

            // Reference System.Transactions.Dll

            RuntimeTransactionHandle runtimeTransactionHandle = new RuntimeTransactionHandle();

            runtimeTransactionHandle = context.Properties.Find(runtimeTransactionHandle.ExecutionPropertyName) as RuntimeTransactionHandle;

            var transaction = runtimeTransactionHandle.GetCurrentTransaction(context);

            var info = transaction.TransactionInformation;
            System.Console.WriteLine("LocalIdentifier:{0} ", info.LocalIdentifier);
            System.Console.WriteLine("CreationTime:{0} ", info.CreationTime);
            System.Console.WriteLine("Status:{0} ", info.Status.ToString());
            System.Console.WriteLine("DistributedIdentifier:{0} ", info.DistributedIdentifier);
            System.Console.WriteLine("IsolationLevel:{0} ", transaction.IsolationLevel.ToString());
            transaction.TransactionCompleted += new System.Transactions.TransactionCompletedEventHandler(transaction_TransactionCompleted);
            //回滚当前事务
            transaction.Rollback(new System.Exception("wxwinter回滚事务说明"));
        }



        void transaction_TransactionCompleted(object sender, System.Transactions.TransactionEventArgs e)
        {
            System.Console.WriteLine("TransactionCompleted");
        }
    }
}
