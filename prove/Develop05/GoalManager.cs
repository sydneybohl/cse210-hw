public class GoalManager
{
    // Attributes (private)
    private List<Goal> _goals;
    private int _score;
    private int _level;

    // Constructor - initializing the attributes 
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        // Display the main menu & display player info
        // Call:
        // CreateGoal, ListGoalDetails, SaveGoals, LoadGoals
        // RecordEvent, Exit 
        // Loop until quit 
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create Goal");
            Console.WriteLine("  2. List Goal Details");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Exit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                RecordEvent();
            }
            else if (choice == "4")
            {
                SaveGoals();
            }
            else if (choice == "5")
            {
                LoadGoals();
            }
            else if (choice == "6")
            {
                exit = true;
            }
        }

    }

    public void DisplayPlayerInfo()
    {
        // Display the points
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {_level}");

    }

    public void ListGoalNames()
    {
        // Loop through the list of goals and display
        // the names (YOU MAY NEED ANOTHER FUNCTION
        // IN THE GOAL CLASS)
        // 1. Go to bed on time 
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringOutput()}");
        }
    }

    public void ListGoalDetails()
    {
        // Loop through the list of goals and display
        // the full details 
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string status = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {_goals[i].GetStringOutput()}");
        }
    }

    public void CreateGoal()
    {
        // Display a sub-menu to select a goal name
        // Ask for the name, description, and points
        // Ask for more if they pick the checklist goal 
        // Create the object and add to the goal list
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }

        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

    }

    public void RecordEvent()
    {
        // Display a list of all of the goal names
        // Ask user to select a goal
        // Call RecordEvent on the correct goal 
        // Update the score based on the points \
        // Display current points 
        ListGoalNames();
        Console.Write("Select a goal to record an event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsAwarded = _goals[goalIndex].RecordEvent();
            _score += pointsAwarded;

            Console.WriteLine($"Congratulations! You have earned {pointsAwarded} points!");
            CheckLevelUp();
            Console.WriteLine($"You now have {_score} points.");

        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        // Ask user for a file name
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();
        // Loop through the goals and convert each
        // goal to a string and then save the string.
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");

    }

    public void LoadGoals()
    {
        // Ask user for a file name
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();
        // Read each line of the file and split it up
        // Use the parts to re-create the Goal object
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            foreach (var line in lines[1..])
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                string name = goalData[0];
                string description = goalData[1];
                int points = int.Parse(goalData[2]);

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(goalData[3]);
                    var simpleGoal = new SimpleGoal(name, description, points);
                    if (isComplete) simpleGoal.RecordEvent(); // Mark as complete if it was complete
                    _goals.Add(simpleGoal);
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(goalData[3]);
                    int bonus = int.Parse(goalData[4]);
                    int amountCompleted = int.Parse(goalData[5]);
                    var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    for (int i = 0; i < amountCompleted; i++) checklistGoal.RecordEvent(); // Mark progress
                    _goals.Add(checklistGoal);
                }
                else
                {
                    Console.WriteLine("Unknown goal type found in file.");
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = _score / 1000 + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You leveled up to level {_level}!");
        }
    }
}

