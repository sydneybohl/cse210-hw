using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        Random random = new Random(); // Create Random object outside the loop

        // List of prompts for the journal entries 
        List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today? ",
                "Write about a book, movie, or piece of art that inspired you recently. What resonated with you? ",
                "How did I see the hand of the Lord in my life today? ",
                "What was the most meaningful spiritual experience you had today? ",
                "What is a quote, talk, or scripture that has stood out to you recently? ",
                "Reflect on a recent mistake or failure. What did you learn from it? ",
                "What was the best moment of your day and why? ",
                "Write about a small act of kindness you witnessed or experienced today. ",
                "List three things you are grateful for today and explain why they are important to you. ",
                "Write about a time where you received an answer to your prayer. ",
                "Write about a goal you have for the future. What steps are you taking to achieve it? ",
                "What is a skill or talent of yours that you would like to develop further? How do you plan on growing that skill or talent? ",
                "What is a recent accomplishment or achievement you experienced? How did it make you feel? ",
                "What is one way you can become more like Christ? "

            };

        bool quit = false;
        while (!quit)
        {
            // Display the menu options 
            Console.WriteLine();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            // Ask the user for their choice 
            Console.WriteLine();
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Count)]; // Select random prompt
                    myJournal.AddAnEntry(prompt);
                    break;
                case "2":
                    myJournal.DisplayJournalEntries();
                    break;
                case "3":
                    myJournal.SaveToFile();
                    break;
                case "4":
                    myJournal.LoadFromFile();
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a number listed.");
                    break;
            }
        }
    }

}
