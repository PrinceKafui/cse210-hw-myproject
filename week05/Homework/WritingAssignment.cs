using System;

public class WritingAssignment : Assignment
{
    // Unique member variable
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing information
    public string GetWritingInformation()
    {
        // use base class getter to access name
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}
