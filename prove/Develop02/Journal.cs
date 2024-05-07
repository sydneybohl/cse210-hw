using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Add a new journal entry with the correct prompt and the user response 
    public void AddAnEntry(string prompt)
    {
        Console.WriteLine(prompt); // To display prompt followed by a new line 
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        _entries.Add(new Entry(prompt, response, date));
    }

    // Display all journal entries when called 
    public void DisplayJournalEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display(); // Call Display method of entry class
        }
    }

    // Save the journal entries to a CSV file 
    public void SaveToFile()
    {
        Console.Write("Enter Filename: ");
        string filename = Console.ReadLine();


        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Write header line
            writer.WriteLine("Date|Prompt|Response");

            // Write each of the entries to the file 
            foreach (Entry entry in _entries)
            {
                // Used '|' as the separator to avoid issues with commas and quotes
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }

        }
    }

    // Load the journal entries from the CSV file 
    public void LoadFromFile()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear(); // Clear existing entries before loading

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    _entries.Add(new Entry(prompt, response, date));
                }
            }
        }

    }
}