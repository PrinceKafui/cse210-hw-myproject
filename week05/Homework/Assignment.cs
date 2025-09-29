using System;

public class Assignment
{
    // Private member variables
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Option 1: Provide getter methods (if you need access from derived classes)
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    // Option 2 (alternative): You could make these protected instead of private
    // protected string _studentName;
    // protected string _topic;
}
