using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WFConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            //Sequence sequence=new Sequence();
            //WriteLine wl = new WriteLine() { Text = new InArgument<string>("a") };
            //WriteLine w2 = new WriteLine() { Text = new InArgument<string>("b") };
            //WriteLine w3 = new WriteLine() { Text = new InArgument<string>("c") };
            //sequence.Activities.Add(wl);
            //sequence.Activities.Add(w2);
            //sequence.Activities.Add(w3);
            //WorkflowInvoker.Invoke(sequence);
            //Console.WriteLine("请输入第一个数");
            //System.Collections.Generic.Dictionary<string, object> dic = new System.Collections.Generic.Dictionary<string, object>();
            //dic.Add("myValue", Console.ReadLine());
          
            //WorkflowApplication myInstance = new WorkflowApplication(new Pick(), dic);
            //myInstance.Completed = completed;
            //WorkflowApplication myInstance = new WorkflowApplication(new Transaction());
            //myInstance.Aborted = aborted;
            //myInstance.OnUnhandledException = unhandledException_Abort;
            //myInstance.Completed = completed;
           
            //myInstance.Run();

            WorkflowApplication instance = new WorkflowApplication(new CompensableActivity());



            instance.Completed = new Action<WorkflowApplicationCompletedEventArgs>(completed);
            instance.OnUnhandledException = unhandledExceptionl;
            instance.Aborted = aborted;
            instance.Run();
            
            Console.ReadLine();
            //Activity workflow1 = new Workflow1();
            //WorkflowInvoker.Invoke(workflow1);
        }
        static void completed(WorkflowApplicationCompletedEventArgs e)
        {
            System.Console.WriteLine("完成,实例编号:{0},状态:{1}", e.InstanceId, e.CompletionState.ToString());
            System.Console.WriteLine("Message:{0}", e.TerminationException.Message);
            //System.Console.WriteLine(e.Outputs["myOut"].ToString());
            //System.Console.WriteLine(e.Outputs["test"].ToString());
        }
        static UnhandledExceptionAction unhandledExceptionl(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            System.Console.WriteLine("unhandledException:{0}", e.UnhandledException.Message);

            return UnhandledExceptionAction.Cancel;
        }
        static UnhandledExceptionAction unhandledException_Abort(WorkflowApplicationUnhandledExceptionEventArgs e)
        {

            System.Console.WriteLine("unhandledException_Abort:{0}", e.UnhandledException.Message);

            return UnhandledExceptionAction.Cancel;

        }
        static void aborted(WorkflowApplicationAbortedEventArgs e)
        {
            System.Console.WriteLine("aborted ,实例编号:{1},Reason:{0}", e.Reason.Message, e.InstanceId);
        }
    }
}
