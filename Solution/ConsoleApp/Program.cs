using System;

class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.LengthOfLongestSubstring("abcabcbb")); // Output: 3
        Console.WriteLine(solution.LengthOfLongestSubstring("bbbbb"));    // Output: 1
        Console.WriteLine(solution.LengthOfLongestSubstring("pwwkew"));   // Output: 3
    }

}
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        int maxLength = 0;
        int start = 0;
        var charIndexMap = new Dictionary<char, int>();

        for (int end = 0; end < s.Length; end++)
        {
            if (charIndexMap.ContainsKey(s[end]))
            {
                start = Math.Max(start, charIndexMap[s[end]] + 1);
            }

            charIndexMap[s[end]] = end;
            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}
