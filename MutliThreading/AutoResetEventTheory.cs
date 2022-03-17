using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Lock
    {
        AutoResetEvent _available = new AutoResetEvent(true);
        //ManualResetEvent 방법은 수동으로 close상태를 만드는 것이라, reset()을 시켜주어야 한다. but waitone()과 reset()이 automic 하지 않으므로 별로다.
        //Mutex 방법도 있는데, 정보(lock을 몇개 잠궜는지, lock을 한 쓰레드를 ThreadId로 기억하여 올바른 쓰레드가 자신을 릴리즈하려하는지 등)를 많이 가지고 있으므로 느리다.
        public void Acquire()
        {
            _available.WaitOne(); // 입장시도
            //_available.Reset(); // false로 바꿔주는데, WaitOne()에는 이미 이 기능이 포함되어있다
        }

        public void Release()
        {
            _available.Set();
        }
    }
    class AutoResetEventTheory
    {
        static int _num = 0;
        static Lock _lock = new Lock();

        static void Thread_1()
        {
            for (int i = 0; i < 10000; i++)
            {
                _lock.Acquire();
                _num++;
                _lock.Release();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 10000; i++)
            {
                _lock.Acquire();
                _num--;
                _lock.Release();
            }
        }
        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(_num);
        }
    }
}
