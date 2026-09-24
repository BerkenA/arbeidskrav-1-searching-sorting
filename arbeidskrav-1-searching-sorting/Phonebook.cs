namespace arbeidskrav_1_searching_sorting;

public class Phonebook
{
    private readonly Contact[] _contacts;
    private int _comparisons;
    public int Comparisons
    {
        get { return _comparisons; }
    }
    public Phonebook(Contact[] contacts)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts), "The contacts array cannot be null.");
        }
        _contacts = contacts;
    }
    public int Count
    {
        get { return _contacts.Length; }
    }
    public Contact GetContact(int index)
    {
        return _contacts[index];
    }
    
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

    public Contact[] ToArray()
    {
        Contact[] copy = new Contact[_contacts.Length];
        for (int i = 0; i < _contacts.Length; i++)
        {
            copy[i] = _contacts[i];
        }

        return copy;
    }

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