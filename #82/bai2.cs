using System;

class JaggedArrayOperations
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine() ?? "0");

        int[][] array = new int[rows][];
        Random rand = new Random();

        // Get column sizes and populate with random numbers (1 to 100)
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Enter number of columns for Row {i + 1}: ");
            int cols = int.Parse(Console.ReadLine() ?? "0");
            array[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                array[i][j] = rand.Next(1, 101); // Random numbers between 1 and 100
            }
        }

        Console.WriteLine("\n--- Initial Array ---");
        PrintArray(array);

        // Task 1: Print largest numbers
        PrintMaxValues(array);

        // Task 2: Sort rows ascending
        SortRowsAscending(array);
        Console.WriteLine("\n--- Array After Sorting Rows Ascending ---");
        PrintArray(array);

        // Task 3: Print prime items
        PrintPrimeItems(array);

        // Task 4: Search value positions
        Console.Write("\nEnter a number to search in the array: ");
        int searchValue = int.Parse(Console.ReadLine() ?? "0");
        SearchValue(array, searchValue);
    }

    static void PrintArray(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Row {i + 1}: ");
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write($"{arr[i][j]}\t");
            }
            Console.WriteLine();
        }
    }

    // Task 1: Print biggest number per row and overall largest
    static void PrintMaxValues(int[][] arr)
    {
        Console.WriteLine("\n--- Maximum Values ---");
        int globalMax = int.MinValue;
        bool hasElements = false;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Length == 0) continue;

            int rowMax = arr[i][0];
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] > rowMax) rowMax = arr[i][j];
            }

            Console.WriteLine($"Row {i + 1} Maximum: {rowMax}");

            if (rowMax > globalMax)
            {
                globalMax = rowMax;
                hasElements = true;
            }
        }

        if (hasElements)
            Console.WriteLine($"Overall Array Maximum: {globalMax}");
        else
            Console.WriteLine("Array is empty.");
    }

    // Task 2: Sort values ascending for each row
    static void SortRowsAscending(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Array.Sort(arr[i]);
        }
    }

    // Helper method to check if a number is prime
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    // Task 3: Print all prime numbers in the array
    static void PrintPrimeItems(int[][] arr)
    {
        Console.WriteLine("\n--- Prime Numbers in Array ---");
        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (IsPrime(arr[i][j]))
                {
                    Console.WriteLine($"Prime Value {arr[i][j]} found at Position: Row {i + 1}, Col {j + 1}");
                    found = true;
                }
            }
        }

        if (!found) Console.WriteLine("No prime numbers found.");
    }

    // Task 4: Search and print all positions of a target value
    static void SearchValue(int[][] arr, int target)
    {
        Console.WriteLine($"\n--- Search Results for {target} ---");
        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] == target)
                {
                    Console.WriteLine($"Found at Row {i + 1}, Column {j + 1}");
                    found = true;
                }
            }
        }

        if (!found) Console.WriteLine($"Value {target} was not found in the array.");
    }
}