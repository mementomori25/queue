using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Queue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        public int Capacity { get; private set; }

        private int Head { get; set; }

        private int Tail { get; set; }

        private T[] _collection;

        public CustomQueue(int capacity = 4)
        {
            Capacity = capacity;
            _collection = new T[Capacity];
        }

        public void Put(T item)
        {
            _collection[Tail] = item;
            Count++;
            Tail++;
            if (Tail >= Capacity)
                IncreaseCapacity();
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");
            var payload = _collection[Head];
            _collection[Head] = default;
            Head++;
            Count--;
            return payload;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");
            return _collection[Head];
        }

        private void IncreaseCapacity()
        {
            Capacity <<= 1;
            var newCollection = new T[Capacity];
            Array.Copy(_collection, Head, newCollection, 0, Tail - Head);
            _collection = newCollection;
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
