using System.Collections.Generic;

namespace task_28
{
    public class Program
    {
        public interface MyCollection<T>
        {
            void Add(T e);
            void AddAll(T[] a);
            void Clear();
            bool Contains(object o);
            bool ContainsAll(T[] a);
            bool IsEmpty();
            void Remove(object o);
            void RemoveAll(T[] a);
            void RetainAll(T[] a);
            int Size();
            void ToArray();
            void ToArray(T[] a);
        }
        public interface MyList<T> : MyCollection<T>
        {
            void Add(int index, T e);
            void AddAll(int index, T[] a);
            T Get(int index);
            int InddexOf(object o);
            int LastIndex(object o);
            void ListIterator();
            void ListIterator(int index);
            void Remove(int index);
            void Set(int index, T e);
            void SubList(int fromIndex, int toIndex);
        }
        public interface MyQueue<T> : MyCollection<T>
        {
            T Element();
            bool Offer(T obj);
            T Peek();
            T Poll();
        }
        public interface MyDeque<T> : MyCollection<T>
        {
            void AddFirst(T obj);
            void AddLast(T obj);
            T GetFirst();
            T GetLast();
            bool OfferFirst(T obj);
            bool OfferLast(T obj);
            T Pop();
            void Push(T obj);
            T PeekFirst();
            T PeekLast();
            T PollFirst();
            T PollLast();
            T RemmoveLast();
            T RemoveFirst();
            bool RemoveLastOccurrence(object obj);
            bool RemoveFirstOccurrence(object obj);
        }
        public interface MySet<T> : MyCollection<T>
        {
            T First();
            T Last();
            void SubSet(T FromElement, T ToElement);
            void HeadSet(T toElement);
            void TailSet(T fromElement);
        }
        /*public interface MySortedSet<T> : MySet<T>
        {
            T First();
            T Last();
            void SubSet(T FromElement, T ToElement);
            void HeadSet(T toElement);
            void TailSet(T fromElement);
        }*/
        public interface MyNavigableSet<T> : MySet<T>
        {
            void LowerEntry(T key);
            void FloorEntry(T key);
            void HigherEntry(T key);
            void CeilingEntry(T key);
            void LowerKey(T key);
            void FloorKey(T key);
            void HigherKey(T key);
            void CeilingKey(T key);
            void PollFirstEntry();
            void PollLastEntry();
            void FirstEntry();
            void LastEntry();

        }
        public interface MyMap<K, V>
        {
            void Clear();
            bool ContainsKey(object key);
            bool ContainsValue(object value);
            IEnumerable<KeyValuePair<K, V>> EntrySet();
            V Get(object key);
            bool IsEmpty();
            void KeySet();
            void Put(K key, V value);
            void PutAll(MyMap<K, V> m);
            void Remove(object key);
            int Size();
            MyCollection<V> Values();
        }
        public interface MySortedMap<K, V>
        {
            void FirstKey();
            void LastKey();
            void HeadMap(K end);
            void SubMap(K start, K end);
            void TailMap(K start);
        }
        public interface MyNavigableMap<K, V> : MySortedMap<K, V>
        {
            void LowerEntry(K key);
            void FloorEntry(K key);
            void HigherEntry(K key);
            void CeilingEntry(K key);
            void LowerKey(K key);
            void FloorKey(K key);
            void HigherKey(K key);
            void CeilingKey(K key);
            void PollFirstEntry();
            void PollLastEntry();
            void FirstEntry();
            void LastEntry();
        }
        public class MyArrayList<T> : MyList<T>
        {
            private MyArrayList<T> list;
            public MyArrayList(MyArrayList<T> listt)
            {
                list = listt;
            }
            public MyArrayList(T[] a) { list = new MyArrayList<T>(a); }
            public void Add(T e) { list.Add(e); }
            public void AddAll(T[] a) { list.AddAll(a); }
            public void Clear() { list.Clear(); }
            public bool Contains(object o) { return list.Contains(o); }
            public bool ContainsAll(T[] a) {  return  list.ContainsAll(a); }
            public bool IsEmpty() {  return  list.IsEmpty(); }
            public void Remove(object o) {  list.Remove(o); }
            public void RemoveAll(T[] a) { list.RemoveAll(a); }
            public void RetainAll(T[] a) { list.list.RetainAll(a); }
            public int Size() { return list.Size(); }
            public void ToArray() {  list.ToArray(); }
            public void ToArray(T[] a) { list.ToArray(a); }
            public void Add(int index, T e) { list.Add(index, e); }
            public void AddAll(int index, T[] a) { list.AddAll(index, a); }
            public T Get(int index) { return list.Get(index); }
            public int InddexOf(object o) { return list.InddexOf(o); }
            public int LastIndex(object o) { return list.LastIndex(o); }
            public void ListIterator() {  list.ListIterator(); }
            public void ListIterator(int index) {  list.ListIterator(index); }
            public void Remove(int index) { list.Remove(index); }
            public void Set(int index, T e) {  list.Set(index, e); }
            public void SubList(int fromIndex, int toIndex) {  list.SubList(fromIndex, toIndex); }
        }
        public class MyVector<T> : MyList<T>
        {
            private MyVector<T> vector;
            public MyVector(MyVector<T> v)
            {
                vector = v;
            }
            public MyVector(T[] a) { vector = new MyVector<T>(a); }
            public void Add(T e) { vector.Add(e); }
            public void AddAll(T[] a) { vector.AddAll(a); }
            public void Clear() {  vector.Clear(); }
            public bool Contains(object o) { return vector.Contains(o); }
            public bool ContainsAll(T[] a) {  return vector.ContainsAll(a); }
            public bool IsEmpty() {  return vector.IsEmpty(); }
            public void Remove(object o) {  vector.Remove(o); }
            public void RemoveAll(T[] a) { vector.RemoveAll(a); }
            public void RetainAll(T[] a) { vector.RetainAll(a); }
            public int Size() {  return vector.Size(); }
            public void ToArray() {  vector.ToArray(); }
            public void ToArray(T[] a) { vector.ToArray(a); }
            public void Add(int index, T e) {  vector.Add(index, e); }
            public void AddAll(int index, T[] a) { vector.AddAll(index, a); }
            public T Get(int index) { return vector.Get(index); }
            public int InddexOf(object o) { return vector.InddexOf(o); }
            public int LastIndex(object o) { return vector.LastIndex(o); }
            public void ListIterator() {  vector.ListIterator(); }
            public void ListIterator(int index) {  vector.ListIterator(index); }
            public void Remove(int index) { vector.Remove(index); }
            public void Set(int index, T e) { vector.Set(index, e); }
            public void SubList(int fromIndex, int toIndex) {  vector.SubList(fromIndex, toIndex); }
        }
        public class MyLInkedList<T> : MyList<T>
        {
            private MyLInkedList<T> list;
            public MyLInkedList(MyLInkedList<T> listt)
            {
                list = listt;
            }
            public MyLInkedList(T[] a) { list = new MyLInkedList<T> (a); }
            public void Add(T e) { list.Add(e); }
            public void AddAll(T[] a) { list.AddAll(a); }
            public void Clear() { list.Clear(); }
            public bool Contains(object o) { return list.Contains(o); }
            public bool ContainsAll(T[] a) { return list.ContainsAll(a); }
            public bool IsEmpty() { return list.IsEmpty(); }
            public void Remove(object o) { list.Remove(o); }
            public void RemoveAll(T[] a) { list.RemoveAll(a); }
            public void RetainAll(T[] a) { list.RetainAll(a); }
            public int Size() { return list.Size(); }
            public void ToArray() { list.ToArray(); }
            public void ToArray(T[] a) { list.ToArray(a); }
            public void Add(int index, T e) { list.Add(index, e); }
            public void AddAll(int index, T[] a) { list.AddAll(index, a); }
            public T Get(int index) { return list.Get(index); }
            public int InddexOf(object o) { return list.InddexOf(o); }
            public int LastIndex(object o) { return list.LastIndex(o); }
            public void ListIterator() { list.ListIterator(); }
            public void ListIterator(int index) { list.ListIterator(index); }
            public void Remove(int index) { list.Remove(index); }
            public void Set(int index, T e) { list.Set(index, e); }
            public void SubList(int fromIndex, int toIndex) { list.SubList(fromIndex, toIndex); }
        }
        public class MyPriorityQueue<T>: MyQueue<T> {
            private MyPriorityQueue<T> queue;
            public MyPriorityQueue(MyPriorityQueue<T> q)
            {
                queue = q;
            }
            public MyPriorityQueue(T[] a) { queue = new MyPriorityQueue<T>(a); }
            public void Add(T e) { queue.Add(e); }
            public void AddAll(T[] a) {  queue.AddAll(a); }
            public void Clear() {  queue.Clear(); }
            public bool Contains(object o) { return queue.Contains(o); }
            public bool ContainsAll(T[] a) {  return queue.ContainsAll(a); }
            public bool IsEmpty() {  return queue.IsEmpty(); }
            public void Remove(object o) {  queue.Remove(o); }
            public void RemoveAll(T[] a) { queue.RemoveAll(a); }
            public void RetainAll(T[] a) { queue.RetainAll(a); }
            public int Size() {  return queue.Size(); }
            public void ToArray() {  queue.ToArray(); }
            public void ToArray(T[] a) { queue.ToArray(a); }
            public T Element() {  return queue.Element(); }
            public bool Offer(T obj) { return  queue.Offer(obj); }
            public T Peek() { return  queue.Peek(); }
            public T Poll() { return queue.Poll(); }
        }
        public class MyArrayDeque<T> : MyDeque<T>
        {
            private MyArrayDeque<T> list;
            public MyArrayDeque(MyArrayDeque<T> listt)
            {
                list = listt;
            }
            public MyArrayDeque(T[] a) { list = new MyArrayDeque<T> (a); }
            public void Add(T e) { list.Add(e); }
            public void AddAll(T[] a) { list.AddAll(a); }
            public void Clear() { list.Clear(); }
            public bool Contains(object o) { return list.Contains(o); }
            public bool ContainsAll(T[] a) { return list.ContainsAll(a); }
            public bool IsEmpty() { return list.IsEmpty(); }
            public void Remove(object o) { list.Remove(o); }
            public void RemoveAll(T[] a) { list.RemoveAll(a); }
            public void RetainAll(T[] a) { list.list.RetainAll(a); }
            public int Size() { return list.Size(); }
            public void ToArray() { list.ToArray(); }
            public void ToArray(T[] a) { list.ToArray(a); }
            public void AddFirst(T obj) {  list.AddFirst(obj); }
            public void AddLast(T obj) { list.AddLast(obj); }
            public T GetFirst() {  return list.GetFirst(); }
            public T GetLast() {  return list.GetLast(); }
            public bool OfferFirst(T obj) {  return list.OfferFirst(obj); }
            public bool OfferLast(T obj) { return list.OfferLast(obj); }
            public T Pop() {  return list.Pop(); }
            public void Push(T obj) { list.Push(obj); }
            public T PeekFirst() {  return list.PeekFirst(); }
            public T PeekLast() {  return list.PeekLast(); }
            public T PollFirst() {  return list.PollFirst(); }
            public T PollLast() {  return list.PollLast(); }
            public T RemmoveLast() {  return list.RemmoveLast(); }
            public T RemoveFirst() {  return list.RemoveFirst(); }
            public bool RemoveLastOccurrence(object obj) {  return list.RemoveLastOccurrence(obj); }
            public bool RemoveFirstOccurrence(object obj) { return  list.RemoveFirstOccurrence(obj);}
        }
        public class MyHashSet<T> : MySet<T>
        {
            private MyHashSet<T> set;
            public MyHashSet(MyHashSet<T> sett)
            {
                set = sett;
            }
            public MyHashSet(T[] a) { set = new MyHashSet<T>(a); }
            public void Add(T e) { set.Add(e); }
            public void AddAll(T[] a) { set.AddAll(a); }
            public void Clear() { set.Clear(); }
            public bool Contains(object o) { return set.Contains(o); }
            public bool ContainsAll(T[] a) { return set.ContainsAll(a); }
            public bool IsEmpty() { return set.IsEmpty(); }
            public void Remove(object o) { set.Remove(o); }
            public void RemoveAll(T[] a) { set.RemoveAll(a); }
            public void RetainAll(T[] a) { set.RetainAll(a); }
            public int Size() { return set.Size(); }
            public void ToArray() { set.ToArray(); }
            public void ToArray(T[] a) { set.ToArray(a); }
            public T First() {return set.First(); }
            public T Last() { return  set.Last(); }
            public void SubSet(T FromElement, T ToElement) { set.SubSet(FromElement, ToElement); }
            public void HeadSet(T toElement) {  set.HeadSet(toElement); }
            public void TailSet(T fromElement) {  set.TailSet(fromElement); }
        }
        public class MyTreeSet<T>: MyNavigableSet<T>
        {
            private MyTreeSet<T> tree;
            public MyTreeSet(MyTreeSet<T> treee)
            {
                tree = treee;
            }
            public MyTreeSet(T[] a) { tree = new MyTreeSet<T>(a); }
            public void Add(T e) { tree.Add(e); }
            public void AddAll(T[] a) { tree.AddAll(a); }
            public void Clear() { tree.Clear(); }
            public bool Contains(object o) { return tree.Contains(o); }
            public bool ContainsAll(T[] a) { return tree.ContainsAll(a); }
            public bool IsEmpty() { return tree.IsEmpty(); }
            public void Remove(object o) { tree.Remove(o); }
            public void RemoveAll(T[] a) { tree.RemoveAll(a); }
            public void RetainAll(T[] a) { tree.RetainAll(a); }
            public int Size() { return tree.Size(); }
            public void ToArray() { tree.ToArray(); }
            public void ToArray(T[] a) { tree.ToArray(a); }
            public T First() { return tree.First(); }
            public T Last() { return tree.Last(); }
            public void SubSet(T FromElement, T ToElement) { tree.SubSet(FromElement, ToElement); }
            public void HeadSet(T toElement) { tree.HeadSet(toElement); }
            public void TailSet(T fromElement) { tree.TailSet(fromElement); }
            public void LowerEntry(T key) {  tree.LowerEntry(key); }
            public void FloorEntry(T key) { tree.FloorEntry(key); }
            public void HigherEntry(T key) { tree.HigherEntry(key); }
            public void CeilingEntry(T key) { tree.CeilingEntry(key); }
            public void LowerKey(T key) { tree.LowerKey(key); }
            public void FloorKey(T key) { tree.FloorKey(key); }
            public void HigherKey(T key) { tree.HigherKey(key); }
            public void CeilingKey(T key) { tree.CeilingKey(key); }
            public void PollFirstEntry() {  tree.PollFirstEntry(); }
            public void PollLastEntry() {  tree.PollLastEntry(); }
            public void FirstEntry() {  tree.FirstEntry(); }
            public void LastEntry() {  tree.LastEntry(); }
        }
        
