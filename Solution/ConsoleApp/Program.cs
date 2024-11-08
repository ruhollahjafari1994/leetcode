public class Program
{
    public static void Main(string[] args)
    {
        // Example test case
        int[] nums = { 0, 1, 1, 3 };
        int maximumBit = 2;

        // Create an instance of the Solution class
        Solution solution = new Solution();

        // Get the maximum XOR results
        int[] result = solution.GetMaximumXor(nums, maximumBit);

        // Print the results
        Console.WriteLine("Output:");
        foreach (int value in result)
        {
            Console.Write(value + " ");
        }
    }
}

public class Solution
{
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        int n = nums.Length;
        int[] answer = new int[n];

        // Calculate the XOR of all elements in the array
        int xorTotal = 0;
        foreach (int num in nums)
        {
            xorTotal ^= num;
        }

        // Calculate the maximum possible XOR value with maximumBit bits
        int maximumXor = (1 << maximumBit) - 1;

        // Process each query in reverse order
        for (int i = 0; i < n; i++)
        {
            // Find k that maximizes the XOR result
            answer[i] = xorTotal ^ maximumXor;
            // Remove the last element of nums from xorTotal
            xorTotal ^= nums[n - 1 - i];
        }

        return answer;
    }
}
