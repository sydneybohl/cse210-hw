public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you fell when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind for the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(_duration);

        int currentPromptIndex = 0;
        int currentQuestionIndex = 0;

        // Display a prompt
        DisplayPrompt(_prompts[currentPromptIndex]);
        currentPromptIndex = (currentPromptIndex + 1) % _prompts.Count; // Increment and loop back to beginning if needed

        while (DateTime.Now < stopTime)
        {
            // Display a question
            DisplayQuestions(_questions[currentQuestionIndex]);
            currentQuestionIndex = (currentQuestionIndex + 1) % _questions.Count; // Increment and loop back to beginning if needed
        }

        DisplayEndingMessage();
    }

    // public string GetRandomPrompt()
    // {
    //     Random random = new Random();
    //     int index = random.Next(_prompts.Count);
    //     return _prompts[index];
    // }

    // public string GetRandomQuestion()
    // {
    //     Random random = new Random();
    //     int index = random.Next(_questions.Count);
    //     return _questions[index];
    // }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("Once you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions about your experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();
    }

    public void DisplayQuestions(string question)
    {
        Console.WriteLine(question);
        ShowSpinner(10);
    }
}