using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the base class
        Assignment a1 = new Assignment("Prince Kafui", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // Test MathAssignment
        MathAssignment m1 = new MathAssignment("Bella  Amexo", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine();

        // Test WritingAssignment
        WritingAssignment w1 = new WritingAssignment("Edem Amexo", "African History", "The problems of the continent");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
