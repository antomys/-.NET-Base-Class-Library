// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args)
    {
        var asyncAwait = new AsyncAwait();
        asyncAwait.AsyncAwaitExample();
    }
}
public class AsyncAwait
{
    public async Task AsyncAwaitExample()
    {
        int myVariable = 0;

        await DummyAsyncMethod();
        Debug.WriteLine("Continuation - After First Await");
        myVariable = 1;

        await DummyAsyncMethod();
        Debug.WriteLine("Continuation - After Second Await");
        myVariable = 2;

    }

    private async Task DummyAsyncMethod()
    {
        //Асинхронный вызов
    }

}

//  Decompiled code from this:
/*[CompilerGenerated]
    private sealed class <AsyncAwaitExample>d__0 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder <>t__builder;

        public AsyncAwait <>4__this;

        private int <myVariable>5__1;

        private TaskAwaiter <>u__1;

        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
                TaskAwaiter awaiter;
                TaskAwaiter awaiter2;
                if (num != 0)
                {
                    if (num == 1)
                    {
                        awaiter = <>u__1;
                        <>u__1 = default(TaskAwaiter);
                        num = (<>1__state = -1);
                        goto IL_00f2;
                    }
                    <myVariable>5__1 = 0;
                    awaiter2 = <>4__this.DummyAsyncMethod().GetAwaiter();
                    if (!awaiter2.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter2;
                        <AsyncAwaitExample>d__0 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter2 = <>u__1;
                    <>u__1 = default(TaskAwaiter);
                    num = (<>1__state = -1);
                }
                awaiter2.GetResult();
                Debug.WriteLine("Continuation - After First Await");
                <myVariable>5__1 = 1;
                awaiter = <>4__this.DummyAsyncMethod().GetAwaiter();
                if (!awaiter.IsCompleted)
                {
                    num = (<>1__state = 1);
                    <>u__1 = awaiter;
                    <AsyncAwaitExample>d__0 stateMachine = this;
                    <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                    return;
                }
                goto IL_00f2;
                IL_00f2:
                awaiter.GetResult();
                Debug.WriteLine("Continuation - After Second Await");
                <myVariable>5__1 = 2;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [CompilerGenerated]
    private sealed class <DummyAsyncMethod>d__1 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder <>t__builder;

        public AsyncAwait <>4__this;

        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [AsyncStateMachine(typeof(<AsyncAwaitExample>d__0))]
    [DebuggerStepThrough]
    public Task AsyncAwaitExample()
    {
        <AsyncAwaitExample>d__0 stateMachine = new <AsyncAwaitExample>d__0();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }

    [AsyncStateMachine(typeof(<DummyAsyncMethod>d__1))]
    [DebuggerStepThrough]
    private Task DummyAsyncMethod()
    {
        <DummyAsyncMethod>d__1 stateMachine = new <DummyAsyncMethod>d__1();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
    */