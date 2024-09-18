using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace task3
{
    public partial class Graph : Form
    {
        private ZedGraphControl graphControl;
        private LineItem[] curves;
        private PointPairList[] points;
        public long[,] elapsedMS;
        public int[] arraySizes;

        public Graph(int testNumber)
        {
            InitializeComponent();
            arraySizes = new int[GetSize(testNumber)];
            InitializeGraph(testNumber);
            PlotGraph(testNumber);
        }

        public void InitializeGraph(int testNumber)
        {
            graphControl = new ZedGraphControl
            {
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(graphControl);
            GraphPane pane = graphControl.GraphPane;
            pane.Title.Text = "Производительность сортировок";
            pane.XAxis.Title.Text = "Размер массива";
            pane.YAxis.Title.Text = "Прошедшее время (мс)";

            string[] sortNames = { "BubbleSort", "InsertionSort", "SelectionSort", "ShakerSort", "GnomeSort", "BitonicSort", "ShellSort", "TreeSort", "CombSort", "HeapSort", "QuickSort", "MergeSort", "CountingSort", "BucketSort", "RadiaxSort" };
            int startIndex = GetIndex(testNumber).Item1;
            int endIndex = GetIndex(testNumber).Item2;

            Form1 mainForm = new Form1();
            if (testNumber >= 1 && testNumber < 7)
            {
                elapsedMS = mainForm.Test(startIndex, endIndex, 10000, testNumber);
                arraySizes[0] = 10;
                arraySizes[1] = 100;
                arraySizes[2] = 1000;
                arraySizes[3] = 10000;
                points = new PointPairList[5];
                curves = new LineItem[5];
            }
            else if (testNumber >= 7 && testNumber < 13)
            {
                elapsedMS = mainForm.Test(startIndex, endIndex, 100000, testNumber);
                arraySizes[0] = 10;
                arraySizes[1] = 100;
                arraySizes[2] = 1000;
                arraySizes[3] = 10000;
                arraySizes[4] = 100000;
                points = new PointPairList[3];
                curves = new LineItem[3];

            }
            else if (testNumber >= 13 && testNumber < 19)
            {
                elapsedMS = mainForm.Test(startIndex, endIndex, 1000000, testNumber);
                arraySizes[0] = 10;
                arraySizes[1] = 100;
                arraySizes[2] = 1000;
                arraySizes[3] = 10000;
                arraySizes[4] = 100000;
                arraySizes[5] = 1000000;
                points = new PointPairList[7];
                curves = new LineItem[7];
            }

            for (int i = 0, j = startIndex; i < CurveNumber(testNumber); i++, j++)
            {
                points[i] = new PointPairList();
                curves[i] = pane.AddCurve(sortNames[j], points[i], GetColor(i), SymbolType.None);
            }

            pane.XAxis.Scale.Min = arraySizes[0] - 10;
            pane.XAxis.Scale.Max = arraySizes[arraySizes.Length - 1] + 10;
            pane.YAxis.Scale.Min = MinMaxValue(elapsedMS).Item1;
            pane.YAxis.Scale.Max = MinMaxValue(elapsedMS).Item2;

            if (GetSize(testNumber) == 4)
            {
                pane.XAxis.Scale.MajorStep = 1000;
                pane.XAxis.Scale.MinorStep = 100;
            }
            if (GetSize(testNumber) == 5)
            {
                pane.XAxis.Scale.MajorStep = 10000;
                pane.XAxis.Scale.MinorStep = 1000;
            }
            if (GetSize(testNumber) == 6)
            {
                pane.XAxis.Scale.MajorStep = 100000;
                pane.XAxis.Scale.MinorStep = 10000;
            }

            graphControl.IsEnableVPan = true;
            graphControl.IsEnableVZoom = true;
            graphControl.IsEnableHPan = true;
            graphControl.IsEnableHZoom = true;
        }

        private void PlotGraph(int value)
        {
            for (int i = 0; i < CurveNumber(value); i++)
            {
                for (int j = 0; j < arraySizes.Length; j++)
                {
                    points[i].Add(arraySizes[j], elapsedMS[i, j]);
                }
            }

            graphControl.AxisChange();
            graphControl.Invalidate();
        }

        private System.Drawing.Color GetColor(int index)
        {
            switch (index)
            {
                case 0: return System.Drawing.Color.Red;
                case 1: return System.Drawing.Color.Olive;
                case 2: return System.Drawing.Color.Yellow;
                case 3: return System.Drawing.Color.Green;
                case 4: return System.Drawing.Color.Blue;
                case 5: return System.Drawing.Color.Purple;
                case 6: return System.Drawing.Color.Tomato;
                case 7: return System.Drawing.Color.Aqua;
                default: return System.Drawing.Color.AliceBlue;
            }
        }

        private static Tuple<long, long> MinMaxValue(long[,] mat)
        {
            long min = long.MaxValue;
            long max = long.MinValue;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] < min)
                    {
                        min = mat[i, j];
                    }
                    if (mat[i, j] > max)
                    {
                        max = mat[i, j];
                    }
                }
            }

            return Tuple.Create(min, max);
        }

        public int GetSize(int value)
        {
            if (value >= 1 && value < 7)
            {
                return 4;
            }
            if (value >= 7 && value < 13)
            {
                return 5;
            }
            if (value >= 13 && value < 19)
            {
                return 6;
            }
            return 0;
        }

        public Tuple<int, int> GetIndex(int value)
        {
            if (value >= 1 && value < 7)
            {
                return Tuple.Create<int, int>(0, 5);
            }
            if (value >= 7 && value < 13)
            {
                return Tuple.Create<int, int>(5, 8);
            }
            if (value >= 13 && value < 19)
            {
                return Tuple.Create<int, int>(8, 15);
            }
            return null;
        }

        public int CurveNumber(int value)
        {
            if (value >= 1 && value < 7)
            {
                return 5;
            }
            if (value >= 7 && value < 13)
            {
                return 3;
            }
            if (value >= 13 && value < 19)
            {
                return 7;
            }
            return 0;
        }
    }
}
