using System;

class Program
{
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> numDict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (numDict.ContainsKey(complement))
            {
                return new int[] { numDict[complement], i };
            }
            numDict[nums[i]] = i;
        }

        throw new ArgumentException("No two sum solution");
    }

    static void Main(string[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = TwoSum(nums, target);
        Console.WriteLine($"[{result[0]}, {result[1]}]"); // Output: [0, 1]
    }
}
