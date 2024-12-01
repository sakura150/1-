using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_25
{
    public class MyHashMap<K, V>
    {
        private class Node
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node Next { get; set; }

            public Node(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }

        /*private V t;
        private K r*/
        private Node[] table;
        private int size;
        private double loadFactor;
        public MyHashMap()
        {
            table = new Node[4];
            size = 4;
            loadFactor = 0.75;
        }
        public MyHashMap(int initialCapacity)
        {
            table = new Node[initialCapacity];
            size = initialCapacity;
            loadFactor = 0.75;
        }
        public MyHashMap(int initialCapacity, double loadFactorr)
        {
            table = new Node[initialCapacity];
            size = initialCapacity;
            loadFactor = loadFactorr;
        }
        private int GetHashCode(K key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }
        private int GetHashCode(V key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }
        public void Clear() { size = 0; }
        public bool ContainsKey(K key)
        {
            int index = GetHashCode(key);
            Node current = table[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public bool ContainsValue(V value)
        {
            int index = GetHashCode(value);
            Node current = table[index];
            while (current != null)
            {
                if (current.Key.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerable<KeyValuePair<K, V>> EntrySet()
        {
            for (int i = 0; i < size - 5; i++)
            {
                Node current = table[i];
                while (current != null)
                {
                    yield return new KeyValuePair<K, V>(current.Key, current.Value);
                    current = current.Next;
                }
            }
        }
        public V Get(K key)
        {
            int index = GetHashCode(key);
            Node current = table[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current.Value;
                }
                current = current.Next;
            }

            throw new KeyNotFoundException("Ключ не найден.");
        }
        public bool IsEmpty() { return size == 0; }
        public K[] KeySet()
        {
            K[] t = new K[table.Length];
            for (int i = 0; i < table.Length; i++)
            {
                Node current = table[i];
                while (current != null)
                {
                    t[i] = current.Key;
                    current = current.Next;
                }
            }
            return t;
        }
        public void Put(K key, V value)
        {
            /*int index = GetHashCode(key);
            int k = -1;
            if (table[index] != null)
            {
                while (table != null)
                {
                    if (k == index) k = index;

                }
                if (k == -1)
                {
                    Node newNode = new Node(key, value);
                    newNode.Next = table[index];
                    table[index] = newNode;
                }
            }
            else
            {
                table[index] = new Node(key, value);
            }

            size++;*/
            int index = Math.Abs(key.GetHashCode()) % table.Length;

            Node current = table[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    current.Value = value; // Обновляем значение, если ключ уже существует
                    return;
                }
                current = current.Next;
            }

            Node newNode = new Node(key, value);
            newNode.Next = table[index];
            table[index] = newNode;
            size++;
        }
        public void Remove(K key)
        {
            int index = GetHashCode(key);

            // Если в индексе нет значения, ничего не делаем
            if (table[index] == null)
            {
                return;
            }

            // Если удаляемый ключ - первый в списке
            if (table[index].Key.Equals(key))
            {
                table[index] = table[index].Next;
                size--;
                return;
            }

            // Ищем ключ в списке
            Node current = table[index];
            Node previous = null;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    previous.Next = current.Next;
                    size--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }
        public int Size() { return size; }
    }
    public class MyHashSet<T> where T : IComparable
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
        public T First()
        {

            T[] arr = map.KeySet();
            T min = arr[0];
            foreach (T t in arr)
            {
                if (min.CompareTo(t) > 0) min = t;
            }
            return min;
        }
        public T Last()
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
        }
        public void HeadbSet(T toElement)
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
        }
    }
}
