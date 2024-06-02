public class Address
{
    private string _street;
    private string _city;
    private string _stateProv;
    private string _country;

    public Address(string street, string city, string stateProv, string country)
    {
        _street = street;
        _city = city;
        _stateProv = stateProv;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street} \n{_city}, {_stateProv}, {_country}";
    }
}