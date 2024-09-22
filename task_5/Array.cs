using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace task_5
{
        public class MyArrayList<T>
        {
            private int size;
            private T[] elementData;
            public MyArrayList()
            {
                elementData = null;
                size = 0;
            }


            public MyArrayList(T[] array)
            {
                // Инициализируем массив elementData элементами из массива array
                elementData = new T[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    elementData[i] = array[i];
                }
                // Устанавливаем размер массива size
                size = array.Length;
            }

            public MyArrayList(int capacity)
            {
                T[] array = new T[capacity];
                size = capacity;

            }

            //в конец
            public void Add(T e)
            {
                    T[] array = new T[(int)(size * 1.5) + 1];
                    for (int i = 0; i < size; i++) array[i] = elementData[i];
                    elementData = array;
                
                elementData[size] = e;
            }
            public void AddAll(T[] a)
            {
                int n = a.Length;
                for (int i = 0; i < n; i++) Add(a[i]);
            }
            //удаление всех элементов
            public void Clear() => size = 0;
        //проверка есть ли элемент в массиве
        public bool Contains(object obj)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.elementData[i].Equals(obj))
                    return true;
            }
            return false;
        }
        //проверка есть ли массив в дин массиве
        public bool ContainsAll(T[] a)
            {
                int n = a.Length;
                for (int i = 0; i < elementData.Length; i++)
                {
                    if (Contains(elementData[i])) return true;
                }
                return false;
            }
            public bool isEmpty()
            {
                if (size == 0) return true;
                else return false;
            }

            //удаление объектв из массива есть объект там есть
            public void Remove(T o)
            {
                for (int i = 0; i < size; i++)
                {
                    if (Contains(o))
                    {
                        T removedElement = elementData[i]; // Сохраняем удаляемый элемент
                        for (int j = i; j < size - 1; j++)
                        {
                            elementData[j] = elementData[j + 1]; // Сдвигаем элементы влево
                        }
                        size--; // Уменьшаем размер массива
                    }
                }

            }
            //удаление указанного массива
            public void RemoveAll(T[] a)
            {
                int len = a.Length;
                for (int i = 0; i < len; i++) Remove(a[i]);
            }
            //оставить указанные элементы, а остальные удалить
            public void RetainALl(T[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    elementData[i] = a[i];
                }
                size = a.Length;
            }
            //размер динамического массива
            public int Size()
            {
                return size;
            }
            //возвращать массив, содержащего все элементы дин массива
            public void ToArray()
            {
                T[] array = new T[size];
                for (int i = 0; i < size; i++) array[i] = elementData[i];
            }
            //возвращать масиив, содержащего все элементы дин массива, если аргумент пустой, то создаем новый массив, в который копируется элементы
            public void ToArray(T[] a)
            {
                int n = a.Length;
                if (n <= size && n > 0)
                {
                    T[] array = new T[n + size];
                    for (int i = 0; i < n; i++) array[i] = a[i];
                    for (int i = n; i < size; i++) array[i] = elementData[i];
                    a = array;

                }
                else
                {
                    T[] arr = new T[size];
                    for (int i = 0; i < size; i++) arr[i] = elementData[i];
                    a = arr;
                }
            }

            //добавлене элемента на указанную позицию
            public void Add(int index, T e)
            {

                // Если массив заполнен, увеличиваем его размер
                if (size == elementData.Length)
                {

                    T[] array = new T[(int)(size * 1.5) + 1];
                    for (int i = 0; i < size; i++) array[i] = elementData[i];
                    elementData = array;
                }

                // Сдвигаем элементы, начиная с указанного индекса, вправо
                for (int i = size; i > index; i--)
                {
                    elementData[i] = elementData[i - 1];
                }

                // Вставляем значение на указанный индекс
                elementData[index] = e;
                size++;
            }

            //добавления элементОВ на указанную позицию
            public void Add(int e, T[] a)
            {
                for (int i = 0; i < a.Length; i++) Add(i, a[i]);
            }
            //возвращения элемента в указанной позиции
            public T Get(int index)
            {
                return elementData[index];
            }

            //возвращение индекса указанного объекта, если объекта нет, то return -1
            public int IndexOf(object o)
            {
                for (int i = 0; i < size; i++)
                {
                    if (elementData[i].Equals(o))
                    {
                        return i; // Возвращаем индекс первого найденного элемента
                    }
                }
                return -1; // Если элемент не найден, возвращаем -1
            }
            //нахождения последнего вхождения элемента, если нет, return -1
            public int LastIndexOf(object o)
            {
                int lastIndex = -1;
                for (int i = 0; i < size; i++)
                {
                    if (elementData[i].Equals(o))
                    {
                        lastIndex = i; // Записываем индекс последнего найденного элемента
                    }
                }
                return lastIndex; // Возвращаем индекс последнего найденного элемента
            }
            //удаление и возвращение элемента в указанной позиции
            public T Remove(int index)
            {

                T removedElement = elementData[index]; // Сохраняем удаляемый элемент
                for (int i = index; i < size - 1; i++)
                {
                    elementData[i] = elementData[i + 1]; // Сдвигаем элементы влево
                }
                size--; // Уменьшаем размер массива
                return removedElement; // Возвращаем удаленный элемент
            }
            //замена элемента в уазанной позиции новым элементов
            public void Set(int index, T e)
            {


                elementData[index] = e;
            }
            //возвращение элементоа в диапазоне
            public T[] SubList(int fromIndex, int toIndex)
            {

                int length = toIndex - fromIndex; // Вычисляем размер подмассива
                T[] subArray = new T[length]; // Создаем новый массив для подмассива
                for (int i = 0; i < length; i++)
                {
                    subArray[i] = elementData[fromIndex + i]; // Копируем элементы в подмассив
                }
                return subArray; // Возвращаем подмассив
            }
            public void Print()
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(elementData[i] + " ");
                }
            }
        }
}
