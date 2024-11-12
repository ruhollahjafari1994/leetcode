using System;

public class Solution
{
    public char FindKthBit(int n, int k)
    {
        return FindBit(n, k);
    }

    private char FindBit(int n, int k)
    {
        if (n == 1)
        {
            return '0';
        }

        int length = (1 << n) - 1;  // length of S_n is 2^n - 1
        int mid = length / 2 + 1;   // middle position of S_n

        if (k == mid)
        {
            return '1';
        }
        else if (k < mid)
        {
            return FindBit(n - 1, k);
        }
        else
        {
            int mirroredK = length - k + 1;
            return FindBit(n - 1, mirroredK) == '0' ? '1' : '0';
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        // Test cases
        int n1 = 3, k1 = 1;
        Console.WriteLine($"The {k1}-th bit in S{n1} is: {solution.FindKthBit(n1, k1)}");  // Expected output: '0'

        int n2 = 4, k2 = 11;
        Console.WriteLine($"The {k2}-th bit in S{n2} is: {solution.FindKthBit(n2, k2)}");  // Expected output: '1'

        // Additional tests
        int n3 = 5, k3 = 16;
        Console.WriteLine($"The {k3}-th bit in S{n3} is: {solution.FindKthBit(n3, k3)}");  // You can add expected output if known
        
        int n4 = 20, k4 = 524287;
        Console.WriteLine($"The {k4}-th bit in S{n4} is: {solution.FindKthBit(n4, k4)}");  // Check for edge cases
    }
}
