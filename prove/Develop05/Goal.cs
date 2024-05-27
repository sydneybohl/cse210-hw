public abstract class Goal
{
    // Attributes (protected)
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor (name, description, points)
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return "";
    }

    public abstract string GetStringRepresentation();

    public abstract string GetStringOutput();
}