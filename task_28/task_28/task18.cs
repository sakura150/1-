using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_28
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
            table = new Node[16];
            size = 16;
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
            K[] t = new K[size];
            for (int i = 0; i < size; i++)
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
            int index = GetHashCode(key);
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
}
