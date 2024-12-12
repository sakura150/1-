using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_29
{

    public partial class Form1 : Form
    {


        private Dictionary<string, Point> nodePositions = new Dictionary<string, Point>();
        private List<Tuple<string, string>> edges = new List<Tuple<string, string>>();
        private ListBox listBox1;
        private List<List<int>> stronglyConnectedComponents;
        private ListBox textBoxResults;
        private ListBox listBoxKosaraju;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Граф";
            this.Size = new Size(900, 600);

            //Пример графа (вершины и ребра)
            nodePositions.Add("0", new Point(100, 50));
            nodePositions.Add("1", new Point(300, 50));
            nodePositions.Add("2", new Point(450, 200));
            nodePositions.Add("3", new Point(300, 350));
            nodePositions.Add("4", new Point(100, 350));
            nodePositions.Add("5", new Point(50, 200));
            edges.Add(new Tuple<string, string>("0", "1"));
            edges.Add(new Tuple<string, string>("0", "2"));
            edges.Add(new Tuple<string, string>("1", "2"));
            edges.Add(new Tuple<string, string>("1", "3"));
            edges.Add(new Tuple<string, string>("2", "4"));
            edges.Add(new Tuple<string, string>("2", "3"));
            edges.Add(new Tuple<string, string>("3", "4"));
            edges.Add(new Tuple<string, string>("3", "5"));
            edges.Add(new Tuple<string, string>("4", "5"));

            listBoxKosaraju = new ListBox();
            listBoxKosaraju.Location = new Point(500, 50);
            listBoxKosaraju.Size = new Size(300, 100);
            this.Controls.Add(listBoxKosaraju);

            // Пример использования
            
            Kosaraju kosaraju = new Kosaraju(6);
            kosaraju.AddEdge(0, 1);
            kosaraju.AddEdge(0, 2);
            kosaraju.AddEdge(1, 2);
            kosaraju.AddEdge(1, 3);
            kosaraju.AddEdge(2, 1);
            kosaraju.AddEdge(2, 4);
            kosaraju.AddEdge(3, 2);
            kosaraju.AddEdge(3, 5);
            kosaraju.AddEdge(4, 3);
            kosaraju.AddEdge(4, 5);

            List<List<int>> stronglyConnectedComponents = kosaraju.GetStronglyConnectedComponents();
            List<int> allVertices = new List<int>();
            foreach (List<int> component in stronglyConnectedComponents)
            {
                allVertices.AddRange(component); // Добавляем все вершины из компонента
            }
            listBoxKosaraju.Items.Add($"Компоненты сильной связности: {string.Join(", ", allVertices)}");

            


            // Пример использования
            int[,] capacity = {
            {0, 16, 13, 0, 0, 0},
            {0, 0, 10, 12, 0, 0},
            {0, 4, 0, 0, 14, 0},
            {0, 0, 9, 0, 0, 20},
            {0, 0, 0, 7, 0, 4},
            {0, 0, 0, 0, 0, 0}
        };
            int source = 0;
            int sink = capacity.GetLength(0) - 1; // Предполагаем, что сток - последняя вершина

            int maxFlow = EdmondsKarp.MaxFlow(capacity, source, sink);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Максимальный поток: {maxFlow}");

            listBoxKosaraju.Items.Add(sb.ToString());



            bool[,] adjacencyMatrix = {
                {false, true, true, false, false, false},
                {false, false, true, true, false, false },
                {false, true, false, false, true, false, },
                {false, false, true, false, false, true },
                {false, false, false, true, false, true },
                {false, false, false, false, false, false }
            };
            MaximumCliqueBruteForce cliqueFinder = new MaximumCliqueBruteForce(adjacencyMatrix);
            List<int> maxClique = cliqueFinder.findMaxClique();

            StringBuilder sbb = new StringBuilder();
            sbb.AppendLine("Максимальная клика:");
            if (maxClique.Count > 0)
            {
                sbb.AppendLine(string.Join(", ", maxClique));
            }
            else
            {
                sbb.AppendLine("Не найдена");
            }

            listBoxKosaraju.Items.Add(sbb.ToString());


            textBoxResults = new ListBox();
            textBoxResults.Location = new Point(500, 200);
            textBoxResults.Size = new Size(300, 100);
            this.Controls.Add(textBoxResults);

            textBoxResults.Items.Add("список ребер");

            textBoxResults.Items.Add("идет от 0 ребра (0,1) - 16, (0,2) - 13");
            textBoxResults.Items.Add(" идет от 1 ребра (1, 2) - 10, (1,3) - 12");
            textBoxResults.Items.Add(" идет от 2 ребра (2, 1) - 4, (2, 4) - 14");
            textBoxResults.Items.Add(" идет от 3 ребра (3,2) - 9, (3, 5) - 20 ");
            textBoxResults.Items.Add(" идет от 4 ребра (4,3 ) - 7, (4,5) -4");
            textBoxResults.Items.Add(" идет от 5 ребер нет");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.LightBlue);


            //Рисуем вершины (узлы)
            foreach (KeyValuePair<string, Point> kvp in nodePositions)
            {
                g.FillEllipse(brush, kvp.Value.X - 20, kvp.Value.Y - 20, 40, 40);
                g.DrawString(kvp.Key, this.Font, Brushes.Black, kvp.Value);
            }

            //Рисуем ребра (связи)
            foreach (Tuple<string, string> edge in edges)
            {
                Point start = nodePositions[edge.Item1];
                Point end = nodePositions[edge.Item2];
                g.DrawLine(pen, start, end);
            }

            pen.Dispose();
            brush.Dispose();
        }

        
    }
}
