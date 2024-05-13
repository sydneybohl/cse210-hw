using System;
// Added a library of scriptures, let it randomly select a scripture from the group to display.

class Program
{
    static void Main(string[] args)
    {
        // Create a library of scriptures 
        Library library = new Library();

        // Select a random scripture from the library 
        Scripture randomScripture = library.GetRandomScripture();

        // Loop until the user decides to quit
        while (true)
        {
            // Display the scripture
            Console.WriteLine(randomScripture.GetDisplayText());

            // Prompt the user to continue or quit
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            Console.Clear();

            // Check if the user wants to quit
            if (input.ToLower() == "quit")
                break;

            // Hide a few random words
            randomScripture.HideRandomWords(3); // Hide 3 words each time

            // Check if all words are hidden
            if (randomScripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congrats! All the words have been hidden.");
                break;
            }
        }
    }
}