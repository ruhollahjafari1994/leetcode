using System;

class Program
{
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            // Check if the current element matches the target
            if (arr[i] == target)
            {
                return i; // Return the index if found
            }
        }

        return -1; // Return -1 if target is not found in the array
    }

    static void Main()
    {
        int[] arr = { 7, 2, 9, 4, 3, 8, 5 };
        int target = 4;

        int result = LinearSearch(arr, target);

        if (result == -1)
            Console.WriteLine("Element not present in array");
        else
            Console.WriteLine("Element found at index " + result);
    }
}
