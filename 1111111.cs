internal partial class Program
{
    private static void Main(string[] args)
    {
        try
        {

            string path = "1.txt"; 
            string[] lines = File.ReadAllLines(path); 

            int number = int.Parse(lines[0]);

            int[,] matrix = new int[number, number]; 

            
            for (int i = 0; i < number; i++)
            {
                string[] values = lines[i + 1].Split(' '); 
                for (int j = 0; j < number; j++)
                {
                    matrix[i, j] = int.Parse(values[j]); 
                }
            }

            
            int[] vector = lines[lines.Length - 1].Split(' ').Select(int.Parse).ToArray();


            Console.WriteLine(MultiplicationM(matrix, vector, number));
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
    }

   
    private static bool IsSimmetric(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] != matrix[j, i]) return false; 
            }
        }
        return true; 
    }

    
    private static double MultiplicationM(int[,] matrix, int[] vector, int n)
    {
        
        if (IsSimmetric(matrix, n) && n == vector.Length)
        {
            
            int[] vectorT = vector;
            
            for (int i = 0; i < vector.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < vector.Length; j++)
                {
                    s += vector[i] * matrix[j, i]; 
                }
                vector[i] = s;
            }
            int S = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                S += vector[i] * vectorT[i];
            }
            return Math.Sqrt(S);
        }
        else return 0; 
    }
}