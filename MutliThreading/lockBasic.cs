﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class lockBasic
    {
        static int number = 0;
        static object _obj = new object();

        static void Thread_1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                try
                {
                    Monitor.Enter(_obj);
                    number++;
                }
                finally
                {
                    Monitor.Exit(_obj);
                }

                //lock(_obj)
                //{
                //    number++;
                //}
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                try
                {
                    Monitor.Enter(_obj);
                    number--;
                }
                finally
                {
                    Monitor.Exit(_obj);
                }

                //lock(_obj)
                //{
                //    number--;
                //}
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}
