using q;
using System;
using System.Diagnostics;
public class Program
{
    public class Priotiry : IComparable<Priotiry>
    {
        public int Number { get; set; }
        public int Priot { get; set; }
        public int Step { get; set; }

        public Priotiry(int number, int priot, int step)
        {
            Number = number;
            Priot = priot;
            Step = step;
        }
        public int CompareTo(Priotiry other)
        {
            if(Priot !=  other.Priot) return Priot.CompareTo(other.Priot);
            else return Number.CompareTo(other.Number);
        }
    }
    public static void Main(string[] args)
    {

        string path = "log.txt";

        q.MyPriorityQueue<Priotiry> list = new q.MyPriorityQueue<Priotiry>();
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int k = 0;

        Stopwatch stopwatch = Stopwatch.StartNew();

        //создание очереди из заявок и шагов
        for (int i = 0; i < n; i++)
        {
            Random random = new Random();
            int numr = random.Next(1, 11);
            
            for (int j = 0; j < numr; j++)
            {
                int rrnum = random.Next(1, 6);
                Priotiry numm = new Priotiry(rrnum, j, i);
                list.Add(numm);
                k++;
            }
            
        }
       
        using (StreamWriter writer = new StreamWriter(path))
        {
            for (int i = 0; i < k; i++)
            {
                Priotiry priot = list.Peek();
                writer.WriteLine(priot.Number + " " + priot.Priot + " "+ priot.Step);
                if (i == --k) Console.WriteLine(priot.Number + " " + priot.Priot + " " + priot.Step);

                list.Remove(list.Peek());

            }
        }
        
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine($"Время выполнения: {elapsedTime}");


    }
}