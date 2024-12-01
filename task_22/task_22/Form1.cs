using Mylib;
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

namespace task_22
{
    public partial class Form1 : Form
    {
        MyHashMap<int, int> list1;
        MyTreeMap<int, int> list2;
       
        private ZedGraphControl zedGraphControl;
        public Form1()
        {
            InitializeComponent();
            zedGraphControl = new ZedGraphControl();
            zedGraphControl.Location = new Point(10, 10);
            zedGraphControl.Size = new Size(600, 400);
            Controls.Add(zedGraphControl);

            // Создание массива и двунаправленного списка
            list1 = new MyHashMap<int, int>();
            list2 = new MyTreeMap<int, int>();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            zedGraphControl.GraphPane.CurveList.Clear();
            GraphPane pane = zedGraphControl.GraphPane;

            const string gr1 = "Put";
            const string gr2 = "Get";
            const string gr3 = "Remove";
     
            PointPairList listArray = new PointPairList();
            PointPairList listLinkedList = new PointPairList();

            zedGraphControl.GraphPane.Title.Text = "Зависимость времени выполнения от размера массива";
            zedGraphControl.GraphPane.XAxis.Title.Text = "Количество элементов";
            zedGraphControl.GraphPane.YAxis.Title.Text = "Время выполнения (мс)";

            switch (comboBox1.SelectedItem.ToString())
            {

                case gr1:
                    for (int i = 0; i < 1000000; i++)
                    {
                        DateTime startArray = DateTime.Now;
                        list1.Put(i, i+1);
                        DateTime endArray = DateTime.Now;
                        TimeSpan durationArray = endArray - startArray;
                        listArray.Add(i, durationArray.TotalMilliseconds);

                        DateTime startLinkedList = DateTime.Now;
                        list2.Put(i, i+1);
                        DateTime endLinkedList = DateTime.Now;
                        TimeSpan durationLinkedList = endLinkedList - startLinkedList;
                        listLinkedList.Add(i, durationLinkedList.TotalMilliseconds);
                        list2.Remove(i);
                    }
                    break;
                case gr2:
                    for (int i = 0; i < 1000000; i++)
                    {
                        DateTime startArray = DateTime.Now;
                        list1.Put(i, i + 1);
                        list1.Get(i);
                        DateTime endArray = DateTime.Now;
                        TimeSpan durationArray = endArray - startArray;
                        listArray.Add(i, durationArray.TotalMilliseconds);
                        DateTime startLinkedList = DateTime.Now;
                        list2.Put(i, i + 1);
                        list2.Get(i);
                        DateTime endLinkedList = DateTime.Now;
                        TimeSpan durationLinkedList = endLinkedList - startLinkedList;
                        listLinkedList.Add(i, durationLinkedList.TotalMilliseconds);
                        list2.Remove(i);
                    }
                    break;
                case gr3:
                    for (int i = 0; i < 1000000; i++)
                    {
                        DateTime startArray = DateTime.Now;
                        list1.Put(i, i + 1);
                        list1.Remove(i);
                        DateTime endArray = DateTime.Now;
                        TimeSpan durationArray = endArray - startArray;
                        listArray.Add(i, durationArray.TotalMilliseconds);
                        DateTime startLinkedList = DateTime.Now;
                        list2.Put(i, i + 1);
                        list2.Remove(i);
                        DateTime endLinkedList = DateTime.Now;
                        TimeSpan durationLinkedList = endLinkedList - startLinkedList;
                        listLinkedList.Add(i, durationLinkedList.TotalMilliseconds);
                    }
                    break;
                default:
                    MessageBox.Show("Не были выбраны тестовые данные");
                    break;


            }
            

            LineItem myh = pane.AddCurve("хэш функция", listArray, Color.Black, SymbolType.None);
            myh.Line.Width = 5;
            myh.Line.Color = Color.Black;
            myh.Color = Color.Black;


            LineItem myhh = pane.AddCurve("дерево", listLinkedList, Color.Green, SymbolType.None);
            myhh.Line.Width = 5;
            myhh.Line.Color = Color.Green;
            myhh.Color = Color.Green;



            // Обновление графика
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
