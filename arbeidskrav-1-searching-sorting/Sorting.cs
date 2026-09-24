namespace arbeidskrav_1_searching_sorting;

/// <summary>
/// Compares two contacts based on a chosen field and sort order, so
/// sorting algorithms know how to put them in order.
/// </summary>
public class ContactComparer : IComparer<Contact>
{
    private readonly Field _field;
    private readonly SortOrder _sortOrder;

    /// <summary>
    /// Constructor for setting which field and order to sort by.
    /// </summary>
    public ContactComparer(Field field, SortOrder sortOrder)
    {
        _field = field;
        _sortOrder = sortOrder;
    }
    
    /// <summary>
    /// Compares two contacts based on the field and order set in the constructor.
    /// </summary>
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

    /// <summary>
    /// Makes a copy of any array so it can be sorted without changing the original.
    /// </summary>
    public static T[] CopyArray<T>(T[] source)
    {
        T[] copy = new T[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            copy[i] = source[i];
        }

        return copy;
    }
    
    /// <summary>
    /// Sorts items in place using insertion sort. Goes through the array one element
    /// at a time and slides it backward into the right spot among the elements
    /// already sorted. Best case is O(n) when the data is already sorted, worst
    /// case is O(n²) when it's reverse sorted. Doesn't need any extra space.
    /// </summary>
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

    /// <summary>
    /// Sorts items in place using merge sort. Splits the array in half over and
    /// over until each piece has one element, then merges the pieces back together
    /// in order. Always O(n log n), no matter how the data is sorted to start with.
    /// Needs a temporary array the same size as the input while merging.
    /// </summary>
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