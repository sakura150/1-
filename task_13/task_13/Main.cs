using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task_13
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public delegate void SortDelegate(int[] array, Comparison<int> comparer);

        List<SortDelegate> sortAlgs = new List<SortDelegate>
            {
                Mylib.Class1.BubbleSort, //0
                Mylib.Class1.InsertionSort, //1
                Mylib.Class1.SelectionSort, //2
                Mylib.Class1.ShakerSort, //3
                Mylib.Class1.GhomeSort, //4
                Mylib.Class1.BitonicSort, //5
                Mylib.Class1.ShellaSort, //6
                Mylib.Class1.TreeSort, //7
                Mylib.Class1.CombSort, //8
                Mylib.Class1.HeapSort, //9
                Mylib.Class1.QuickSort, //10
                Mylib.Class1.MergeSort, //11
                Mylib.Class1.CountingSort, //12
                Mylib.Class1.RadixSort, //13
            };

        private void button1_Click_1(object sender, EventArgs e)
        {
            string gr1 = "Группа 1";
            string gr2 = "Группа 2";
            string gr3 = "Группа 3";
            string test1 = "Массивы случайных чисел";
            string test2 = "Массивы с отсортированными подмассивами";
            string test3 = "Отсортированные массивы с перестановками";
            string test4 = "Массивы, отсортированные прямо";
            string test5 = "Масиивы, отсортированные в обратном порядке";
            string test6 = "Массивы с повторяющимися элементами";
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Не были выбраны тестовые данные");
                return;
            }
            if (comboBox1.SelectedItem.ToString() == gr1 && (comboBox2.SelectedItem.ToString() == test1))
            {
                Form graph = new Graph(1);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr1 && (comboBox2.SelectedItem.ToString() == test2))
            {
                Form graph = new Graph(2);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr1 && (comboBox2.SelectedItem.ToString() == test3))
            {
                Form graph = new Graph(3);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr1 && (comboBox2.SelectedItem.ToString() == test4))
            {
                Form graph = new Graph(4);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr1 && (comboBox2.SelectedItem.ToString() == test5))
            {
                Form graph = new Graph(5);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr1 && (comboBox2.SelectedItem.ToString() == test6))
            {
                Form graph = new Graph(6);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr2 && (comboBox2.SelectedItem.ToString() == test1))
            {
                Form graph = new Graph(7);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr2 && (comboBox2.SelectedItem.ToString() == test2))
            {
                Form graph = new Graph(8);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr2 && (comboBox2.SelectedItem.ToString() == test3))
            {
                Form graph = new Graph(9);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr2 && (comboBox2.SelectedItem.ToString() == test4))
            {
                Form graph = new Graph(10);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr2 && (comboBox2.SelectedItem.ToString() == test5))
            {
                Form graph = new Graph(11);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr2 && (comboBox2.SelectedItem.ToString() == test6))
            {
                Form graph = new Graph(12);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr3 && (comboBox2.SelectedItem.ToString() == test1))
            {
                Form graph = new Graph(13);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr3 && (comboBox2.SelectedItem.ToString() == test2))
            {
                Form graph = new Graph(14);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr3 && (comboBox2.SelectedItem.ToString() == test3))
            {
                Form graph = new Graph(15);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr3 && (comboBox2.SelectedItem.ToString() == test4))
            {
                Form graph = new Graph(16);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr3 && (comboBox2.SelectedItem.ToString() == test5))
            {
                Form graph = new Graph(17);
                graph.Show();
            }
            if (comboBox1.SelectedItem.ToString() == gr3 && (comboBox2.SelectedItem.ToString() == test6))
            {
                Form graph = new Graph(18);
                graph.Show();
            }
        }

        public long[,] Test(int startInd, int endInd, int size, int testNumber)
        {
            int counter = 0;
            int sizeCopy = size;
            int sortNumber = endInd - startInd;
            while (sizeCopy != 1)
            {
                counter++;
                sizeCopy /= 10;
            }
            Stopwatch timer = new Stopwatch();
            long[,] elapsedMS = new long[sortNumber, counter];
            int[][] baseArray = ArrayGeneration(counter, testNumber);

            Parallel.For(0, sortNumber, idx =>
            {
                int sortIndex = startInd + idx;
                if (sortIndex == 15)
                {
                    sortIndex--;
                }
                for (int j = 0; j < counter; j++)
                {
                    long totalElapsed = 0;
                    for (int k = 0; k < 20; k++)
                    {
                        int[] array = (int[])baseArray[j].Clone();
                        timer.Restart();
                        sortAlgs[sortIndex](array, (x, y) => ((int)x).CompareTo((int)y));
                        timer.Stop();
                        totalElapsed += timer.ElapsedMilliseconds;
                    }

                    elapsedMS[idx, j] = totalElapsed / 20;
                }
            });
            for (int i = 0; i < elapsedMS.GetLength(0); i++)
            {
                for (int j = 0; j < elapsedMS.GetLength(1); j++)
                {
                    Console.Write(elapsedMS[i, j] + " ");
                }
                Console.WriteLine();
            }
            return elapsedMS;
        }

        public static int[][] ArrayGeneration(int counter, int testNumber)
        {
            int[][] array = new int[counter][];
            for (int i = 0, size = 10; i < counter; i++, size *= 10)
            {
                array[i] = new int[size];
            }
            RandomElemGeneration(array, testNumber);
            return array;
        }

        public static void RandomElemGeneration(int[][] array, int testNumber)
        {
            Random rand = new Random();

            if (testNumber == 1 || testNumber == 7 || testNumber == 13)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = rand.Next(-999999, 1000000);
                    }
                }
            }
            else if (testNumber == 2 || testNumber == 8 || testNumber == 14)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = rand.Next(-999999, 1000000);
                    }
                }
                int[] subArrayCount = { 2, 4, 8, 16, 3125, 15625 };
                for (int i = 0; i < array.Length; i++)
                {
                    int subArrayLength = array[i].Length / subArrayCount[i];
                    int[][] subArrays = new int[subArrayCount[i]][];
                    for (int j = 0; j < subArrayCount[i]; j++)
                    {
                        subArrays[j] = array[i]
                            .Skip(j * subArrayLength)
                            .Take(subArrayLength)
                            .ToArray();
                    }

                    for (int j = 0; j < subArrayCount[i]; j++)
                    {
                        Array.Sort(subArrays[j]);
                    }

                    int[] mergedArray = subArrays.SelectMany(subArray => subArray).ToArray();
                    array[i] = mergedArray;
                }

            }
            else if (testNumber == 3 || testNumber == 9 || testNumber == 15)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = rand.Next(-999999, 1000000);
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Array.Sort(array[i]);
                }
                int[] swapCount = { 1, 2, 4, 8, 1562, 7812 };
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < swapCount[i]; j++)
                    {
                        int tempInd1 = rand.Next(0, array[i].Length);
                        int tempInd2 = rand.Next(0, array[i].Length);
                        int temp = array[i][tempInd1];
                        array[i][tempInd1] = array[i][tempInd2];
                        array[i][tempInd2] = temp;

                    }
                }
            }
            else if (testNumber == 4 || testNumber == 10 || testNumber == 16)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = rand.Next(-999999, 1000000);
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Array.Sort(array[i]);
                }
            }
            else if (testNumber == 5 || testNumber == 11 || testNumber == 17)
            {

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = rand.Next(-999999, 1000000);
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }

            else if (testNumber == 6 || testNumber == 12 || testNumber == 18)
            {
                int fixedValue = rand.Next(-999999, 1000000);

                for (int i = 0; i < array.Length; i++)
                {
                    int halfLength = array[i].Length / 2;

                    for (int j = 0; j < halfLength; j++)
                    {
                        array[i][j] = fixedValue;
                    }

                    for (int j = halfLength; j < array[i].Length; j++)
                    {
                        array[i][j] = rand.Next(-999999, 1000000);
                    }
                }
            }
        }
    }
}
