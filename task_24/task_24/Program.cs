
using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;



public class MyTreeSet<T> where T : IComparable<T>
{
    private Node<T> _root;
    private int size;
    private Comparison<T> comparator;

    public MyTreeSet()//
    {
        size = 0;
    }
    public MyTreeSet(Comparison<T> comparatorr)//
    {
        comparatorr = comparator;

    }
    public MyTreeSet(T[] a)//
    {
        foreach(T t in a) Add(t);
    }
    public MyTreeSet(SortedSet<T> s)//
    {
        foreach (T t in s) Add(t);
    }
    public void Add(T value)//
    {
        Node<T> newNode = new Node<T>(value);
        if (_root == null)
        {
            _root = newNode;
            newNode.Color = Color.Black;
            return;
        }

        Node<T> parentNode = null;
        Node<T> currentNode = _root;
        while (currentNode != null)
        {
            parentNode = currentNode;
            if (value.CompareTo(currentNode.Data) < 0)
            {
                currentNode = currentNode.Left;
            }
            else
            {
                currentNode = currentNode.Right;
            }
        }

        if (value.CompareTo(parentNode.Data) < 0)
        {
            parentNode.Left = newNode;
        }
        else
        {
            parentNode.Right = newNode;
        }

        newNode.Parent = parentNode;
        newNode.Color = Color.Red;

        Balance(newNode);
    }
    public void AddAll(T[] a)//
    {
        foreach( T t in a)
        {
            Add(t);
        }
    }
    public void Clear()//
    {
        _root = null;
    }
    public bool Contains(object o)//
    {
        T e = (T)o;
        if (Search(e)) return true;
        else return false;
    }
    public bool ContainsAll(T[] a)//
    {
        foreach(T t in a)
        {
            if (Search(t)) return true;
        }
        return false;
    }
    public bool IsEmpty()//
    {
        if (_root == null) return true;
        else return false;
    }
    public void Remove(T e)//
    {
        Node<T> nodeToDelete = FindNode(e);
        if (nodeToDelete == null)
        {
            return;
        }

        if (nodeToDelete.Left == null && nodeToDelete.Right == null)
        {
            DeleteNodeWithNoChildren(nodeToDelete);
        }
        else if (nodeToDelete.Left == null)
        {
            DeleteNodeWithOneChild(nodeToDelete, nodeToDelete.Right);
        }
        else if (nodeToDelete.Right == null)
        {
            DeleteNodeWithOneChild(nodeToDelete, nodeToDelete.Left);
        }
        else
        {
            DeleteNodeWithTwoChildren(nodeToDelete);
        }
    }
    public void RemoveAll(T[] a)//
    {
        foreach( T t in a)
        {
            Remove(t);
        }
    }
    public void RetainAll(T[] a)//
    {
        T[] array = ToArray(); int i = 0;
        foreach(T t in array)
        {
            if (t.CompareTo(a[i]) != 0) Remove(t);
        }
    }
    public int Size()//
    {
        return size;
    }
    public T[] ToArray()//
    {
         List<T> list = new List<T>();
         ToArray(_root, list);
         T[] array = new T[list.Count];
        int i = 0;
        foreach( T t in list)
        {
            array[i] = t; i++;
        }
        return array;
        
    }
    private void ToArray(Node<T> node, List<T> list)//
    {

        if(node != null)
        {
            list.Add(node.Data);
            ToArray(node.Left, list);
            ToArray(node.Right, list);
        }
    }
    public T[] ToArray(T[] a)//
    {
        if (a != null)
        {
            List<T> list = new List<T>();
            ToArray(_root, list);
            T[] array = new T[list.Count + a.Length];
            int i = 0;
            foreach (T t in list)
            {
                array[i] = t; i++;
            }
            foreach (T t in a)
            {
                array[i] = t; i++;
            }
            return array;
        }
        else
        {
            List<T> list = new List<T>();
            ToArray(_root, list);
            T[] array = new T[list.Count];
            int i = 0;
            foreach (T t in list)
            {
                array[i] = t; i++;
            }
            return array;
        }
    }
    public T First()//
    {
        T[] arr = ToArray();
        T min = arr[0];
        foreach (T t in arr) if (min.CompareTo(t) > 0) min = t;
        return min;
    }
    public T Last()//
    {
        T[] arr = ToArray();
        T max = arr[0];
        foreach (T t in arr) if (max.CompareTo(t) < 0) max = t;
        return max;
    }
    public void SubSet(T fromElement, T toElement)//
    {
        T[] arr = ToArray();
        foreach(T t in arr)
        {
            if (t.CompareTo(fromElement) >= 0 && t.CompareTo(toElement) <= 0) Console.WriteLine(t);
        }
    }
    public void HeadSet(T toElement)//
    {
        T[] arr = ToArray();
        foreach (T t in arr)
        {
            if (t.CompareTo(toElement) <= 0) Console.WriteLine(t);
        }
    }
    public void TailSet(T fromElement)//
    {
        T[] arr = ToArray();
        foreach (T t in arr)
        {
            if (t.CompareTo(fromElement) >= 0 ) Console.WriteLine(t);
        }
    }
    public T Ceiling(T obj)//
    {
        T[] arr = ToArray();
        T min = arr[0]; int k = 0;
        foreach(T t in arr)
        {
            if (min.CompareTo(t) < 0 && min.CompareTo(obj) >= 0) { min = t; k = 1; }
        }
        if (k == 1) return min;
        else return default;
    }
    public T Floor(T obj)//
    {
        T[] arr = ToArray();
        T max = arr[0]; int k = 0;
        foreach (T t in arr)
        {
            if (max.CompareTo(t) > 0 && max.CompareTo(obj) <= 0) { max = t; k = 1; }
        }
        if (k == 1) return max;
        else return default;
    }
    public T Higher(T obj)//
    {
        T[] arr = ToArray();
        T max = arr[0]; int k = 0;
        foreach (T t in arr)
        {
            if (max.CompareTo(t) > 0 && max.CompareTo(obj) > 0) { max = t; k = 1; }
        }
        if (k == 1) return max;
        else return default;
    }
    public T Lower(T obj)//
    {
        T[] arr = ToArray();
        T min = arr[0]; int k = 0;
        foreach (T t in arr)
        {
            if (min.CompareTo(t) < 0 && min.CompareTo(obj) < 0) { min = t; k = 1; }
        }
        if (k == 1) return min;
        else return default;
    }
    public MyTreeSet<T> HeadSet(T upperBound, bool incl)//
    {
        if (incl== null)
        {
            throw new ArgumentNullException("Boundaries cannot be null.");
        }


        MyTreeSet<T> subset = new MyTreeSet<T>();
        T[] arr = ToArray();
        foreach (T element in arr)
        {
            bool include = false;


            int upperComparison = element.CompareTo(upperBound);


            if (upperComparison > 0 || (upperComparison == 0 && incl))
            {
                include = true;
            }
            if (include)
            {
                subset.Add(element);
            }
        }

        return subset;
    }
    public MyTreeSet<T> SubSet(T lowerBound, bool lowIncl, T upperBound, bool highincl)//
    {
        if (lowerBound == null || upperBound == null)
        {
            throw new ArgumentNullException("Boundaries cannot be null.");
        }

        if (lowerBound.CompareTo(upperBound) > 0)
        {
            throw new ArgumentException("Lower bound must be less than or equal to upper bound.");
        }


        MyTreeSet<T> subset = new MyTreeSet<T>();
        T[] arr = ToArray();
        foreach (T element in arr)
        {
            bool include = false;

            int lowerComparison = element.CompareTo(lowerBound);
            int upperComparison = element.CompareTo(upperBound);

            if (lowerComparison > 0 || (lowerComparison == 0 && lowIncl))
            {
                if (upperComparison < 0 || (upperComparison == 0 && highincl))
                {
                    include = true;
                }
            }

            if (include)
            {
                subset.Add(element);
            }
        }

        return subset;
    }
    public MyTreeSet<T> TailSet(T fromElement, bool inclusive)//
    {
        if (inclusive == null )
        {
            throw new ArgumentNullException("Boundaries cannot be null.");
        }


        MyTreeSet<T> subset = new MyTreeSet<T>();
        T[] arr = ToArray();
        foreach (T element in arr)
        {
            bool include = false;

           
            int upperComparison = element.CompareTo(fromElement);


            if (upperComparison < 0 || (upperComparison == 0 && inclusive))
            {
                include = true;
            }
            if (include)
            {
                subset.Add(element);
            }
        }

        return subset;
    }
    public T PollLast()//
    {
        T max = Last();
        Remove(max);
        return max;
    }
    public T PollFirst()//
    {
        T min = First();
        Remove(min);
        return min;
    }
    public IEnumerable<T> DescendingIterator()//
    {
        if (_root == null) yield break;

        var stack = new Stack<Node<T>>();
        var current = _root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Right; // Сначала идем максимально вправо
            }

