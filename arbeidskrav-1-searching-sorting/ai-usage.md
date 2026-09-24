AI Usage

This project was developed with assistance from Claude (Anthropic) via claude.ai.

How AI Was Used

Claude was used as a guided tutor throughout the development process. Rather
than generating the whole project at once, the conversation was structured
as a step-by-step walkthrough — building the enums, then Contact, then
Phonebook, then each algorithm one at a time, with explanations along the
way and my own attempts checked and corrected. All final decisions on
structure were made by me.

Prompts Used

Planning and Setup
"I have an assignment that is going to be delivered as a GitHub bundle. What should I name my repository?".
"I wish to keep things simple when it comes to the code. Can you assist me?".
"But I already have initialized a repo on git, will that create an issue?".
"Can you help me with creating meaningful commit messages that reflects what I have done".

Understanding Concepts
"Is `IComparer<T>` a type or a method?"
"What does the `out` keyword actually do? Why can't InsertionSort just
return the comparisons and swaps normally?"
"Why is `_comparisons` a field on Phonebook and not just a local variable
inside LinearSearch?"
"`_mergeComparisons` and `_mergeSwaps` are static — does that mean they're
shared across every call to MergeSort, or does each call get its own copy?"
"What's the difference between `<T>` on the class versus `<T>` on the method
itself in Sorting.cs?"
"Can you help me "

Code Generation
"Can you write the tests for me?" (used for the repetitive sorting benchmark
and BinarySearch test blocks, after writing the first example myself)
"Can you give me code to test this?" (null-argument exception tests)
"Can you help me with generating XML documentation"

Report and Documentation
"Can you help me with the report"

Debugging Help
"My Enum.cs looks like this now... Is it correct?"
"What is the error?" (followed by pasting code with mistakes for Claude to
identify and explain)
"Is this correct so far?" (asked repeatedly while building Contact,
Phonebook, ContactComparer, InsertionSort, and MergeSort)

Author: Berken Ates
Course: Backend Programming, 2nd Year — Oslo