        public class MyHashMap<K, V> : MyMap<K, V>
        {
            private MyHashMap<K, V> set;
            public MyHashMap(MyHashMap<K, V> sett) { set = sett; }
            public void Clear() { set.Clear(); }
            public bool ContainsKey(object key) {  return set.ContainsKey(key); }
            public bool ContainsValue(object value) {  return set.ContainsValue(value); }
            public IEnumerable<KeyValuePair<K, V>> EntrySet() { return  set.EntrySet(); }
            public V Get(object key) { return set.Get(key); }

            public bool IsEmpty() {  return set.IsEmpty(); }
            public void KeySet() {  set.KeySet(); }
            public void Put(K key, V value) {  set.Put(key, value); }
            public void PutAll(MyMap<K, V> m)
            {
                
                foreach (var entry in EntrySet())
                {
                    Put(entry.Key, entry.Value);
                }
            }
            public void Remove(object key) {  set.Remove(key); }
            public int Size() {  return set.Size(); }
            public MyCollection<V> Values()
            {
                return set.Values();

            }//
        }
        public class MyTreeMap<K, V> : MyNavigableMap<K, V>
        {
            private MyTreeMap<K, V> tree;
            public MyTreeMap(MyTreeMap<K, V> t) { tree = t; }
            public MyTreeMap(MyMap<K, V> m)
            {
                foreach (KeyValuePair<K, V> entry in EntrySet())
                {
                    tree.Put(entry.Key, entry.Value);
                }
            }
            public MyTreeMap(MySortedMap<K, V> sm)
            {
                foreach (KeyValuePair<K, V> entry in EntrySet())
                {
                    tree.Put(entry.Key, entry.Value);
                }
            }
            public void Clear() { tree.Clear(); }
            public bool ContainsKey(object key) { return tree.ContainsKey(key); }
            public bool ContainsValue(object value) { return tree.ContainsValue(value); }
            public IEnumerable<KeyValuePair<K, V>> EntrySet() { return tree.EntrySet(); }
            public V Get(object key) { return tree.Get(key); }
            public bool IsEmpty() { return tree.IsEmpty(); }
            public void KeySet() { tree.KeySet(); }
            public void Put(K key, V value) { tree.Put(key, value); }
            public void PutAll(MyMap<K, V> m)
            {
                foreach (var entry in EntrySet())
                {
                    Put(entry.Key, entry.Value);
                }
            }
            public void Remove(object key) { tree.Remove(key); }
            public int Size() { return tree.Size(); }
            public MyCollection<V> Values()
            {
                return tree.Values();

            }
            public void FirstKey() {  tree.FirstKey(); }
            public void LastKey() {  tree.LastKey(); }
            public void HeadMap(K end) {  tree.HeadMap(end); }
            public void SubMap(K start, K end) {  tree.SubMap(start, end); }
            public void TailMap(K start) {  tree.TailMap(start); }
            public void LowerEntry(K key) {  tree.LowerEntry(key); }
            public void FloorEntry(K key) { tree.FloorEntry(key); }
            public void HigherEntry(K key) { tree.HigherEntry(key); }
            public void CeilingEntry(K key) { tree.CeilingEntry(key); }
            public void LowerKey(K key) { tree.LowerKey(key); }
            public void FloorKey(K key) { tree.FloorKey(key); }
            public void HigherKey(K key) { tree.HigherKey(key); }
            public void CeilingKey(K key) { tree.CeilingKey(key); }
            public void PollFirstEntry() { tree.PollFirstEntry(); }
            public void PollLastEntry() { tree.PollFirstEntry(); }
            public void FirstEntry() {  tree.FirstEntry(); }
            public void LastEntry() {  tree.LastEntry(); }
        }
    }
}