public abstract class Activity
{
    protected string _date;
    protected double _minutes;

    public Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min) - " +
            $"Distance: {GetDistance():0.00} miles, Speed: {GetSpeed():0.00} mph, " +
            $"Pace: {GetPace():0.00} min per mile";
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();
}