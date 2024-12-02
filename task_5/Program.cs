using System.IO;
using task_5;
internal partial class Program
{
    private static void Main(string[] args)
    {
        try
        {

            string path = "input.txt";

            task_5.MyArrayList<string> tags = new task_5.MyArrayList<string>();
          

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Поиск символа "<"
                    int startTagIndex = line.IndexOf('<');
                    while (startTagIndex != -1)
                    {
                        // Поиск символа ">"
                        int endTagIndex = line.IndexOf('>', startTagIndex);

                        // Извлечение тега
                        string tag = line.Substring(startTagIndex + 1, endTagIndex - startTagIndex - 1);

                        if (tag.Length >= 2 && (char.IsLetter(tag[1]) || (tag[1] == '/' && char.IsLetter(tag[2])))) ;
                        {
                            // Проверяем, что остальные символы являются буквами или числами
                            bool isValid = true;
                            for (int i = 2; i < tag.Length; i++)
                            {
                                if (!char.IsLetterOrDigit(tag[i]))
                                {
                                    isValid = false;
                                    break;
                                }
                            }


                            // Добавление тега в список, если его еще нет
                            if (!tags.Contains(tag) && isValid == true)
                            {
                                tags.Add(tag);
                            }

                        }
                        
                        // Переход к следующему символу "<"
                        startTagIndex = line.IndexOf('<', endTagIndex + 1);
                    }
                }
            }
            tags.Print();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
    }
}
