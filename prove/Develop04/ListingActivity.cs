public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _count = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();

        List<string> userItems = GetListFromUser();

        _count = userItems.Count;
        Console.WriteLine($"You have listed {_count} items.");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine(prompt);
        Console.WriteLine("Start listing your items. Press Enter after each item. When you are done, just press Enter without typing anything.");

    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        string item;

        do
        {
            item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }
        while (!string.IsNullOrEmpty(item));

        return items;
    }
}