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
        
        int[] numbers2 = { 5, 2, 8, 1, 9, 3 };
        Sorting.MergeSort(numbers2, Comparer<int>.Default, out int cmp5, out int swp5);
        Console.WriteLine(string.Join(", ", numbers2));
        Console.WriteLine(cmp5);
        Console.WriteLine(swp5);
        
        Contact[] mSortMeLastName = phonebook.ToArray();
        Sorting.MergeSort(mSortMeLastName, new ContactComparer(Field.LastName, SortOrder.Ascending), out int mCmpLastName, out int mSwpLastName);
        Console.WriteLine(mSortMeLastName[0]);
        Console.WriteLine(mSortMeLastName[mSortMeLastName.Length - 1]);
        Console.WriteLine(mCmpLastName);
        Console.WriteLine(mSwpLastName);

        Contact[] mSortMeFirstName = phonebook.ToArray();
        Sorting.MergeSort(mSortMeFirstName, new ContactComparer(Field.FirstName, SortOrder.Ascending), out int mCmpFirstName, out int mSwpFirstName);
        Console.WriteLine(mSortMeFirstName[0]);
        Console.WriteLine(mSortMeFirstName[mSortMeFirstName.Length - 1]);
        Console.WriteLine(mCmpFirstName);
        Console.WriteLine(mSwpFirstName);

        Contact[] mSortMeMobile = phonebook.ToArray();
        Sorting.MergeSort(mSortMeMobile, new ContactComparer(Field.Mobile, SortOrder.Ascending), out int mCmpMobile, out int mSwpMobile);
        Console.WriteLine(mSortMeMobile[0]);
        Console.WriteLine(mSortMeMobile[mSortMeMobile.Length - 1]);
        Console.WriteLine(mCmpMobile);
        Console.WriteLine(mSwpMobile);

        Contact[] mSortMeLastNameDescending = phonebook.ToArray();
        Sorting.MergeSort(mSortMeLastNameDescending, new ContactComparer(Field.LastName, SortOrder.Descending), out int mCmpLastNameDescending, out int mSwpLastNameDescending);
        Console.WriteLine(mSortMeLastNameDescending[0]);
        Console.WriteLine(mSortMeLastNameDescending[mSortMeLastNameDescending.Length - 1]);

        Contact[] mEmptyArray = new Contact[0];
        Sorting.MergeSort(mEmptyArray, new ContactComparer(Field.LastName, SortOrder.Ascending), out int mCmpEmpty, out int mSwpEmpty);
        Console.WriteLine(mEmptyArray.Length);
        Console.WriteLine(mCmpEmpty);

        Contact[] mOneArray = { phonebook.GetContact(0) };
        Sorting.MergeSort(mOneArray, new ContactComparer(Field.LastName, SortOrder.Ascending), out int mCmpOne, out int mSwpOne);
        Console.WriteLine(mOneArray.Length);
        Console.WriteLine(mOneArray[0]);
        Console.WriteLine(mCmpOne);
        
        Contact[] asSupplied = phonebook.ToArray();

        Contact[] alreadySorted = phonebook.ToArray();
        Sorting.InsertionSort(alreadySorted, new ContactComparer(Field.LastName, SortOrder.Ascending), out _, out _);

        Contact[] reverseSorted = phonebook.ToArray();
        Sorting.InsertionSort(reverseSorted, new ContactComparer(Field.LastName, SortOrder.Descending), out _, out _);
        
        Contact[] benchIA = Sorting.CopyArray(asSupplied);
        Sorting.InsertionSort(benchIA, new ContactComparer(Field.LastName, SortOrder.Ascending), out int benchIAcmp, out int benchIAswp);
        Console.WriteLine("InsertionSort as-supplied: comparisons=" + benchIAcmp + " swaps=" + benchIAswp);
        
        Contact[] benchIB = Sorting.CopyArray(alreadySorted);
        Sorting.InsertionSort(benchIB, new ContactComparer(Field.LastName, SortOrder.Ascending), out int benchIBcmp, out int benchIBswp);
        Console.WriteLine("InsertionSort already-sorted: comparisons=" + benchIBcmp + " swaps=" + benchIBswp);

        Contact[] benchIC = Sorting.CopyArray(reverseSorted);
        Sorting.InsertionSort(benchIC, new ContactComparer(Field.LastName, SortOrder.Ascending), out int benchICcmp, out int benchICswp);
        Console.WriteLine("InsertionSort reverse-sorted: comparisons=" + benchICcmp + " swaps=" + benchICswp);

        Contact[] benchMA = Sorting.CopyArray(asSupplied);
        Sorting.MergeSort(benchMA, new ContactComparer(Field.LastName, SortOrder.Ascending), out int benchMAcmp, out int benchMAswp);
        Console.WriteLine("MergeSort as-supplied: comparisons=" + benchMAcmp + " swaps=" + benchMAswp);

        Contact[] benchMB = Sorting.CopyArray(alreadySorted);
        Sorting.MergeSort(benchMB, new ContactComparer(Field.LastName, SortOrder.Ascending), out int benchMBcmp, out int benchMBswp);
        Console.WriteLine("MergeSort already-sorted: comparisons=" + benchMBcmp + " swaps=" + benchMBswp);

        Contact[] benchMC = Sorting.CopyArray(reverseSorted);
        Sorting.MergeSort(benchMC, new ContactComparer(Field.LastName, SortOrder.Ascending), out int benchMCcmp, out int benchMCswp);
        Console.WriteLine("MergeSort reverse-sorted: comparisons=" + benchMCcmp + " swaps=" + benchMCswp);
    }
}