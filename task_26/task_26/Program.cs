using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace task_26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "input.txt";

            try
            {
                HashSet<string> set = new HashSet<string>(15);
                foreach (string line in File.ReadAllLines(filePath))
                {
                    MatchCollection matches = Regex.Matches(line, "[a-zA-Z]+");
                    foreach (Match match in matches)
                    {
                        set.Add(match.Value.ToLowerInvariant()); 
                    }
                }

                Console.WriteLine("Unique words:");
                string[] list = set.ToArray();
                foreach (string word in list)
                {
                    if(word != null) Console.WriteLine(word);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}