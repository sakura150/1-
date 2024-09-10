using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;



internal partial class Program
{
static void ModandArgN(int numreal, int numimaginary, out double modul, out double argument)
{
    modul = Math.Sqrt(numreal * numreal + numimaginary * numimaginary);
    if (numreal == 0 && numimaginary == 0) argument = 0;
    argument = Math.Atan2(numimaginary, numreal);
    if (argument < 0) argument += 2 * Math.PI;
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
        int numr = 0, numi = 0;
        double mod = 0, arg = 0;
        Complex prod;
        Complex x1, x2;
        int real, imag;
        int real1, imag1, real2, imag2;
        while (letter != 'Q' && letter != 'q')
        {
            switch (letter)
            {
                case 'a':
                    Console.WriteLine( "Введите вещественную часть комплексного числа");
                    real= int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного числа");
                    imag = int.Parse(Console.ReadLine());
                    prod = new Complex(real, imag);
                    numr = prod.R;
                    numi = prod.I;
                    break;

                case 'b':
                    numr = 0;
                    numi = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    real1= int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    imag1 = int.Parse(Console.ReadLine());
                    x1= new Complex(real1, imag1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    real2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    imag2 = int.Parse(Console.ReadLine());
                    x2= new Complex(real2, imag2);
                    prod = x1 + x2;
                    numr = prod.R;
                    numi = prod.I;
                    break;

                case 'c':
                    numr = 0;
                    numi = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    real1= int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    imag1 = int.Parse(Console.ReadLine());
                    x1= new Complex(real1, imag1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    real2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    imag2 = int.Parse(Console.ReadLine());
                    x2= new Complex(real2, imag2);
                    prod = x1-x2;
                    numr = prod.R;
                    numi = prod.I;
                    break;

                case 'd':
                    numr = 0;
                    numi = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    real1= int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного1 числа");
                    imag1 = int.Parse(Console.ReadLine());
                    x1= new Complex(real1, imag1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    real2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    imag2 = int.Parse(Console.ReadLine());
                    x2= new Complex(real2, imag2);
                    prod = x2 * x1;
                    numr = prod.R;
                    numi = prod.I;
                    break;
                case 'e':
                    numr = 0;
                    numi = 0;
                    Console.WriteLine("Введите вещественную часть комплексного 1 числа");
                    real1= int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 1 числа");
                    imag1 = int.Parse(Console.ReadLine());
                    x1= new Complex(real1, imag1);
                    Console.WriteLine("Введите вещественную часть комплексного 2 числа");
                    real2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного 2 числа");
                    imag2 = int.Parse(Console.ReadLine());
                    x2= new Complex(real2, imag2);
                    prod = x1 / x2;
                    numr = prod.R;
                    numi = prod.I;
                    break;

                case 'f':
                    Console.WriteLine("Введите вещественную часть комплексного числа");
                    real = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите мнимую часть комплексного числа");
                    imag = int.Parse(Console.ReadLine());
                    prod= new Complex(real, imag);

                    numr = real;
                    numi = imag;
                    ModandArgN(numr, numi, out mod,out arg);
                    break;

                case 'g':
                    
                    Console.WriteLine($"Вещественное число : {numr}");
                    Console.WriteLine($"Мнимое число : {numi}");
                    break;
                case 'h':
                Complex ff1;
                    Console.WriteLine(numr+ "+ "+ numi +"*i; " +"модуль - " + mod + "; аргумент -   " + arg);
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
    public int R;
    public int I;
    public Complex(int real, int b)
    {
        R = real;
        I = imaginary;
    }

    public static Complex operator +(Complex x1, Complex x2)
    {
        return new Complex(x1.R + x2.R, x1.I + x2.I);
    }
    public static Complex operator -(Complex x1, Complex x2)
    {
        return new Complex(x1.R - x2.R, x1.I - x2.I);
    }
    public static Complex operator *(Complex x1, Complex x2)
    {
        return new Complex(x1.R* x2.R - x1.I * x2.I, x1.R * x2.I + x1.I * x2.R);
    }
    public static Complex operator /(Complex x1, Complex x2)
    {
        return new Complex((x1.R * x2.R + x1.I * x2.I) / (x2.R * x2.R + x2.I * x2.I),
            (x2.R * x1.I - x1.R * x2.I) / (x2.R * x2.R + x2.I * x2.I));

    }
}

