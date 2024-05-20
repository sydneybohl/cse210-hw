public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(_duration);

        do
        {
            // Have the user breathe in for 5 seconds
            Console.Write("Breathe in...");
            ShowCountdown(5);
            Console.WriteLine();
            // Have the user breathe out for 5 seconds
            Console.Write("Breathe out...");
            ShowCountdown(5);
            Console.WriteLine();
        }
        while (DateTime.Now < stopTime);

        DisplayEndingMessage();
    }
}