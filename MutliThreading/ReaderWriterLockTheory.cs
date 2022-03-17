using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class ReaderWriterLockTheory
    {

        static object _lock = new object();
        static SpinLock _lock2 = new SpinLock();
        class Reward
        {

        }
        static ReaderWriterLockSlim _lock3 = new ReaderWriterLockSlim();

        static Reward GetRewardBird(int id)
        {
            _lock3.EnterReadLock();

            _lock3.ExitReadLock();
            lock(_lock)
            {

            }
            return null;
        }

        static void AddReward(Reward reward)
        {
            _lock3.EnterWriteLock();

            _lock3.ExitWriteLock();
        }
        static void Main(string[] args)
        {
            lock (_lock)
            {

            }
        }
    }
}
