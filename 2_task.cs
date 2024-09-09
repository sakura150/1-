using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;

/*numr1 - вещ. часть 1 числа , numr2 - вещ часть 2 числа, numi1 - мним. часть 1 числа , numi2 - мним часть 2 числа */
internal partial class Program
{
    static void AddN(int numr1, int numi1, int numr2, int numi2, out int num, out int numm)
    {
        num = numr1 + numr2;
        numm = numi1 + numi2;
    }
    static void SubN(int numr1, int numi1, int numr2, int numi2, out int num, out int numm)
    {
        num = numr1 - numr2;
        numm = numi1 - numi2;
    }
    static void MulN(int numr1, int numi1, int numr2, int numi2, out int num, out int numm)
    {
        num = numr1 * numr2 - numi1 * numi2;
        numm = numr1 * numi2 + numr2 * numi2;
    }

    static void DivN(int numr1, int numi1, int numr2, int numi2, out int num, out int numm)
    {
        num = (numr1 * numr2 + numi1 * numi2) / (numr2 * numr2 + numi2 * numi2);
        numm = (numr2 * numi1 - numr1 * numi2) / (numr2 * numr2 + numi2 * numi2);
    }


    static void ModandArgN(int numr, int numi, out double mod, out double arg)
    {
        mod = Math.Sqrt(numr * numr + numi * numi);
        if (numr == 0 && numi == 0) arg = 0;
        arg = Math.Atan2(numi, numr);
        if (arg < 0) arg += 2 * Math.PI;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("a - введение комплексного числа");
        Console.WriteLine("b - сложение");
        Console.WriteLine("c - вычитание");
        Console.WriteLine("d - умножение");
        Console.WriteLine("e - деление");
        Console.WriteLine("f - модуль и аргумент комплексного числа");
        Console.WriteLine("g - вывод вещ. и мним. частей комп. числа");
        Console.WriteLine("h - вывод результата");
        Console.WriteLine("Введите букву");
        char letter;
        letter = Console.ReadKey().KeyChar;
        int num1 = 0, num2 = 0;
        double mod = 0, arg = 0;
        while (letter != 'Q' && letter != 'q')
        {
            switch (letter)
            {
                case 'a':
                    Console.WriteLine( "Введите вещественную часть комплексного числа");
                    int n1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного числа");
                    int n2 = int.Parse(Console.ReadLine());
                    num1 = n1;
                    num2 = n2;
                    break;

                case 'b':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    int y1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int x2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int y2 = int.Parse(Console.ReadLine());
                    AddN(x1, y1, x2, y2, out num1, out num2);
                    break;

                case 'c':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int a1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    int b1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int a2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int b2 = int.Parse(Console.ReadLine());
                    SubN(a1, b1, a2, b2, out num1,out num2);
                    break;

                case 'd':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int c1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного1 числа");
                    int d1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int c2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int d2 = int.Parse(Console.ReadLine());
                    MulN(c1, d1, c2, d2, out num1, out num2);
                    break;
                case 'e':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int q1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    int w1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int q2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int w2 = int.Parse(Console.ReadLine());
                    DivN(q1, w1, q2, w2, out  num1, out num2);
                    break;

                case 'f':
                    Console.WriteLine("Введите вещественную часть комплексного числа");
                    int v1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного числа");
                    int v2 = int.Parse(Console.ReadLine());
                    num1 = v1;
                    num2 = v2;
                    ModandArgN(num1, num2, out mod,out arg);
                    break;

                case 'g':
                    Console.WriteLine($"Вещественное число : {num1}");
                    Console.WriteLine($"Мнимое число : {num2}");
                    break;
                case 'h':
                    Console.WriteLine(num1 + " + " + num2 + " *i; " + "модуль - " + mod + "; аргумент -   " + arg);
                    break;


                default: Console.WriteLine("Неизвестная буква");
                    break;
            }
            Console.WriteLine("Введите букву");
            letter = Console.ReadKey().KeyChar;
        }
    }
}
