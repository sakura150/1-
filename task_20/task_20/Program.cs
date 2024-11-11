using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Transactions;


namespace Program
{
    public class Prog
    {
        public static void Main(string[] args)
        {
            try
            {
                string path = "input.txt";
                MyHashMap<string, string > list = new MyHashMap<string, string>();

                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');
                    string type = parts[0].Trim();
                    string valuable = parts[3].Trim();
                    string name = parts[1].Trim();

                    string val = $"{name}({valuable})";

                    if(type == "int" || type == "float" || type == "double")
                    {
                        if(list.ContainsKey(val)) Console.WriteLine("повтор");
                        else list.Put(type, val);
                        
                    }
                }

                IEnumerable<KeyValuePair<string, string>> pairs = list.EntrySet();
                foreach (var pair in pairs)
                {
                    
                    Console.WriteLine(pair.Key + " " + pair.Value);
                }
            }
            catch (Exception e)
            {
                
                    Console.WriteLine("Exception : " + e.Message);
                
            }
        }
    }

}