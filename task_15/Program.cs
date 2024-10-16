using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Runtime.Intrinsics.Arm;
namespace deque
{
    public class Programm
    {

        public static int CountF(string line)
        {
            int s = 0;
            string[] parts = line.Split(' ');
            foreach (string part in parts)
            {
                if (int.Parse(part) > 9 && int.Parse(part) < 100) s++;
            }
            return s;
        }
        public static int CountP(string line)
        {
            int s = 0;
            string[] parts = line.Split(' ');
            foreach (string part in parts)
            {
                if (part == " ") s++;
            }
            return s;
        }
        public static void Main(string[] args)
        {

            try { 
            string path1 = "input.txt";
            string path2 = "sorded.txt";

            
            MyArrayDeque<string> list = new MyArrayDeque<string>();

            int n = int.Parse(Console.ReadLine());

            string[] lines = File.ReadAllLines(path1);

                
            if (lines.Length > 0)
                { 
                    list.Add(lines[0]);
                    int s = CountF(lines[0]);
                 
                    for(int  i =0; i< lines.Length; i++)
                    {
                        int s1 = CountF(lines[i]);
                        int p1 = CountP(lines[i]);
                        string fileContent = File.ReadAllText(path2);

                        if(s1>s) File.WriteAllText(path2, fileContent + lines[i]);
                        else File.WriteAllText(path2, lines[i] + fileContent);

                        if (s1 > s && p1<n) list.AddLast(lines[i]);
                        else if (s1 < s && p1<n) list.AddFirst(lines[i]);

                        s = s1;
                    }
                }


              
            list.Print();
        }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }

        }
    }
}