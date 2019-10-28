using Rainnier.Algorithm.ThreadSync.InterlockedDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.ThreadSync
{
    class Program
    {
        static public int tickCount = 10;
        volatile static bool s_stopWorker = false;
        static public object q = new object();
        public static void SellTicket()
        {
            lock (q)
            {
                while (tickCount > 0)
                { 
                
                    tickCount--;
                    Thread.Sleep(2000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} sold 1 ticket.left {tickCount}");
                }
            }
        }

        static void Worker(object o)
        {
            int x = 0;
            while (!s_stopWorker)
            {
                x++;
                
            }

            Console.WriteLine($"Worker: stopped when x = {x}");
        }
        static void Main(string[] args)
        {
            InterlockedDemoMethod();
            //var threadSharingdata = new ThreadSharingData();
            //var t1 = new Thread(new ThreadStart(threadSharingdata.Thread1));
            //t1.Name = "Window1";
            //var t2 = new Thread(new ThreadStart(threadSharingdata.Thread2));
            //t2.Name = "Window2";


            //t1.Start();
            //t2.Start();


        }

        static void ThreadSharingDataDemo()
        {
            Console.WriteLine("Main: letting work run for 5 seconds");
            var t = new Thread(Worker);
            t.Start();
            Thread.Sleep(5000);
            s_stopWorker = true;
            Console.WriteLine("Main: waitting fro work to stop");
            t.Join();
            Console.ReadKey();
        }

        static void InterlockedDemoMethod()
        {
            var a = new MultiWebRequest();
            Console.ReadKey();
        }
    }
}
