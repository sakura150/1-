using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Reflection;

public class Program
{
    public class Heap<T> where T : IComparable<T>
    {

        private v.MyVector<T> heap;
        public void HeapCreate(T[] value)
        {
            heap = new v.MyVector<T>(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                heap.Add(value[i]);
            }
            for (int i = 0; i < value.Length; i++)
            {
                Heapify(i);
            }
        }

        public T ToArrayMax() { return heap.Get(heap.Size() - 1); }
        public T ToArrayMin() { return heap.Get(0); }
        public T ExtractMin()
        {
            if (heap.Size() == 0)
            {
                throw new InvalidOperationException("Куча пуста");
            }

            T min = heap.Get(0);
            Swap(0, heap.Size() - 1);
            heap.Remove(heap.Size() - 1);
            Heapify(0);
            return min;
        }
        public T ExtractMax()
        {
            if (heap.Size() == 0)
            {
                throw new InvalidOperationException("Куча пуста");
            }

            T max = heap.Get(heap.Size() - 1);
            heap.Remove(heap.Size() - 1);
            Heapify(heap.Size() - 1);
            return max;
        }

        public void AddKey(int index, T value)
        {
            if (value.CompareTo(heap.Get(index)) > 0)
            {
                throw new ArgumentException("Новое значение ключа должно быть больше текущего.");
            }
            heap.Set(index, value);
            while (index > 0 && heap.Get(Parent(index)).CompareTo(heap.Get(index)) > 0)
            {
                Swap(index, Parent(index));

                index = Parent(index);
            }
        }
        public void RemoveKey(int index, T value)
        {
            if (value.CompareTo(heap.Get(index)) < 0)
            {
                throw new ArgumentException("Новое значение ключа должно быть меньше текущего.");
            }


            heap.Set(index, value);
            while (index > 0 && heap.Get(Parent(index)).CompareTo(heap.Get(index)) < 0)
            {

                Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private static int Parent(int index)
        {
            return (index - 1) / 2;
        }
        public void AddValue(T value)
        {
            heap.Add(value);
            for (int i = 0; i < heap.Size(); i++) Heapify(i);
        }
        public void Sliyyanie(T[] heap2)
        {
            for (int i = 0; i < heap2.Length; i++)
            {
                heap.Add(heap2[i]);
                Heapify(i);
            }
        }
        private void Heapify(int index)
        {
            for (; ; )
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int minChildIndex = leftChildIndex;

                if (rightChildIndex < heap.Size() && heap.Get(rightChildIndex).CompareTo(heap.Get(leftChildIndex)) < 0)
                {
                    minChildIndex = rightChildIndex;
                }
                if (leftChildIndex < heap.Size() && heap.Get(leftChildIndex).CompareTo(heap.Get(rightChildIndex)) < 0)
                {
                    minChildIndex = leftChildIndex;
                }
                if (index == heap.Size()) { break; }
                Swap(index, minChildIndex);
            }
        }
        private void Swap(int index1, int index2)
        {
            T temp1 = heap.Get(index1);
            T temp2 = heap.Get(index2);
            heap.Set(index2, temp1);
            heap.Set(index1, temp2);
        }
        public void Print()
        {
            heap.Print();
        }

    }
    public static void Main(string[] args)
    {
        double[] array = { 1, 2, 4, 58, 15, -8 };
        Heap<double> list = new Heap<double>();
        list.HeapCreate(array);
        list.ToArrayMax();
        list.AddValue(26);
        list.Print();
    }
}
