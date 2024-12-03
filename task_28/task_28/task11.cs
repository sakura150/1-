using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_28
{
    public class PriorityQueueCompare : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            // Преобразуем объекты к типу int
            int num1 = (int)x;
            int num2 = (int)y;

            // Сравниваем числа
            if (num1 < num2)
                return -1;
            else if (num1 == num2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }


    public class MyPriorityQueue<T>
    {
        private T[] queue;
        private int size;
        private PriorityQueueCompare comparator;

        public MyPriorityQueue()
        {
            queue = null;
            size = 11;
        }
        public MyPriorityQueue(T[] a)
        {
            queue = new T[a.Length];
            for (int i = 0; i < a.Length;)
            {
                queue[i] = a[i];
            }
            size = a.Length;
        }
        public MyPriorityQueue(int initialCapacity)
        {
            queue = null;
            size = initialCapacity;
        }
        public MyPriorityQueue(int initialCapacity, PriorityQueueCompare comparator)
        {
            queue = null;
            size = initialCapacity;
            this.comparator = comparator;
        }
        public MyPriorityQueue(MyPriorityQueue<T> c)
        {
            queue = new T[c.size];
            size = c.size;
            for (int i = 0; i < size; i++) { Add(c.Peek()); }
        }

        private void Heapify(int index, PriorityQueueCompare comparator)
        {
            while (true)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int minChildIndex = leftChildIndex;
                comparator = new PriorityQueueCompare();
                int result = comparator.Compare(queue[rightChildIndex], queue[leftChildIndex]);
                if (rightChildIndex < size && result == 1)
                {

                    minChildIndex = rightChildIndex;
                }

                if (leftChildIndex < size && result == -1)
                {

                    minChildIndex = leftChildIndex;
                }
                if (index == size)
                {
                    break;
                }

                int resultt = comparator.Compare(queue[minChildIndex], (queue[index]));
                if (resultt == -1)
                {
                    Swap(index, minChildIndex);
                    index = minChildIndex;
                }
                else
                {
                    break;
                }
            }
        }
        private void Swap(int index1, int index2)
        {
            T temp1 = queue[index1];
            queue[index1] = queue[index2];
            queue[index2] = temp1;
        }

        public void Add(T e)
        {
            if (size < 64)
            {
                T[] array = new T[(size * 2) + 1];
                for (int i = 0; i < array.Length; i++) array[i] = queue[i]; ;

                size = array.Length;
                queue[size - 1] = e;
                Heapify(size - 1, comparator);
            }
            else
            {
                T[] array = new T[(int)(size * 1.5) + 1];
                for (int i = 0; i < array.Length; i++) array[i] = queue[i];
                size = array.Length;
                queue[size - 1] = e;
                Heapify(size - 1, comparator);
            }
        }
        public void AddAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++) Add(a[i]);
        }

        public void Clear() => size = 0;
        public bool Contains(object o)
        {
            bool k = false;
            for (int i = 0; i < size; i++)
            {
                foreach (T t in queue)
                {
                    if (Equals(t, o)) k = true;
                }
            }
            return k;
        }
        public bool ContainsAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (Contains(a[i])) return true;
            }
            return false;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        private int FindIndex(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (o.Equals(queue[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Remove(object o)
        {
            if (Contains(o))
            {
                int k = FindIndex(o);
                T[] array = new T[size--];
                for (int i = 0; i < k; i++) array[i] = queue[i];
                for (int i = k + 1; i < size--; i++) array[i] = queue[i];
                queue = array;
                size--;
                Heapify(size -= 2, comparator);
            }

        }
        public void RemoveAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Remove(a[i]);
            }

        }
        public void RetainAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++) queue[i] = a[i];
            size = a.Length;
        }
        public int Size()
        {
            return size;
        }
        public void ToArray()
        {
            T[] array = new T[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = queue[i];
            }
        }
        public void ToArray(T[] a)
        {
            for (int i = 0; i < size; i++)
            {
                Add(a[i]);
            }
            size += a.Length;
            T[] array = new T[size];
            for (int i = 0; i < array.Length; i++) array[i] = queue[i];
        }
        public T Element()
        {
            return queue[0];
        }
        public bool Offer(T obj)
        {
            Add(obj);
            if (Contains(obj)) return true;
            else return false;
        }
        public T Peek()
        {
            if (size == 0) return default(T);
            else return queue[0];
        }
        public T Poll()
        {
            if (size == 0) return default(T);
            else
            {
                T q = queue[0];
                Remove(queue[0]);
                return q;
            }
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string s = "";
            foreach (T t in queue)
            {
                s += t + " ";
            }
            return s;
        }

    }
}
