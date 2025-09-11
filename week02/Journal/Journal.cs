using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine("----- New Entry -----");
                outputFile.WriteLine($"Date: {entry.Date}");
                outputFile.WriteLine($"Prompt: {entry.PromptText}");
                outputFile.WriteLine($"Entry: {entry.EntryText}");
                outputFile.WriteLine(); // blank line between entries
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        string date = "";
        string prompt = "";
        string entryText = "";

        foreach (string line in lines)
        {
            if (line.StartsWith("Date:"))
                date = line.Substring(6).Trim();
            else if (line.StartsWith("Prompt:"))
                prompt = line.Substring(8).Trim();
            else if (line.StartsWith("Entry:"))
                entryText = line.Substring(7).Trim();
            else if (line.StartsWith("----- New Entry -----"))
                continue;
            else if (string.IsNullOrWhiteSpace(line) && date != "" && prompt != "" && entryText != "")
            {
                _entries.Add(new Entry(date, prompt, entryText));
                date = prompt = entryText = "";
            }
        }
    }
}
