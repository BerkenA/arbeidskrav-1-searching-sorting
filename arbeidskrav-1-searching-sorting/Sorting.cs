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
    private static int _mergeComparisons;
    private static int _mergeSwaps;

    public static T[] CopyArray<T>(T[] source)
    {
        T[] copy = new T[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            copy[i] = source[i];
        }

        return copy;
    }
    
    public static void InsertionSort<T>(T[] items, IComparer<T> comparer, out int comparisons, out int swaps)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items), "The array to be sorted can't be null");
        }
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

    public static void MergeSort<T>(T[] items, IComparer<T> comparer, out int comparisons, out int swaps)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items), "The array to sort can't be null");
        }
        _mergeComparisons = 0;
        _mergeSwaps = 0;
        MergeSortRange(items, 0, items.Length -1, comparer);
        comparisons = _mergeComparisons;
        swaps = _mergeSwaps;
    }

    private static void MergeSortRange<T>(T[] items, int low, int high, IComparer<T> comparer)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSortRange(items, low, mid, comparer);
            MergeSortRange(items, mid +1, high, comparer);
            int leftIndex = low;
            int rightIndex = mid + 1;
            int tempIndex = 0;
            T[] temp = new T[high - low + 1];

            while (leftIndex <= mid && rightIndex <= high)
            {
                _mergeComparisons++;
                if (comparer.Compare(items[leftIndex], items[rightIndex]) <= 0)
                {
                    temp[tempIndex] = items[leftIndex];
                    _mergeSwaps++;
                    leftIndex++;
                }
                else
                {
                    temp[tempIndex] = items[rightIndex];
                    _mergeSwaps++;
                    rightIndex++;
                }

                tempIndex++;
            }

            while (leftIndex <= mid)
            {
                temp[tempIndex] = items[leftIndex];
                _mergeSwaps++;
                leftIndex++;
                tempIndex++;
            }

            while (rightIndex <= high)
            {
                temp[tempIndex] = items[rightIndex];
                _mergeSwaps++;
                rightIndex++;
                tempIndex++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                items[low + i] = temp[i];
            }
        }
    }
}