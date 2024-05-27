public class SimpleGoal : Goal
{
    // Attributes 
    private bool _isComplete;

    // Constructor (name, description, points)
    // SimpleGoal (....) : base(...)
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }


    public override int RecordEvent()
    {
        // If we previously were not complete,
        // then mark complete and return points.
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        // What if we previously were complete?
        return 0;
    }

    public override bool IsComplete()
    {
        // Return back whether this goal is complete or not.
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }

    public override string GetStringOutput()
    {
        return $"{_shortName} ({_description})";
    }
}