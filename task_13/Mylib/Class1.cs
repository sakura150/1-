using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylib
{
    public class Class1
    {
        public static void BubbleSort<T>(T[] a, Comparison<T> comparer)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparer(a[j], a[j + 1]) > 0)
                    {
                        T t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }
                }
            }
        }
        public static void ShakerSort<T>(T[] arr, Comparison<T> comparer)
        {
            int left = 0;
            int right = arr.Length - 1;
            bool swapped;

            do
            {
                swapped = false;

                // Движение слева направо
                for (int i = left; i < right; i++)
                {
                    if (comparer(arr[i], arr[i + 1]) > 0)
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }

                right--; // Уменьшаем правую границу

                // Движение справа налево
                if (swapped)
                {
                    swapped = false;
                    for (int i = right; i > left; i--)
                    {
                        if (comparer(arr[i], arr[i - 1]) < 0)
                        {
                            Swap(arr, i, i - 1);
                            swapped = true;
                        }
                    }

                    left++; // Увеличиваем левую границу
                }
            } while (swapped);
        }
        public static void GhomeSort<T>(T[] arr, Comparison<T> comparer)
        {
            int n = arr.Length;
            int i = 1;
            int j = 2;

            while (i < n)
            {
                if (comparer(arr[i - 1], arr[i]) <= 0)
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(arr, i - 1, i);
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }
        private static void Swap<T>(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static void InsertionSort<T>(T[] arr, Comparison<T> comparer)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                T key = arr[i]; // Текущий элемент, который нужно вставить
                int j = i - 1;

                // Сдвиг элементов, больших key, на один шаг вправо
                while (j >= 0 && comparer(arr[j], key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                // Вставка key в правильное место
                arr[j + 1] = key;
            }
        }
        public static void SelectionSort<T>(T[] arr, Comparison<T> comparer)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i; // Индекс минимального элемента

                // Поиск минимального элемента в оставшейся части массива
                for (int j = i + 1; j < n; j++)
                {
                    if (comparer(arr[j], arr[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Обмен минимального элемента с текущим элементом
                if (minIndex != i)
                {
                    Swap(arr, i, minIndex);
                }
            }
        }
        public static void ShellaSort<T>(T[] arr, Comparison<T> comparer)
        {
            int n = arr.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = arr[i];
                    int j = i;

                    // Сравнение и вставка элемента в правильное место
                    while (j >= gap && comparer(arr[j - gap], temp) > 0)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }

                gap /= 2; // Уменьшение шага
            }
        }

        class Node<T>
        {
            public T Data;
            public Node<T> Left;
            public Node<T> Right;

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        class BinarySearchTree<T>
        {
            public Node<T> Root;

            public BinarySearchTree()
            {
                Root = null;
            }

            public void Insert(T data, Comparison<T> comparer)
            {
                Root = InsertRec(Root, data, comparer);
            }

            private Node<T> InsertRec(Node<T> root, T data, Comparison<T> comparer)
            {
                if (root == null)
                {
                    return new Node<T>(data);
                }

                if (comparer(data, root.Data) < 0)
                    root.Left = InsertRec(root.Left, data, comparer);
                else
                    root.Right = InsertRec(root.Right, data, comparer);

                return root;
            }

            public void InOrderTraversal(Node<T> root, List<T> result)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = root;

                while (current != null || stack.Count > 0)
                {
                    while (current != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }

                    current = stack.Pop();
                    result.Add(current.Data);
                    current = current.Right;
                }
            }
        }

        public static void TreeSort<T>(T[] array, Comparison<T> comparer)
        {
            BinarySearchTree<T> bst = new BinarySearchTree<T>();
            foreach (T value in array)
            {
                bst.Insert(value, comparer);
            }
            List<T> sortedList = new List<T>();
            bst.InOrderTraversal(bst.Root, sortedList);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedList[i];
            }
        }
        /*public static void BitonicSort(int[] arr)
        {
            int n = arr.Length;
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            // Определение максимального количества битов
            int maxBits = 0;
            while (max > 0)
            {
                maxBits++;
                max >>= 1;
            }

            // Сортировка по битам
            for (int bit = 0; bit < maxBits; bit++)
            {
                int[] temp = new int[n];
                int j = 0;
                for (int i = 0; i < n; i++)
                {
                    if (((arr[i] >> bit) & 1) == 1)
                    {
                        temp[j++] = arr[i];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (((arr[i] >> bit) & 1) == 0)
                    {
                        temp[j++] = arr[i];
                    }
                }
                arr = temp;
            }
        }*/
        public static void BitonicSort<T>(T[] array, Comparison<T> comparer)
        {
            if (array.Length == 0) return;

            // 1. Найти максимальное значение в массиве
            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (comparer(array[i], max) > 0)
                {
                    max = array[i];
                }
            }

            // 2. Определить максимальное количество бит 
            int maxBits = GetMaxBits(max, comparer);

            // 3. Выполнить битовую сортировку
            for (int bit = 0; bit < maxBits; bit++)
            {
                // 4. Создать два массива для хранения элементов в зависимости от значения бита
                List<T> zeroBits = new List<T>();
                List<T> oneBits = new List<T>();

                // 5. Распределить элементы по массивам
                foreach (T element in array)
                {
                    if (GetBit(element, bit, comparer) == 0)
                    {
                        zeroBits.Add(element);
                    }
                    else
                    {
                        oneBits.Add(element);
                    }
                }

                // 6. Собрать элементы из массивов в исходный массив
                int index = 0;
                foreach (T element in zeroBits)
                {
                    array[index++] = element;
                }
                foreach (T element in oneBits)
                {
                    array[index++] = element;
                }
            }
        }

        // Функция для получения максимального количества бит в числе
        private static int GetMaxBits<T>(T value, Comparison<T> comparer)
        {
            int bits = 0;
            while (comparer(value, GetValueFromIndexx(value, bits, comparer)) >= 0)
            {
                bits++;
            }
            return bits;
        }

        // Функция для получения значения бита на заданной позиции 
        private static int GetBit<T>(T value, int bit, Comparison<T> comparer)
        {
            return (comparer(GetValueFromIndexx(value, bit, comparer), GetValueFromIndexx(value, bit + 1, comparer)) & 1);
        }

        // Функция-заглушка для получения значения по индексу (необходимо реализовать для каждого типа данных)
        private static T GetValueFromIndexx<T>(T value, int index, Comparison<T> comparer)
        {
            // Реализация получения значения по индексу для конкретного типа данных
            throw new NotImplementedException();
        }






        public static void CombSort<T>(T[] arr, Comparison<T> comparer)
        {
            int gap = arr.Length;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = (int)Math.Max(1, gap / 1.3); // Уменьшаем шаг
                swapped = false;

                for (int i = 0; i + gap < arr.Length; i++)
                {
                    if (comparer(arr[i], arr[i + gap]) > 0)
                    {
                        Swap(arr, i, i + gap);
                        swapped = true;
                    }
                }
            }
        }
        public static void HeapSort<T>(T[] arr, Comparison<T> comparer)
        {
            int n = arr.Length;

            // Построение пирамиды (кучи)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i, comparer);
            }

            // Извлечение элементов из пирамиды
            for (int i = n - 1; i >= 0; i--)
            {
                // Обмен корневого элемента с последним элементом пирамиды
                Swap(arr, 0, i);

                // Восстановление пирамиды после обмена
                Heapify(arr, i, 0, comparer);
            }
        }

        // Функция для построения пирамиды
        private static void Heapify<T>(T[] arr, int n, int i, Comparison<T> comparer)
        {
            int largest = i; // Индекс наибольшего элемента
            int left = 2 * i + 1; // Индекс левого потомка
            int right = 2 * i + 2; // Индекс правого потомка

            // Проверка, является ли левый потомок больше, чем текущий элемент
            if (left < n && comparer(arr[left], arr[largest]) > 0)
            {
                largest = left;
            }

            // Проверка, является ли правый потомок больше, чем текущий элемент
            if (right < n && comparer(arr[right], arr[largest]) > 0)
            {
                largest = right;
            }

            // Обмен местами, если наибольший элемент не является текущим
            if (largest != i)
            {
                Swap(arr, i, largest);

                // Рекурсивный вызов Heapify для поддерева
                Heapify(arr, n, largest, comparer);
            }
        }

        public static void QuickSort<T>(T[] array, int left, int right, Comparison<T> comparer)
        {
            while (left < right)
            {
                int pivotIndex = Partition(array, left, right, comparer);

                if (pivotIndex - left < right - pivotIndex)
                {
                    QuickSort(array, left, pivotIndex - 1, comparer);
                    left = pivotIndex + 1;
                }
                else
                {
                    QuickSort(array, pivotIndex + 1, right, comparer);
                    right = pivotIndex - 1;
                }
            }
        }
        static int Partition<T>(T[] array, int left, int right, Comparison<T> comparer)
        {
            T pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (comparer(array[j], pivot) <= 0)
                {
                    i++;
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            T temp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp1;

            return i + 1;
        }

        public static void QuickSort<T>(T[] array, Comparison<T> comparer)
        {
            QuickSort(array, 0, array.Length - 1, comparer);
        }



        public static void MergeSort<T>(T[] a, Comparison<T> comparer)
        {
            int n = a.Length;
            int mid = n / 2; // находим середину сортируемой последовательности
            if (n % 2 == 1)
                mid++;
            int h = 1; // шаг
                       // выделяем память под формируемую последовательность
            T[] c = new T[n];
            int step;
            while (h < n)
            {
                step = h;
                int i = 0;   // индекс первого пути
                int j = mid; // индекс второго пути
                int k = 0;   // индекс элемента в результирующей последовательности
                while (step <= mid)
                {
                    while ((i < step) && (j < n) && (j < (mid + step)))
                    { // пока не дошли до конца пути
                      // заполняем следующий элемент формируемой последовательности
                      // меньшим из двух просматриваемых
                        if (comparer(a[i], a[j]) < 0)
                        {
                            c[k] = a[i];
                            i++; k++;
                        }
                        else
                        {
                            c[k] = a[j];
                            j++; k++;
                        }
                    }
                    while (i < step)
                    { // переписываем оставшиеся элементы первого пути (если второй кончился раньше)
                        c[k] = a[i];
                        i++; k++;
                    }
                    while ((j < (mid + step)) && (j < n))
                    {  // переписываем оставшиеся элементы второго пути (если первый кончился раньше)
                        c[k] = a[j];
                        j++; k++;
                    }
                    step = step + h; // переходим к следующему этапу
                }
                h = h * 2;
                // Переносим упорядоченную последовательность (промежуточный вариант) в исходный массив
                for (i = 0; i < n; i++)
                    a[i] = c[i];
            }
        }

        public static void CountingSort<T>(T[] array, Comparison<T> comparer)
        {
            if (array.Length == 0) return;

            // 1. Найти минимальное и максимальное значения в массиве
            T min = array[0];
            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (comparer(array[i], min) < 0)
                {
                    min = array[i];
                }
                if (comparer(array[i], max) > 0)
                {
                    max = array[i];
                }
            }

            // 2. Создать массив подсчета
            Dictionary<T, int> count = new Dictionary<T, int>();

            // 3. Подсчитать количество элементов для каждого уникального значения
            foreach (T element in array)
            {
                if (count.ContainsKey(element))
                {
                    count[element]++;
                }
                else
                {
                    count[element] = 1;
                }
            }

            // 4. Создать отсортированный массив
            T[] sortedArray = new T[array.Length];
           
            int index = 0;
            foreach (var kvp in count.OrderBy(x => x.Key))
            {
                for (int j = 0; j < kvp.Value; j++)
                {
                    sortedArray[index++] = kvp.Key;
                }
            }

            // 5. Записать отсортированный массив в исходный массив
            Array.Copy(sortedArray, array, array.Length);
        }



        public static void RadixSort<T>(T[] array, Comparison<T> comparer)
        {
            if (array.Length == 0) return;

            // 1. Найти максимальное значение в массиве
            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (comparer(array[i], max) > 0)
                {
                    max = array[i];
                }
            }

            // 2. Определить максимальное количество разрядов 
            int maxDigits = GetMaxDigits(max, comparer);

            // 3. Выполнить поразрядную сортировку
            for (int digit = 0; digit < maxDigits; digit++)
            {
                // 4. Создать массив для каждой цифры (0-9)
                List<T>[] buckets = new List<T>[10];
                for (int i = 0; i < buckets.Length; i++)
                {
                    buckets[i] = new List<T>();
                }

                // 5. Распределить элементы по корзинам
                foreach (T element in array)
                {
                    int digitValue = GetDigit(element, digit, comparer);
                    buckets[digitValue].Add(element);
                }

                // 6. Собрать элементы из корзин в исходный массив
                int index = 0;
                for (int i = 0; i < buckets.Length; i++)
                {
                    foreach (T element in buckets[i])
                    {
                        array[index++] = element;
                    }
                }
            }
        }

        // Функция для получения максимального количества разрядов в числе
        private static int GetMaxDigits<T>(T value, Comparison<T> comparer)
        {
            int digits = 0;
            while (comparer(value, GetValueFromIndex(value, digits, comparer)) >= 0)
            {
                digits++;
            }
            return digits;
        }

        // Функция для получения цифры на заданной позиции 
        private static int GetDigit<T>(T value, int digit, Comparison<T> comparer)
        {
            return comparer(GetValueFromIndex(value, digit, comparer), GetValueFromIndex(value, digit + 1, comparer));
        }

        // Функция-заглушка для получения значения по индексу (необходимо реализовать для каждого типа данных)
        private static T GetValueFromIndex<T>(T value, int index, Comparison<T> comparer)
        {
            // Реализация получения значения по индексу для конкретного типа данных
            throw new NotImplementedException();
        }
    }
}
