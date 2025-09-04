using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
         Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                break; 
            }

            numbers.Add(input);
        }

        // Core Requirements
        int sum = numbers.Sum();
        double average = numbers.Count > 0 ? numbers.Average() : 0;
        int max = numbers.Count > 0 ? numbers.Max() : 0;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average:F2}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge
        // Find the smallest positive number
        var positiveNumbers = numbers.Where(n => n > 0).ToList();
        if (positiveNumbers.Count > 0)
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Sort and display the numbers
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
