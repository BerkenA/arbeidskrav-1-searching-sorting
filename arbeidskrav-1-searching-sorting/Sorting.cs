namespace arbeidskrav_1_searching_sorting;

public class ContactComparer : IComparer<Contact>
{
    private readonly Field _field;
    private readonly SortOrder _sortOrder;

    public ContactComparer(Field field, SortOrder sortOrder)
    {
        _field = field;
        _sortOrder = sortOrder;
    }
    public int Compare(Contact x, Contact y)
    {
        int result = string.Compare(Phonebook.Key(x, _field), Phonebook.Key(y,_field), StringComparison.OrdinalIgnoreCase);
        if (_sortOrder == SortOrder.Descending)
        {
           result = -result;
        }
        return result;
    }
}

public static class Sorting
{
    public static void InsertionSort<T>(T[] items, IComparer<T> comparer, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;
        int n = items.Length;
        for (int i = 1; i < n; i++)
        {
            int j = i - 1;
            T current = items[i];
            while (j >= 0)
            {
                comparisons++;
                if (comparer.Compare(items[j], current) <= 0)
                {
                    break;
                }
                items[j + 1] = items[j];
                swaps++;
                j--;
            }
            items[j + 1] = current;
        }
    }
}