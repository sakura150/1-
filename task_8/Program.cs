using vector;

public class Programm
{
    public class MyStack<T> : vector.MyVector<T>
    {
        private vector.MyVector<T> stack;
        private int size;
        public MyStack()
        {
            stack = new vector.MyVector<T>();
            size = -1;
        }
        public void Push(T item)
        {
            stack.Add(item);
            size++;
        }
        public void Pop()
        {
            stack.Remove(size--);
            size--;
        }

        public T Peek()
        {
            return Get(size--);
        }
        public bool Empty()
        {
            if (size == -1) return true;
            else return false;
        }
        public int Search(T item)
        {
            int n = stack.IndexOf(item);
            if (n > 0) return n;
            else return -1;

        }
    }

    public class Example
    {
        public static void Main(string[] args)
        {

            MyStack<int> list = new MyStack<int>();
            for (int i = 0; i < 5; i++) list.Push(i);
            list.Pop();
            Console.WriteLine(list.Search(3));

        }
    }
}
