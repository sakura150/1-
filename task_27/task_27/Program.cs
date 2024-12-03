// задачи 8, 10,  18, 21,
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using task_27;

namespace task_27
{
    // 24 23 11 14
    public interface MyIterator1<T>
    {
        bool HasNext();
        T Next();
        void Remove();
    }
    // 4 6 16
    public interface MyIterator2<T>
    {
        bool HasNext();
        T Next();
        bool HasPrevious();
        T Previous();
        int NextIndex();
        int PreviousIndex();
        void Remove();
        void Set(T element);
        void Add(T element);
    }
    public class MyItr1<T> : MyIterator1<T>
    {
        private MyPriorityQueue<T> queue;
        /*
        private MyHashSet<T> set;
        private MyTreeSet<T> tree;*/
        private T cursor;
        private IEnumerator<T> enumerator;
        public MyItr1(MyPriorityQueue<T> queue)
        {
            queue = queue;
            enumerator = queue.GetEnumerator();
        }

        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            queue.Remove(cursor);
        }
    }
    //array
    public class MyItr2<T> : MyIterator1<T>
    {
        private MyArrayDeque<T> deque;
        private IEnumerator<T> enumerator;
        private T cursor;
        public MyItr2(MyArrayDeque<T> deque)
        {
            deque = deque;
            enumerator = deque.GetEnumerator();
        }

        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            deque.Remove(cursor);
        }
    }
    // set
    public class MyItr3<T> : MyIterator1<T>
    {
        private MyHashSet<T> set;
        private IEnumerator<T> enumerator;
        private T cursor;
        public MyItr3(MyHashSet<T> kk)
        {
            set = kk;
            enumerator = set.GetEnumerator();
        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            set.Remove(cursor);
        }
    }
    //tree
   public class MyItr4<T> : MyIterator1<T>
    {
        private MyTreeSet<T> root;
        private IEnumerator<T> enumerator;
        private T cursor;
        public MyItr4(MyTreeSet<T> kk)
        {
            root = kk;
            enumerator = root.GetEnumerator();  
        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            root.Remove(cursor);
        }
    }
    
    public class MyItr5<T> : MyIterator2<T>
    {
        private MyArrayList<T> array;
        private IEnumerator<T> enumerator;
        private T cursor;
        private int index; // для переммещения назад
        public MyItr5(MyArrayList<T> list)
        {
            array = list;
            enumerator = list.GetEnumerator();

        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }
        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }
        public bool HasPrevious()
        {
            return index > 0;
            
        }
        public T Previous()
        {
            T element = array.Get(index--); return element;
        }
        public int NextIndex()
        {
            int i = array.IndexOf(cursor);
            if (i < array.Size() && i >=0) return i++;
            else return -1;
        }
        public int PreviousIndex()
        {
            int i = array.IndexOf(cursor);
            if (i < array.Size() && i>=0) return i--;
            else return -1;
        }
        public void Remove()
        {
            array.Remove(cursor);
        }
        public void Set(T element)
        {
            int i = array.IndexOf(element);
            array.Set(i, element);
        }
        public void Add(T element)
        {
            array.Add(element);
        }
    }
    //vector
    public class MyItr6<T> : MyIterator2<T>
    {

        private MyVector<T> vector;
        private IEnumerator<T> enumerator;
        private T cursor;
        private int index; // для переммещения назад
        public MyItr6(MyVector<T> list)
        {
            vector = list;
            enumerator = list.GetEnumerator();

        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }
        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }
        public bool HasPrevious()
        {
            return index > 0;

        }
        public T Previous()
        {
            T element = vector.Get(index--); return element;
        }
        public int NextIndex()
        {
            int i = vector.IndexOf(cursor);
            if (i < vector.Size() && i >= 0) return i++;
            else return -1;
        }
        public int PreviousIndex()
        {
            int i = vector.IndexOf(cursor);
            if (i < vector.Size() && i >= 0) return i--;
            else return -1;
        }
        public void Remove()
        {
            vector.Remove(cursor);
        }
        public void Set(T element)
        {
            int i = vector.IndexOf(element);
            vector.Set(i, element);
        }
        public void Add(T element)
        {
            vector.Add(element);
        }

    }
    //list
    public class MyItr7<T> : MyIterator2<T>
    {
        private MyLInkedList<T> list;
        private IEnumerator<T> enumerator;
        private T cursor;
        private int index; // для перемещения назад
        public MyItr7(MyLInkedList<T> list1)
        {
            list = list1;
            enumerator = list1.GetEnumerator();

        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }
        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }
        public bool HasPrevious()
        {
            return index > 0;

        }
        public T Previous()
        {
            T element = list.Get(index--); return element;
        }
        public int NextIndex()
        {
            int i = list.IndexOf(cursor);
            if (i < list.Size() && i >= 0) return i++;
            else return -1;
        }
        public int PreviousIndex()
        {
            int i = list.IndexOf(cursor);
            if (i < list.Size() && i >= 0) return i--;
            else return -1;
        }
        public void Remove()
        {
            list.Remove(cursor);
        }
        public void Set(T element)
        {
            int i = list.IndexOf(element);
            list.Set(i, element);
        }
        public void Add(T element)
        {
            list.Add(element);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4};
            MyArrayList<int> list = new MyArrayList<int>(arr);

            list.Add(7);
            MyItr5<int> iterator1 = new MyItr5<int>(list);

            while (iterator1.HasNext())
            {
                int element = iterator1.Next();
                Console.WriteLine(element);
            }
        }
    }
}
