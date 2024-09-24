using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vector
{
        public class MyVector<T>
        {
            private T[] elementData;
            private int elementCount;
            private int capacityIncrement;

            public MyVector(int initialCapacity, int capacitIncrement)
            {
                elementData = null;
                elementCount = initialCapacity;
                capacityIncrement = capacitIncrement;
            }


            public MyVector(int initialCapacity)
            {
                elementData = null;
                elementCount = initialCapacity;
                capacityIncrement = 0;
            }

            public MyVector()
            {
                elementData = null;
                elementCount = 10;
                capacityIncrement = 0;
            }
            public MyVector(T[] a)
            {
                elementData = new T[a.Length];
                for (int i = 0; i < a.Length; i++) elementData[i] = a[i];
                elementCount = a.Length;
                capacityIncrement = 0;

            }


            //в конец
            public void Add(T e)
            {
            if (elementCount == elementData.Length)
            {
                if (capacityIncrement == 0)
                {
                    T[] array = new T[(int)(elementCount * 2) + 1];
                    for (int i = 0; i < elementCount; i++) array[i] = elementData[i];
                    elementData = array;
                }
                else
                {
                    T[] array = new T[(int)(elementCount + capacityIncrement) + 1];
                    for (int i = 0; i < elementCount; i++) array[i] = elementData[i];
                    elementData = array;
                }
            }
                elementData[elementCount] = e;
            }
            public void AddAll(T[] a)
            {
                int n = a.Length;
                for (int i = 0; i < n; i++) Add(a[i]);
            }
            //удаление всех элементов
            public void Clear() { elementCount = 0; capacityIncrement = 0; }
            //проверка есть ли элемент в массиве
            public bool Contains(T o)
            {
                foreach (T t in elementData)
                {
                    if (t.Equals(o) || (t == null && o == null)) return true;
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
                if (elementCount == 0 && capacityIncrement == 0) return true;
                else return false;
            }

            //удаление объектв из массива есть объект там есть
            public void Remove(T o)
            {
                for (int i = 0; i < elementCount; i++)
                {
                    if (Contains(o))
                    {
                        T removedElement = elementData[i]; // Сохраняем удаляемый элемент
                        for (int j = i; j < elementCount - 1; j++)
                        {
                            elementData[j] = elementData[j + 1]; // Сдвигаем элементы влево
                        }
                        elementCount--; // Уменьшаем размер массива
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
                elementCount = a.Length;
            }
            //размер динамического массива
            public int Size()
            {
                return elementCount;
            }
            //возвращать массив, содержащего все элементы дин массива
            public void ToArray()
            {
                T[] array = new T[elementCount];
                for (int i = 0; i < elementCount; i++) array[i] = elementData[i];
            }
            //возвращать масиив, содержащего все элементы дин массива, если аргумент пустой, то создаем новый массив, в который копируется элементы
            public void ToArray(T[] a)
            {
                int n = a.Length;
                if (n <= elementCount && n > 0)
                {
                    T[] array = new T[n + elementCount];
                    for (int i = 0; i < n; i++) array[i] = a[i];
                    for (int i = n; i < elementCount; i++) array[i] = elementData[i];
                    a = array;

                }
                else
                {
                    T[] arr = new T[elementCount];
                    for (int i = 0; i < elementCount; i++) arr[i] = elementData[i];
                    a = arr;
                }
            }

            //добавлене элемента на указанную позицию
            public void Add(int index, T e)
            {

                // Если массив заполнен, увеличиваем его размер
                if (elementCount == elementData.Length)
                {

                    T[] array = new T[(int)(elementCount * 1.5) + 1];
                    for (int i = 0; i < elementCount; i++) array[i] = elementData[i];
                    elementData = array;
                }

                // Сдвигаем элементы, начиная с указанного индекса, вправо
                for (int i = elementCount; i > index; i--)
                {
                    elementData[i] = elementData[i - 1];
                }

                // Вставляем значение на указанный индекс
                elementData[index] = e;
                elementCount++;
            }

            //добавления элементОВ на указанную позицию
            public void AddAll(int e, T[] a)
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
                for (int i = 0; i < elementCount; i++)
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
                for (int i = 0; i < elementCount; i++)
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
                for (int i = index; i < elementCount - 1; i++)
                {
                    elementData[i] = elementData[i + 1]; // Сдвигаем элементы влево
                }
                elementCount--; // Уменьшаем размер массива
                return removedElement; // Возвращаем удаленный элемент
            }
            //замена элемента в уазанной позиции новым элементов
            public void Set(int index, T e) => elementData[index] = e;
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
                for (int i = 0; i < elementCount; i++)
                {
                    Console.WriteLine(elementData[i] + " ");
                }
            }

            public T FirstElement()
            {
                return elementData[0];
            }
            public T LastElement()
            {
                return elementData[elementCount - 1];
            }
            public void RemoveElementAt(int pos)
            {
                for (int i = pos; i < elementCount - 1; i++)
                {
                    elementData[i] = elementData[i + 1]; // Сдвигаем элементы влево
                }
                elementCount--; // Уменьшаем размер массива
            }

            public void RemoveRange(int begin, int end)
            {
                for (int i = begin; i < end + 1; i++)
                {
                    RemoveElementAt(i);
                }
            }
        }
      
}
