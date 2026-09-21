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