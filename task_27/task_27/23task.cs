
namespace task_27
{
    
    public class MyHashSet<T> // where T : IComparable<T>
    {
        private MyHashMap<T, object> map;
        public MyHashSet()
        {
            map = new MyHashMap<T, object>();
        }
        public MyHashSet(T[] a)
        {
            int len = a.Length;

            map = new MyHashMap<T, object>(len);

            for (int i = 0; i < len; i++)
            {
                map.Put(a[i], false);
            }
        }
        public MyHashSet(int initialCapacity, float loadFactor)
        {
            map = new MyHashMap<T, object>(initialCapacity, loadFactor);
        }
        public MyHashSet(int initialCapacity)
        {
            map = new MyHashMap<T, object>(initialCapacity);
        }
        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = ToArray();
            foreach (T i in arr)
            {
                yield return i;
            }
        }

        public void Add(T e)
        {
            map.Put(e, false);
        }
        public void AddAll(T[] a)
        {
            foreach (T t in a) map.Put(t, false);
        }
        public void Clear() => map.Clear();
        public bool Contains(object e)
        {
            T el = (T)e;
            if (map.ContainsKey(el)) return true;
            else return false;
        }
        public bool ContainsAll(T[] a)
        {
            foreach (T t in a)
            {
                if (map.ContainsKey(t)) return true;
            }
            return false;
        }
        public bool IsEmpty()
        {
            if (map.IsEmpty()) return true;
            else return false;
        }
        public void Remove(object o)
        {
            T e = (T)o;
            map.Remove(e);
        }
        public void RemoveAll(T[] a)
        {
            foreach (T t in a)
            {
                map.Remove(t);
            }
        }
        public int Size()
        {
            return map.Size();
        }
        public T[] ToArray()
        {
            return map.KeySet();
        }
        public T[] ToArray(T[] a)
        {
            T[] arr = map.KeySet();
            T[] array = new T[a.Length + map.Size()];
            if (a == null) return map.KeySet();
            else
            {

                for (int i = 0; i < a.Length; i++) array[i] = a[i];
                int index = 0;
                for (int i = a.Length; i < array.Length; i++) { array[i] = arr[index]; index++; }
            }
            return array;
        }
        /*public T First()
        {

            T[] arr = map.KeySet();
            T min = arr[0];
            foreach (T t in arr)
            {
                if (min.CompareTo(t) > 0) min = t;
            }
            return min;
        }*/
        /*public T Last()
        {
            T[] arr = map.KeySet();
            T max = arr[0];
            foreach (T t in arr)
            {
                if (max.CompareTo(t) < 0) max = t;
            }
            return max;
        }
        public void SubSet(T fromElement, T toElement)
        {
            MyHashSet<T> set = new MyHashSet<T>();
            T[] array = map.KeySet();
            foreach (T t in array)
            {
                if (t.CompareTo(fromElement) < 0 && t.CompareTo(toElement) > 0) set.Add(t);
            }
        }*/
       /* public void HeadbSet(T toElement)
        {
            MyHashSet<T> set = new MyHashSet<T>();
            T[] array = map.KeySet();
            foreach (T t in array)
            {
                if (t.CompareTo(toElement) > 0) set.Add(t);
            }
        }
        public void TailSet(T fromElement)
        {
            MyHashSet<T> set = new MyHashSet<T>();
            T[] array = map.KeySet();
            foreach (T t in array)
            {
                if (t.CompareTo(fromElement) < 0) set.Add(t);
            }
        }*/
    }
}
