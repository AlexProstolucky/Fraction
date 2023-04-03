using System;

public sealed class Fraction
{
    private int numerator;            
    private int denominator;           
    private int sign;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            Console.WriteLine("В знаменнику не може бути нуль");
        }
        this.numerator = Math.Abs(numerator);
        this.denominator = Math.Abs(denominator);
        if (numerator * denominator < 0)
        {
            this.sign = -1;
        }
    }
    public Fraction(int number) : this(number, 1) { }


    private static int getGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int buff = b;
            b = a % b;
            a = buff;
        }
        return a;
    }
    private static int getLeastCommonMultiple(int a, int b)
    {
        return a * b / getGreatestCommonDivisor(a, b);
    }

    public void Reduce()
    {
            while (numerator >= denominator)
            {
                numerator -= denominator;
                sign++;
            }

            int buff = getGreatestCommonDivisor(numerator, denominator);
            numerator /= buff;
            denominator /= buff;
    }
    public override string ToString()
    {
        string result = "";
        if (this.numerator == this.denominator)
        {
            return result + "1";
        }
        if (this.sign == 0 && this.numerator == this.denominator) return result = "0";
        else if (this.numerator == 0) return result = result += Convert.ToString(this.sign);
        if (this.sign > 0)
        {
            result += Convert.ToString(this.sign);
            return result + " " + this.numerator + "/" + this.denominator;
        }
        else if (this.sign < 0)
        {
            result += "-";
            return result + " " + this.numerator + "/" + this.denominator;
        }
        else
        {
            return result + this.numerator + "/" + this.denominator;
        }
    }
    
    // Додавання
    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator);  
    }
    public static Fraction operator +(Fraction a, int b)
    {
        return a + new Fraction(b);
    }
    public static Fraction operator +(int a, Fraction b)
    {
        return b + a;
    }


    // Віднімання 
    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator);
    }
    // Віднімання числа від дріба
    public static Fraction operator -(Fraction a, int b)
    {
        return a - new Fraction(b);
    }
    // Віднімання дроба від числа
    public static Fraction operator -(int a, Fraction b)
    {
        return b - a;
    }

    // Множення
    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
    }
    // Множення дроба на число
    public static Fraction operator *(Fraction a, int b)
    {
        return a * new Fraction(b);
    }
    // Множення число на дріб
    public static Fraction operator *(int a, Fraction b)
    {
        return b * a;
    }

    // Ділення
    public static Fraction operator /(Fraction a, Fraction b)
    {
        return a * new Fraction(b.denominator,b.numerator);
    }

    // Ділення дроба на число
    public static Fraction operator /(Fraction a, int b)
    {
        return a / new Fraction(b);
    }
    // Ділення число на дріб
    public static Fraction operator /(int a, Fraction b)
    {
        return new Fraction(a) / b;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        int n1, d1, n2, d2;
        Console.WriteLine("Уведіть чисельник у наступний рядок для першого дроба:");
        n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Уведіть знаменник у наступний рядок для першого дроба:");
        d1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Уведіть чисельник у наступний рядок для другого дроба:");
        n2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Уведіть знаменик у наступний рядок для другого дроба:");
        d2 = Convert.ToInt32(Console.ReadLine());
        Fraction a = new Fraction(n1,d1);
        Fraction b = new Fraction(n2,d2);
        Fraction plus = a + b;
        Fraction minus = a - b;
        Fraction multiply = a * b;
        Fraction division = a / b;
        Console.WriteLine($"Результат додавання, віднімання, множення та ділення дробів {a.ToString()} та {b.ToString()}:");
        Console.WriteLine($"Результат додавання: {plus.ToString()}");
        Console.WriteLine($"Результат віднімання: {minus.ToString()}");
        Console.WriteLine($"Результат множення: {multiply.ToString()}");
        Console.WriteLine($"Результат ділення: {division.ToString()}");
        a.Reduce();
        b.Reduce();
        plus.Reduce();
        minus.Reduce();
        multiply.Reduce();
        division.Reduce();
        Console.WriteLine($"\n\nРезультат додавання, віднімання, множення та ділення дробів зі скороченням {a.ToString()} та {b.ToString()}:");
        Console.WriteLine($"Результат додавання: {plus.ToString()}");
        Console.WriteLine($"Результат віднімання: {minus.ToString()}");
        Console.WriteLine($"Результат множення: {multiply.ToString()}");
        Console.WriteLine($"Результат ділення: {division.ToString()}");
    }
}