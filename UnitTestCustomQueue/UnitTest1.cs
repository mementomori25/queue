using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queue;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UnitTestCustomQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QueueCountIncrease()
        {
            var q = new CustomQueue<int>();
            q.Put(1);
            Assert.AreEqual(1, q.Count);
        }

        [TestMethod]
        public void QueueCountDecrease()
        {
            var q = new CustomQueue<int>();
            q.Put(1);
            q.Put(2);
            q.Put(3);
            q.Pop();
            Assert.AreEqual(2, q.Count);
        }

        [TestMethod]
        public void CheckIncreaseCapacity()
        {
            var q = new CustomQueue<int>();
            for (var i = 0; i < 10; i++) q.Put(i);
            Assert.AreEqual(16, q.Capacity);
            Assert.AreEqual(10, q.Count);
            for (var i = 0; i < 10; i++) Assert.AreEqual(q.Pop(), i);
        }

        [TestMethod]
        public void PeekWorks()
        {
            var q = new CustomQueue<int>();
            q.Put(50);
            q.Peek();
            Assert.AreEqual(q.Count, 1);
            q.Peek();
            Assert.AreEqual(q.Count, 1);
        }

        [TestMethod]
        public void CheckContains()
        {
            var q = new CustomQueue<int>();
            q.Put(1);
            q.Put(2);
            Assert.AreEqual(q.Contains(1), true);
            Assert.AreEqual(q.Contains(5), false);
        }

        [TestMethod]
        public void SpeedTest()
        {
            const double order = 3d;
            var timer = new Stopwatch();
            var q = new Queue<int>();
            timer.Start();
            foreach (var dig in Enumerable.Range(0, 10000000))
                q.Enqueue(dig);
            timer.Stop();
            double first = timer.ElapsedMilliseconds;
            timer = new Stopwatch();
            var nq = new CustomQueue<int>();
            timer.Start();
            foreach (var dig in Enumerable.Range(0, 10000000))
                nq.Put(dig);
            timer.Stop();
            double second = timer.ElapsedMilliseconds;
            var res = second / first < order;
            Assert.IsTrue(res);
        }
    }
}