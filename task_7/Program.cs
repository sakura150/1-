using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using task_6;

internal partial class Program
{
    private static void Main(string[] args)
    {
        try
        {
            string path1 = "input.txt";
            string path2 = "output.txt";
            task_6.MyVector<IPAddress> vector = new task_6.MyVector<IPAddress>();
            string[] lines = File.ReadAllLines(path1);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                foreach (string part in parts)
                {
                    if (IPAddress.TryParse(part, out IPAddress ipAddress))
                    {
                        if (!vector.Contains(ipAddress))
                        {
                            vector.Add(ipAddress);
                            using (StreamWriter writer = new StreamWriter(path2)) writer.WriteLine(ipAddress);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
    }
}