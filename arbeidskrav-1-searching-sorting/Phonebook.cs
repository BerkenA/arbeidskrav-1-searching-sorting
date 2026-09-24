namespace arbeidskrav_1_searching_sorting;

public class Phonebook
{
    private readonly Contact[] _contacts;
    private int _comparisons;
    
    /// <summary>
    /// How many comparisons the last search made.
    /// </summary>
    public int Comparisons
    {
        get { return _comparisons; }
    }
    
    /// <summary>
    /// Constructor for building a Phonebook directly from an array of contacts.
    /// </summary>
    public Phonebook(Contact[] contacts)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts), "The contacts array cannot be null.");
        }
        _contacts = contacts;
    }
    
    /// <summary>
    /// How many contacts are in the phonebook.
    /// </summary>
    public int Count
    {
        get { return _contacts.Length; }
    }
    
    /// <summary>
    /// Gets the contact at a given index.
    /// </summary>
    public Contact GetContact(int index)
    {
        return _contacts[index];
    }
    
    /// <summary>
    /// Loads all contacts from a CSV file and builds a Phonebook from them.
    /// </summary>
    public static Phonebook Load(string csvPath)
    {
        if (!File.Exists(csvPath))
        {
            throw new FileNotFoundException("Could not find the phonebook CSV file at: " + csvPath);
        }

        string[] lines = File.ReadAllLines(csvPath);
        Contact[] contacts = new Contact[lines.Length - 1];
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            Contact contact = new Contact(parts[0], parts[1], parts[2],parts[3],parts[4], parts[5]);
            contacts[i - 1] = contact;
        }

        return new Phonebook(contacts);
    }

    /// <summary>
    /// Gets the value of a contact for whichever field is asked for
    /// (FirstName, LastName, or Mobile).
    /// </summary>
    public static string Key(Contact contact, Field field)
    {
        switch (field)
        {
            case Field.FirstName:
                return contact.FirstName;
            case Field.LastName:
                return contact.LastName;
            case Field.Mobile:
                return contact.Mobile;
            default:
                return "";
        }
    }

    /// <summary>
    /// Looks through every contact and finds the ones where the chosen field
    /// matches the target exactly, ignoring upper and lower case. Gives back
    /// an empty array if nothing matches. Has to check every contact every
    /// time, so it's O(n).
    /// </summary>
    public Contact[] LinearSearch(Field field, string target)
    {
        _comparisons = 0;
        List<Contact> matches = new List<Contact>();
        
        for (int i = 0; i < _contacts.Length; i++)
        {
            Contact current =  _contacts[i];
            _comparisons++;
            if (string.Equals(Key(current, field), target, StringComparison.OrdinalIgnoreCase))
            {
                matches.Add(current);
            }
        }
        return matches.ToArray();
    }

    /// <summary>
    /// Makes a copy of the contacts array so it can be sorted or changed
    /// without touching the original.
    /// </summary>
    public Contact[] ToArray()
    {
        Contact[] copy = new Contact[_contacts.Length];
        for (int i = 0; i < _contacts.Length; i++)
        {
            copy[i] = _contacts[i];
        }

        return copy;
    }

    /// <summary>
    /// Finds a contact by cutting the search area in half each time instead of
    /// checking one by one. Only works if the array is already sorted by the
    /// field you're searching on. If there are duplicates it finds the first
    /// one. Much faster than linear search, O(log n).
    /// </summary>
    public int BinarySearch(Field field, String target)
    {
        _comparisons = 0;
        int low = 0;
        int high = _contacts.Length - 1;
        int result_index = -1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            _comparisons++;
            int result = string.Compare(Key(_contacts[mid], field), target, StringComparison.OrdinalIgnoreCase);

            if (result == 0)
            {
                result_index = mid;
                high = mid - 1;
            }
            else if (result < 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return result_index;
    }
}