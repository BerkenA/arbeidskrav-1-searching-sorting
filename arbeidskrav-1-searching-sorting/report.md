# Searching and Sorting: Report

Replace every bracketed prompt with your own work. Delete this line and any
prompt you have answered. **The finished report must be no more than two pages
of data and your own reflection.** Padding counts against you.

|      |                             |
|------|-----------------------------|
| Name | Berken Ates                 |
| Date | 24.09.2026                  |
| Data | phonebook.csv, 200 contacts |

---

## 1. Searching unsorted data

| Field    | Target   | Case         | Matches | Comparisons |
|----------|----------|--------------|---------|-------------|
| LastName | Bjerke   | Best case    | 9       | 200         |
| LastName | Hansen   | Worst case   | 7       | 200         |
| LastName | Rønning  | absent value | 0       | 200         |
| Mobile   | 12345678 | absent value | 0       | 200         |

**Reflection.**
Every one of my four searches needed exactly 200 comparisons regardless of target position.
Even though a match is found in the first spot as is with Bjerke, there is still a possibility
of more people sharing that last name somewhere else in the array. Because of this the search has to loop over the
entire array regardless of whether it finds 9 matches or none.


## 2. Sorting

| Algorithm     | Input shape    | Comparisons | Swaps or moves |
|---------------|----------------|-------------|----------------|
| InsertionSort | as supplied    | 9691        | 9494           |
| InsertionSort | already sorted | 199         | 0              |
| InsertionSort | reverse sorted | 19571       | 19411          |
| MergeSort     | as supplied    | 1282        | 1544           |
| MergeSort     | already sorted | 812         | 1544           |
| MergeSort     | reverse sorted | 890         | 1544           |

**Reflection.**
All six sorting runs showed MergeSort doing less work than InsertionSort — clearest
on the as-supplied data, where MergeSort needed only 1282 comparisons against
InsertionSort's 9691. InsertionSort swung wildly with input order: 199 comparisons
on already-sorted data, 19571 on reverse-sorted, matching its O(n) best and O(n²)
worst case. MergeSort barely moved (812 to 1282) regardless of shape, fitting its
O(n log n) behavior, and its swap count stayed exactly 1544 every time, since every
element is written into the buffer once per merge level no matter the starting order.

## 3. Searching sorted data

| Field     | Target   | Result      | Comparisons |
|-----------|----------|-------------|-------------|
| LastName  | Bjerke   | index 29    | 8           |
| LastName  | Rønning  | -1          | 8           |
| Mobile    | 97756218 | index   179 | 8           |
| FirstName | Julie    | index    75 | 7           |

Linear search on the same targets, for comparison:

| Target   | Comparisons (linear) | Comparisons (binary) |
|----------|----------------------|----------------------|
| Bjerke   | 200                  | 8                    |
| Rønning  | 200                  | 8                    |
| 97756218 | 200                  | 8                    |
| Julie    | 200                  | 7                    |

**Reflection.**
Binary search needed 7-8 comparisons per lookup, close to log2(200) ≈ 7,64.
This is a big improvement over linear search's constant 200.
The first-occurence guarantee come from not stopping at the first match.
BinarySearch narrows leftward (high = mid - 1) and keeps searching.
Any earlier duplicate overwrites the stored result before the search ends.
Sorting cost 9691 comparisons, so at roughly 192 comparisons saved pr search.
It pays for itself after about 50 searches on the same field.

## Appendix A: Complexity Reference

| Operation     | Best       | Average    | Worst      | Space |
|---------------|------------|------------|------------|-------|
| InsertionSort | O(n)       | O(n²)      | O(n²)      | O(1)  |
| MergeSort     | O(n log n) | O(n log n) | O(n log n) | O(n)  |

InsertionSort's already-sorted run (199 comparisons ≈ n) matches its O(n) best
case; its reverse-sorted run (19571, close to the theoretical maximum of
n(n-1)/2 = 19900) matches its O(n²) worst case. MergeSort's near-flat
comparison counts across shapes match its shape-independent O(n log n)
complexity.


## 4. Insight
My biggest takeaway is that InsertionSort's O(n²) and MergeSort's
O(n log n) translate into a real, roughly sevenfold difference in comparisons,
even on the exact same 200 contacts. Input order matters hugely for one
algorithm and barely at all for the other: InsertionSort swung wildly between
sorted and reversed data, while MergeSort stayed almost flat. And the "sorting
pays for itself after 50 searches" figure from section 3 isn't just theoretical —
it's a genuinely practical number I could use to decide whether sorting is
worth it for a real dataset.
