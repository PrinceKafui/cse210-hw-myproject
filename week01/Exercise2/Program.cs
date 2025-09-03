using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");


           // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percent = int.Parse(input);

        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch: Determine the + or - sign
        int lastDigit = percent % 10;

        if (letter != "F") // F grades never get + or -
        {
            if (letter == "A" && percent >= 93)
            {
                // A+ does not exist, so only plain A or A-
                sign = "";
            }
            else if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Special case: No A+ allowed
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // Special case: No F+ or F-
        if (letter == "F")
        {
            sign = "";
        }

        // Display the letter grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Pass/fail message
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Don't worry, keep trying and you'll do better next time!");
        }
    }
}