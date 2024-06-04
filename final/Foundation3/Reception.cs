public class Reception : Event
{
    private string _email;

    public Reception(string title, string description, string date, string time, Address address, string email)
        : base(title, description, date, time, address)
    {
        _email = email;
    }

    public override string FullDetails()
    {
        return $"Type: Reception \n{StandardDetails()} \nEmail: {_email}";
    }

    public override string ShortDescription()
    {
        return $"Reception - {_title} - {_date}";
    }
}