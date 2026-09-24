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

| Field | Target | Result | Comparisons |
|---|---|---|---|
| LastName | [a surname that appears several times] | index | |
| LastName | [absent value] | -1 | |
| Mobile | [a number from the file] | index | |
| FirstName | [a name that appears several times] | index | |

Linear search on the same targets, for comparison:

| Target | Comparisons (linear) | Comparisons (binary) |
|---|---|---|
| | | |

**Reflection.** [How many comparisons did binary search need against 200
contacts, and how does that compare with log2(200)? How do you guarantee the
first occurrence when a surname is duplicated? Sorting cost you the comparisons
in part 2: how many searches must you perform before sorting first pays for
itself?]

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

**One paragraph.** [What is the single most useful thing these figures taught you
about choosing an algorithm? Write about something your own numbers show, not
something you read.]
