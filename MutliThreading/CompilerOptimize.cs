﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{    class Program
    {
        volatile static bool _stop = false;
        static void ThreadMain()
        {
            Console.WriteLine("쓰레드 시작");

            while (_stop == false)
            {

            }

            Console.WriteLine("쓰레드 종료!");
        }

        static void Main(string[] args)
        {
            Task t = new Task();
            t.Start();

            Thread.Sleep(1000);

            _stop = true;

            Console.WriteLine("쓰레드 종료");
            Console.WriteLine("종료 대기중");

            t.Wait();

            Console.WriteLine("종료 성공");
        }
    }
}