            current = stack.Pop();
            yield return current.Data;
            current = current.Left; // Затем идем влево
        }
    }
    public SortedSet<T> DescendingSet()//
    {
        var descendingSet = new SortedSet<T>(Comparer<T>.Create((x, y) => y.CompareTo(x))); //Обратный компаратор
        var enumerator = DescendingIterator(); //Используем итератор из предыдущего ответа
        foreach (var item in enumerator)
        {
            descendingSet.Add(item);
        }
        return descendingSet;
    }
    private void Balance(Node<T> node)
    {
        while (node != _root && node.Parent.Color == Color.Red)
        {
            if (node.Parent == node.Parent.Parent.Left)
            {
                Node<T> uncleNode = node.Parent.Parent.Right;
                if (uncleNode != null && uncleNode.Color == Color.Red)
                {
                    node.Parent.Color = Color.Black;
                    uncleNode.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Right)
                    {
                        node = node.Parent;
                        LeftRotate(node);
                    }

                    node.Parent.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    RightRotate(node.Parent.Parent);
                }
            }
            else
            {
                Node<T> uncleNode = node.Parent.Parent.Left;
                if (uncleNode != null && uncleNode.Color == Color.Red)
                {
                    node.Parent.Color = Color.Black;
                    uncleNode.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        RightRotate(node);
                    }

                    node.Parent.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    LeftRotate(node.Parent.Parent);
                }
            }
        }

        _root.Color = Color.Black;
    }
    private void LeftRotate(Node<T> node)
    {
        Node<T> rightNode = node.Right;
        node.Right = rightNode.Left;
        if (rightNode.Left != null)
        {
            rightNode.Left.Parent = node;
        }

        rightNode.Parent = node.Parent;
        if (node.Parent == null)
        {
            _root = rightNode;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = rightNode;
        }
        else
        {
            node.Parent.Right = rightNode;
        }

        rightNode.Left = node;
        node.Parent = rightNode;
    }
    private void RightRotate(Node<T> node)
    {
        Node<T> leftNode = node.Left;
        node.Left = leftNode.Right;
        if (leftNode.Right != null)
        {
            leftNode.Right.Parent = node;
        }

        leftNode.Parent = node.Parent;
        if (node.Parent == null)
        {
            _root = leftNode;
        }
        else if (node == node.Parent.Right)
        {
            node.Parent.Right = leftNode;
        }
        else
        {
            node.Parent.Left = leftNode;
        }
        leftNode.Right = node;
        node.Parent = leftNode;
    }
    public bool Search(T value)
    {
        Node<T> currentNode = _root;
        while (currentNode != null)
        {
            if (value.CompareTo(currentNode.Data) == 0)
            {
                return true;
            }
            else if (value.CompareTo(currentNode.Data) < 0)
            {
                currentNode = currentNode.Left;
            }
            else
            {
                currentNode = currentNode.Right;
            }
        }

        return false;
    }
    private Node<T> FindNode(T value)
    {
        Node<T> currentNode = _root;
        while (currentNode != null)
        {
            if (value.CompareTo(currentNode.Data) == 0)
            {
                return currentNode;
            }
            else if (value.CompareTo(currentNode.Data) < 0)
            {
                currentNode = currentNode.Left;
            }
            else
            {
                currentNode = currentNode.Right;
            }
        }

        return null;
    }
    private void DeleteNodeWithNoChildren(Node<T> nodeToDelete)
    {
        if (nodeToDelete == _root)
        {
            _root = null;
        }
        else if (nodeToDelete == nodeToDelete.Parent.Left)
        {
            nodeToDelete.Parent.Left = null;
        }
        else
        {
            nodeToDelete.Parent.Right = null;
        }
    }
    private void DeleteNodeWithOneChild(Node<T> nodeToDelete, Node<T> childNode)
    {
        if (nodeToDelete == _root)
        {
            _root = childNode;
            childNode.Parent = null;
        }
        else if (nodeToDelete == nodeToDelete.Parent.Left)
        {
            nodeToDelete.Parent.Left = childNode;
        }
        else
        {
            nodeToDelete.Parent.Right = childNode;
        }

        childNode.Parent = nodeToDelete.Parent;
    }
    private void DeleteNodeWithTwoChildren(Node<T> nodeToDelete)
    {
        Node<T> successorNode = FindSuccessor(nodeToDelete);
        nodeToDelete.Data = successorNode.Data;

        if (successorNode.Left == null && successorNode.Right == null)
        {
            DeleteNodeWithNoChildren(successorNode);
        }
        else if (successorNode.Left == null)
        {
            DeleteNodeWithOneChild(successorNode, successorNode.Right);
        }
        else
        {
            DeleteNodeWithOneChild(successorNode, successorNode.Left);
        }
    }
    private Node<T> FindSuccessor(Node<T> node)
    {
        Node<T> successorNode = node.Right;
        while (successorNode.Left != null)
        {
            successorNode = successorNode.Left;
        }

        return successorNode;
    }
    private enum Color
    {
        Red,
        Black
    }
    private class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public Color Color { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            Parent = null;
            Color = Color.Red;
        }
    }
    public void PrintTree()
    {
        PrintTree(_root);
    }
    private void PrintTree(Node<T> node)
    {
        if (node == null)
        {
            Console.WriteLine("Null node");
            return;
        }

        Console.WriteLine($"{node.Data} ({node.Color})");
        if (node.Left != null)
        {
            Console.WriteLine("Left child:");
            PrintTree(node.Left);
        }
        if (node.Right != null)
        {
            Console.WriteLine("Right child:");
            PrintTree(node.Right);
        }
    }
}
public class Progrem
{
    public static void Main(string[] args)
    {
        
        MyTreeSet<int> tree = new MyTreeSet<int>();

        // Add some values into the tree
        tree.Add(10);
        tree.Add(5);
        tree.Add(15);
        tree.Add(2);
        tree.Add(7);
        tree.Add(12);
        tree.Add(20);

        // Search for a value in the tree
        bool found = tree.Search(7);
        if (found)
        {
            Console.WriteLine("Value found in the tree.");
        }
        else
        {
            Console.WriteLine("Value not found in the tree.");
        }

        // Delete a value from the tree
        tree.Remove(10);
        bool found1 = tree.Search(10);
        if (found1)
        {
            Console.WriteLine("Value found in the tree.");
        }
        else
        {
            Console.WriteLine("Value not found in the tree.");
        }
        tree.PrintTree();

    }
}