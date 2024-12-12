using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_29
{
    public class Kosaraju
    {
        //Поиск компонент сильной связности. Алгоритм Косарайю.
        private int V; // Количество вершин
        private List<List<int>> graph; // Граф, представленный списком смежности
        private List<List<int>> reversedGraph; // Обращенный граф

        public Kosaraju(int V)
        {
            this.V = V;
            graph = new List<List<int>>(V);
            reversedGraph = new List<List<int>>(V);
            for (int i = 0; i < V; i++)
            {
                graph.Add(new List<int>());
                reversedGraph.Add(new List<int>());
            }
        }

        // Добавление ребра
        public void AddEdge(int v, int w)
        {
            graph[v].Add(w);
            reversedGraph[w].Add(v); // Добавление ребра в обратный граф
        }

        // Обход в глубину
        private void DFS1(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;
            foreach (int neighbor in graph[v])
            {
                if (!visited[neighbor])
                {
                    DFS1(neighbor, visited, stack);
                }
            }
            stack.Push(v);
        }

        // Второй обход в глубину (на обращенном графе)
        private void DFS2(int v, bool[] visited, List<int> component)
        {
            visited[v] = true;
            component.Add(v);
            foreach (int neighbor in reversedGraph[v])
            {
                if (!visited[neighbor])
                {
                    DFS2(neighbor, visited, component);
                }
            }
        }

        // Нахождение сильно связных компонент
        public List<List<int>> GetStronglyConnectedComponents()
        {
            bool[] visited = new bool[V]; // Массив для первого обхода
            Stack<int> stack = new Stack<int>();

            // Первый обход в глубину
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    DFS1(i, visited, stack);
                }
            }

            visited = new bool[V]; // Создаём НОВЫЙ массив для второго обхода!!!
            List<List<int>> stronglyConnectedComponents = new List<List<int>>();

            // Второй обход в глубину на обращенном графе
            while (stack.Count > 0)
            {
                int v = stack.Pop();
                if (!visited[v])
                {
                    List<int> component = new List<int>();
                    DFS2(v, visited, component);
                    stronglyConnectedComponents.Add(component);
                }
            }

            return stronglyConnectedComponents;
        }


    }
    public class EdmondsKarp
    {
        public static int MaxFlow(int[,] capacity, int source, int sink)
        {
            int n = capacity.GetLength(0);
            int[,] flow = new int[n, n]; // Матрица потоков
            int maxFlow = 0;

            while (true)
            {
                // Поиск увеличивающего пути с помощью поиска в ширину (BFS)
                int[] parent = new int[n];
                for (int i = 0; i < n; i++) { parent[i] = -1; } // Замена Array.Fill
                Queue<int> q = new Queue<int>();
                q.Enqueue(source);
                parent[source] = -2; // Отметка источника

                while (q.Count > 0)
                {
                    int u = q.Dequeue();
                    for (int v = 0; v < n; v++)
                    {
                        if (parent[v] == -1 && capacity[u, v] - flow[u, v] > 0)
                        {
                            parent[v] = u;
                            q.Enqueue(v);
                            if (v == sink) break;
                        }
                    }
                    if (parent[sink] != -1) break;
                }

                // Если увеличивающий путь не найден, то алгоритм завершен
                if (parent[sink] == -1) break;

                // Нахождение минимальной остаточной емкости на пути
                int pathFlow = int.MaxValue;
                for (int v = sink; v != source; v = parent[v])
                {
                    int u = parent[v];
                    pathFlow = Math.Min(pathFlow, capacity[u, v] - flow[u, v]);
                }

                // Обновление потоков
                for (int v = sink; v != source; v = parent[v])
                {
                    int u = parent[v];
                    flow[u, v] += pathFlow;
                    flow[v, u] -= pathFlow; // Обратный поток
                }

                maxFlow += pathFlow;
            }

            return maxFlow;
        }
    }
    public class MaximumCliqueBruteForce
    {
        private bool[,] adjacencyMatrix;
        private int numVertices;
        private List<int> maxClique = new List<int>();

        public MaximumCliqueBruteForce(bool[,] adjacencyMatrix)
        {
            this.adjacencyMatrix = adjacencyMatrix;
            this.numVertices = adjacencyMatrix.GetLength(0);
        }

        // Проверка, является ли подмножество вершин кликой
        private bool isClique(List<int> subset)
        {
            if (subset.Count < 2) return true; // Одноэлементное множество - клика
            for (int i = 0; i < subset.Count; i++)
            {
                for (int j = i + 1; j < subset.Count; j++)
                {
                    if (!adjacencyMatrix[subset[i], subset[j]]) return false; // Нет ребра - не клика
                }
            }
            return true;
        }

        // Рекурсивный перебор всех подмножеств вершин
        private void findMaxCliqueRecursive(List<int> currentClique, int startIndex)
        {
            if (isClique(currentClique))
            {
                if (currentClique.Count > maxClique.Count)
                {
                    maxClique = new List<int>(currentClique); // Копируем, чтобы не изменять исходный список
                }
            }

            for (int i = startIndex; i < numVertices; i++)
            {
                List<int> nextClique = new List<int>(currentClique);
                nextClique.Add(i);
                findMaxCliqueRecursive(nextClique, i + 1);
            }
        }

        // Нахождение максимальной клики
        public List<int> findMaxClique()
        {
            findMaxCliqueRecursive(new List<int>(), 0);
            return maxClique;
        }
    }
}
