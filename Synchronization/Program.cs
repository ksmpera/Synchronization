using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    class Program
    {

        static CountdownEvent countDown;

        static void Main(string[] args)
        {
            int count = 0;

            List<Thread> threads = new List<Thread>();

            for (int i = 1; i < 11; i++)
            {
                if (i % 2 != 0)
                {
                    count++;
                }
                Thread thread = new Thread(WorkMethod);
                thread.Name = "Thread_" + i;

                threads.Add(thread);

            }

            countDown = new CountdownEvent(count);

            foreach (Thread th in threads)
            {
                th.Start();
            }


            Console.ReadKey();
        }

        public static void WorkMethod()
        {
            int num = int.Parse(Thread.CurrentThread.Name.Substring(7));
            if (num % 2 == 0)
            {

                countDown.Wait();
                Thread.Sleep(2000);
                Console.WriteLine(Thread.CurrentThread.Name + " Has finished (EVEN)");

            }
            else
            {
                Thread.Sleep(2000);
                Console.WriteLine(Thread.CurrentThread.Name + " Has finished (ODD)");
                countDown.Signal();
            }

        }
    }
}

