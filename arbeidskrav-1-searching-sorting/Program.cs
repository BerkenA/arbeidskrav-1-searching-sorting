namespace arbeidskrav_1_searching_sorting;

class Program
{
    static void Main(string[] args)
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");
        Console.WriteLine(phonebook.Count);
        Console.WriteLine(phonebook.GetContact(0));
        Console.WriteLine(phonebook.GetContact(phonebook.Count - 1));
        Contact[] results = phonebook.LinearSearch(Field.LastName, "Bjerke");
        Console.WriteLine(results.Length);
        Console.WriteLine(phonebook.Comparisons);
        Contact[] results1 = phonebook.LinearSearch(Field.LastName, "Hansen");
        Console.WriteLine(results1.Length);
        Console.WriteLine(phonebook.Comparisons);
        Contact[] results2 = phonebook.LinearSearch(Field.LastName, "Rønning");
        Console.WriteLine(results2.Length);
        Console.WriteLine(phonebook.Comparisons);
        Contact[] results3 = phonebook.LinearSearch(Field.Mobile, "12345678");
        Console.WriteLine(results3.Length);
        Console.WriteLine(phonebook.Comparisons);
    }
}