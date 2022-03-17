using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{    class Program
    {
        static void MainThread(object State)
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine("Hello Thread!");
        }

        static void Main(string[] args)
        {
            Task t = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning) ;
            t.Start();

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);
            ThreadPool.QueueUserWorkItem(MainThread);

            //Thread t = new Thread(MainThread);
            //t.IsBackground = true;
            //t.Name = "Test Thread";
            //t.Start();

            //Console.WriteLine("Waiting for Thread!");

            //t.Join();
            //Console.WriteLine("Hello World!");
            while(true)
            {

            }
        }
    }
}