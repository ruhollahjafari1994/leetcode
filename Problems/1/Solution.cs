public class Solution {
    public int MaxUniqueSplit(string s) {
        return Backtrack(s, 0, new HashSet<string>());
    }

    private int Backtrack(string s, int start, HashSet<string> uniqueSubstrings) {
        if (start == s.Length) {
            // If we've reached the end of the string, return the count of unique substrings
            return uniqueSubstrings.Count;
        }
        
        int maxCount = 0;

        // Explore all possible substrings starting from `start`
        for (int end = start + 1; end <= s.Length; end++) {
            string substring = s.Substring(start, end - start);

            if (!uniqueSubstrings.Contains(substring)) {
                // Add the substring to the set if it's unique
                uniqueSubstrings.Add(substring);
                
                // Recur and calculate the maximum unique split count
                maxCount = Math.Max(maxCount, Backtrack(s, end, uniqueSubstrings));
                
                // Backtrack: remove the substring for the next exploration
                uniqueSubstrings.Remove(substring);
            }
        }

        return maxCount;
    }
}
