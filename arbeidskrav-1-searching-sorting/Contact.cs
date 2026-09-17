namespace arbeidskrav_1_searching_sorting;

public class Contact
{
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly string _mobile;
    private readonly string _birthday;
    private readonly string _street;
    private readonly string _city;
    
    public string FirstName
    {
        get { return _firstName; }
    }
    public string LastName
    {
        get { return _lastName; }
    }
    public string Mobile
    {
        get { return _mobile; }
    }
    public string Birthday
    {
        get { return _birthday; }
    }  
    public string Street
    {
        get { return _street; }
    }
    public string City
    {
        get { return _city; }
    }

    public Contact (string firstName, string lastName, string mobile, string birthday, string street, string city)
    {
        _firstName = firstName;
        _lastName = lastName;
        _mobile = mobile;
        _birthday = birthday;
        _street = street;
        _city = city;
    }
    
    public override string ToString()
    {
        return $"{_firstName} {_lastName} {_mobile} {_birthday} {_street} {_city}";
    }
}