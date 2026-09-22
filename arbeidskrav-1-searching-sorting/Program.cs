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
        
        Contact[] sortMe = phonebook.ToArray();
        Sorting.InsertionSort(sortMe, new ContactComparer(Field.LastName, SortOrder.Ascending), out int cmp, out int swp);
        Console.WriteLine(sortMe[0]);
        Console.WriteLine(sortMe[sortMe.Length - 1]);
        Console.WriteLine(cmp);
        Console.WriteLine(swp);
        
        Contact[] sortMe2 = phonebook.ToArray();
        Sorting.InsertionSort(sortMe2, new ContactComparer(Field.FirstName, SortOrder.Ascending), out int cmp2, out int swp2);
        Console.WriteLine(sortMe2[0]);
        Console.WriteLine(sortMe2[sortMe2.Length - 1]);
        Console.WriteLine(cmp2);
        Console.WriteLine(swp2);
        
        Contact[] sortMe3 = phonebook.ToArray();
        Sorting.InsertionSort(sortMe3, new ContactComparer(Field.Mobile, SortOrder.Ascending), out int cmp3, out int swp3);
        Console.WriteLine(sortMe3[0]);
        Console.WriteLine(sortMe3[sortMe3.Length - 1]);
        Console.WriteLine(cmp3);
        Console.WriteLine(swp3);
        
        Contact[] sortMe4 = phonebook.ToArray();
        Sorting.InsertionSort(sortMe4, new ContactComparer(Field.LastName, SortOrder.Descending), out int cmp4, out int swp4);
        Console.WriteLine(sortMe4[0]);
        Console.WriteLine(sortMe4[sortMe4.Length - 1]);
        
        Contact[] emptyArray = new Contact[0];
        Sorting.InsertionSort(emptyArray, new ContactComparer(Field.LastName, SortOrder.Ascending), out int cmpEmpty, out int swpEmpty);
        Console.WriteLine(emptyArray.Length);
        Console.WriteLine(cmpEmpty);

        Contact[] oneArray = { phonebook.GetContact(0) };
        Sorting.InsertionSort(oneArray, new ContactComparer(Field.LastName, SortOrder.Ascending), out int cmpOne, out int swpOne);
        Console.WriteLine(oneArray.Length);
        Console.WriteLine(oneArray[0]);
        Console.WriteLine(cmpOne);
    }
}