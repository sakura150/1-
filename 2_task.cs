using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;




internal partial class Program
{
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
        Complex prod;
        while (letter != 'Q' && letter != 'q')
        {
            switch (letter)
            {
                case 'a':
                    Console.WriteLine( "Введите вещественную часть комплексного числа");
                    int n1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного числа");
                    int n2 = int.Parse(Console.ReadLine());
                    Complex c = new Complex(n1, n2);
                    num1 = c.A;
                    num2 = c.B;
                    break;

                case 'b':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    int y1 = int.Parse(Console.ReadLine());
                    Complex c1 = new Complex(x1, y1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int x2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int y2 = int.Parse(Console.ReadLine());
                    Complex c2 = new Complex(x2, y2);
                    prod = c1 + c2;
                    num1 = prod.A;
                    num2 = prod.B;
                    break;

                case 'c':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int a1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    int b1 = int.Parse(Console.ReadLine());
                    Complex q1 = new Complex(a1, b1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int a2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int b2 = int.Parse(Console.ReadLine());
                    Complex q2 = new Complex(a2, b2);
                    prod = q1 - q2;
                    num1 = prod.A;
                    num2 = prod.B;
                    break;

                case 'd':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int e1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного1 числа");
                    int d1 = int.Parse(Console.ReadLine());
                    Complex w1 = new Complex(e1, d1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int e2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int d2 = int.Parse(Console.ReadLine());
                    Complex w2 = new Complex(e2, d2);
                    prod = w2 * w1;
                    num1 = prod.A;
                    num2 = prod.B;
                    break;
                case 'e':
                    num1 = 0;
                    num2 = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    int u1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    int i1 = int.Parse(Console.ReadLine());
                    Complex o1 = new Complex(u1, i1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    int u2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    int i2 = int.Parse(Console.ReadLine());
                    Complex o2 = new Complex(u2, i2);
                    prod = o1 / o2;
                    num1 = prod.A;
                    num2 = prod.B;
                    break;

                case 'f':
                    Console.WriteLine("Введите вещественную часть комплексного числа");
                    int v1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного числа");
                    int v2 = int.Parse(Console.ReadLine());
                    Complex p = new Complex(v1, v2);

                    num1 = v1;
                    num2 = v2;
                    ModandArgN(num1, num2, out mod,out arg);
                    break;

                case 'g':
                    
                    Console.WriteLine($"Вещественное число : {num1}");
                    Console.WriteLine($"Мнимое число : {num2}");
                    break;
                case 'h':
                Complex ff1;
                    Console.WriteLine(num1+ "+ "+ num2 +"*i; " +"модуль - " + mod + "; аргумент -   " + arg);
                    break;


                default: Console.WriteLine("Неизвестная буква");
                    break;
            }
            Console.WriteLine("Введите букву");
            letter = Console.ReadKey().KeyChar;
        }
    }
}

public struct Complex
{
    public int A;
    public int B;
    public Complex(int a, int b)
    {
        A = a;
        B = b;
    }

    public static Complex operator +(Complex x1, Complex x2)
    {
        return new Complex(x1.A + x2.A, x1.B + x2.B);
    }
    public static Complex operator -(Complex x1, Complex x2)
    {
        return new Complex(x1.A - x2.A, x1.B - x2.B);
    }
    public static Complex operator *(Complex x1, Complex x2)
    {
        return new Complex(x1.A * x2.A - x1.B * x2.B, x1.A * x2.B + x1.B * x2.A);
    }
    public static Complex operator /(Complex x1, Complex x2)
    {
        return new Complex((x1.A * x2.A + x1.B * x2.B) / (x2.A * x2.A + x2.B * x2.B),
            (x2.A * x1.B - x1.A * x2.B) / (x2.A * x2.A + x2.B * x2.B));

    }
}

