public class Customer
{
    private Address _address;
    private string _name;


    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public Address GetAddress()
    {
        return _address;
    }

    public string GetName()
    {
        return _name;
    }
}