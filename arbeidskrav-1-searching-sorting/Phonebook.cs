namespace arbeidskrav_1_searching_sorting;

public class Phonebook
{
    private readonly Contact[] _contacts;
    public Phonebook(Contact[] contacts)
    {
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

    string Key(Contact contact, Field field)
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
}