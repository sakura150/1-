using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylib
{
 
    public class Class1
    {
        public static void BubbleSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }
                }
            }
        }
        public static void ShakerSort(int[] arr)
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
                    if (arr[i] > arr[i + 1])
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
                        if (arr[i] < arr[i - 1])
                        {
                            Swap(arr, i, i - 1);
                            swapped = true;
                        }
                    }

                    left++; // Увеличиваем левую границу
                }
            } while (swapped);
        }
        public static void GhomeSort(int[] arr)
        {
            int n = arr.Length;
            int i = 1;
            int j = 2;

            while (i < n)
            {
                if (arr[i - 1] <= arr[i])
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
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i]; // Текущий элемент, который нужно вставить
                int j = i - 1;

                // Сдвиг элементов, больших key, на один шаг вправо
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                // Вставка key в правильное место
                arr[j + 1] = key;
            }
        }
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i; // Индекс минимального элемента

                // Поиск минимального элемента в оставшейся части массива
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
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
        public static void ShellaSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;

                    // Сравнение и вставка элемента в правильное место
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }

                gap /= 2; // Уменьшение шага
            }
        }

        class Node
        {
            public int Data;
            public Node Left;
            public Node Right;

            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        class BinarySearchTree
        {
            public Node Root;

            public BinarySearchTree()
            {
                Root = null;
            }

            public void Insert(int data)
            {
                Root = InsertRec(Root, data);
            }

            private Node InsertRec(Node root, int data)
            {
                if (root == null)
                {
                    return new Node(data);
                }

                if (data < root.Data)
                    root.Left = InsertRec(root.Left, data);
                else
                    root.Right = InsertRec(root.Right, data);

                return root;
            }

            public void InOrderTraversal(Node root, List<int> result)
            {
                Stack<Node> stack = new Stack<Node>();
                Node current = root;

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

        public static void TreeSort(int[] array)
        {
            BinarySearchTree bst = new BinarySearchTree();
            foreach (int value in array)
            {
                bst.Insert(value);
            }
            List<int> sortedList = new List<int>();
            bst.InOrderTraversal(bst.Root, sortedList);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedList[i];
            }
        }
        public static void BitonicSort(int[] arr)
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
        }
        public static void CombSort(int[] arr)
        {
            int gap = arr.Length;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = (int)Math.Max(1, gap / 1.3); // Уменьшаем шаг
                swapped = false;

                for (int i = 0; i + gap < arr.Length; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        Swap(arr, i, i + gap);
                        swapped = true;
                    }
                }
            }
        }
        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Построение пирамиды (кучи)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Извлечение элементов из пирамиды
            for (int i = n - 1; i >= 0; i--)
            {
                // Обмен корневого элемента с последним элементом пирамиды
                Swap(arr, 0, i);

                // Восстановление пирамиды после обмена
                Heapify(arr, i, 0);
            }
        }

        // Функция для построения пирамиды
        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Индекс наибольшего элемента
            int left = 2 * i + 1; // Индекс левого потомка
            int right = 2 * i + 2; // Индекс правого потомка

            // Проверка, является ли левый потомок больше, чем текущий элемент
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // Проверка, является ли правый потомок больше, чем текущий элемент
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // Обмен местами, если наибольший элемент не является текущим
            if (largest != i)
            {
                Swap(arr, i, largest);

                // Рекурсивный вызов Heapify для поддерева
                Heapify(arr, n, largest);
            }
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            while (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                if (pivotIndex - left < right - pivotIndex)
                {
                    QuickSort(array, left, pivotIndex - 1);
                    left = pivotIndex + 1;
                }
                else
                {
                    QuickSort(array, pivotIndex + 1, right);
                    right = pivotIndex - 1;
                }
            }
        }
        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp1;

            return i + 1;
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }



        public static void MergeSort(int[] a)
        {
            int n = a.Length;
            int mid = n / 2; // находим середину сортируемой последовательности
            if (n % 2 == 1)
                mid++;
            int h = 1; // шаг
                       // выделяем память под формируемую последовательность
            int[] c = new int[n];
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
                        if (a[i] < a[j])
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
        public static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;

            int FindMaxValue(int[] arr)
            {
                int maxValue = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > maxValue)
                    {
                        maxValue = arr[i];
                    }
                }
                return maxValue;
            }

            int FindMinValue(int[] arr)
            {
                int minValue = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < minValue)
                    {
                        minValue = arr[i];
                    }
                }
                return minValue;
            }

            int max = FindMaxValue(array);
            int min = FindMinValue(array);

            int range = max - min + 1;

            var count = new int[range];

            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i + min;
                    index++;
                }
            }
        }
        // Функция для нахождения максимального элемента
        private static int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        public static void RadixSort(int[] arr)
        {
            int max = FindMax(arr); // Найти максимальное значение в массиве
            int exp = 1; // Начальный разряд (единицы)

            while (max / exp > 0)
            {
                LengthSort(arr, exp); // Сортировка по текущему разряду
                exp *= 10; // Переход к следующему разряду
            }
        }

        private static void LengthSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n]; // Массив для отсортированных элементов
            int[] Length = new int[10]; // Массив для подсчета количества элементов с определенным разрядом

            // Инициализация массива Length
            for (int i = 0; i < n; i++)
            {
                Length[(arr[i] / exp) % 10]++;
            }

            // Обновление массива Length
            for (int i = 1; i < 10; i++)
            {
                Length[i] += Length[i - 1];
            }

            // Создание отсортированного массива output
            for (int i = n - 1; i >= 0; i--)
            {
                output[Length[(arr[i] / exp) % 10] - 1] = arr[i];
                Length[(arr[i] / exp) % 10]--;
            }

            // Копирование элементов из output в исходный массив arr
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

    }
}
