public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }


    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        // Return back whether this goal is complete or not.
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }

    public override string GetStringOutput()
    {
        return $"{_shortName} ({_description})";
    }
}