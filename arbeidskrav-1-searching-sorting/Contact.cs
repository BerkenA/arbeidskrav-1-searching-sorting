namespace arbeidskrav_1_searching_sorting;

/// <summary>
/// Holds the data for one contact from the phonebook. Can't be changed
/// after it's created.
/// </summary>
public class Contact
{
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly string _mobile;
    private readonly string _birthday;
    private readonly string _street;
    private readonly string _city;
    
    /// <summary>
    /// The contact's first name.
    /// </summary>
    public string FirstName
    {
        get { return _firstName; }
    }
    
    /// <summary>
    /// The contact's last name.
    /// </summary>
    public string LastName
    {
        get { return _lastName; }
    }
    
    /// <summary>
    /// The contact's mobile.
    /// </summary>
    public string Mobile
    {
        get { return _mobile; }
    }
    
    /// <summary>
    /// The contact's birthday.
    /// </summary>
    public string Birthday
    {
        get { return _birthday; }
    }
    
    /// <summary>
    /// The contact's street.
    /// </summary>
    public string Street
    {
        get { return _street; }
    }
    
    /// <summary>
    /// The contact's city.
    /// </summary>
    public string City
    {
        get { return _city; }
    }
    
    /// <summary>
    /// Builds a new Contact from the six values that come from one row of the CSV.
    /// </summary>
    public Contact (string firstName, string lastName, string mobile, string birthday, string street, string city)
    {
        _firstName = firstName;
        _lastName = lastName;
        _mobile = mobile;
        _birthday = birthday;
        _street = street;
        _city = city;
    }
    
    /// <summary>
    /// Gives back a readable line of text with the contact's info for printing.
    /// </summary>
    public override string ToString()
    {
        return $"{_firstName} {_lastName} {_mobile} {_birthday} {_street} {_city}";
    }
}