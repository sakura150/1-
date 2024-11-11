namespace Program
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            try
            {

                string path = "input.txt";

                
                MyHashMap<int, string> list = new MyHashMap<int, string>();

                int k = 1;
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int startTagIndex = line.IndexOf('<');
                        while (startTagIndex != -1)
                        {
                            int endTagIndex = line.IndexOf('>', startTagIndex);
                            string tag = line.Substring(startTagIndex + 1, endTagIndex - startTagIndex - 1);
                            if (tag.Length >= 2 && (char.IsLetter(tag[1]) || (tag[1] == '/' && char.IsLetter(tag[2]))));
                            {
                                bool isValid = true;
                                for (int i = 2; i < tag.Length; i++)
                                {
                                    if (!char.IsLetterOrDigit(tag[i]))
                                    {
                                        isValid = false;

                                        break;
                                    }
                                   
                                }
                                list.Put(k, tag);
                                k++;


                            }
                            startTagIndex = line.IndexOf('<', endTagIndex + 1);
                        }
                    }
                }
                IEnumerable<KeyValuePair<int, string>> pairs = list.EntrySet();
                int k1 = 1;
                foreach (var pair in pairs)
                {
                    Console.WriteLine(pair.Key + " " + pair.Value);
                    k1++;
                    if (k == k1) Console.WriteLine($"количество вхождений каждого тега: {pair.Key }");
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
        }
    }
}