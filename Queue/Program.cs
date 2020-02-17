using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            var q = new Queue<int>();
            timer.Start();
            foreach (var dig in Enumerable.Range(0, 10000000))
                q.Enqueue(dig);
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            timer = new Stopwatch();
            var nq = new CustomQueue<int>();
            timer.Start();
            foreach (var dig in Enumerable.Range(0, 10000000))
                nq.Put(dig);
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
