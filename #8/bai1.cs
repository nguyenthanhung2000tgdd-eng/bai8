using System;

class bai1
{
    static void Main()
    {
        // 1. Create and initialize a jagged array with predefined values
        int[][] jaggedArray = new int[3][]
        {
            new int[] { 5, 12, 8 },
            new int[] { 21, 44 },
            new int[] { 3, 17, 90, 31 }
        };

        // Display the jagged array
        Console.WriteLine("--- Displaying Jagged Array ---");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Row {i + 1}: ");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write($"{jaggedArray[i][j]}\t");
            }
            Console.WriteLine();
        }
    }
}