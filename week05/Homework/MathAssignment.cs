using System;

public class MathAssignment : Assignment
{
    // Unique member variables
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic) // call base constructor
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method to display homework list
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
