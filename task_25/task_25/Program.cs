namespace task_25
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            MyHashSet<string> set = new MyHashSet<string>();
            string path = "input.txt";
            foreach (string lin in File.ReadLines(path))
            {
                string[] line = lin.Split(' ');
                int min = line[0].Length;
                int count1 = line.Length;
                foreach (string word in line) if (min > word.Length) min = word.Length;
                int min2 = line[0].Length;
                foreach (string lin1 in File.ReadLines(path))
                {
                    string[] line2 = lin1.Split(' ');
                    int count2 = line2.Length;
                    foreach (string word in line2) if (min2 > word.Length) min2 = word.Length;
                    if (min2 < min && count1 < count2) set.Add(lin1);
                    else set.Add(lin);

                }
            }
            string[] array = set.ToArray();
            foreach (string word in array)
            {
                Console.WriteLine(word);
            }
        }
    }
}