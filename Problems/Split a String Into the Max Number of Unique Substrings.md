# 1593. Split a String Into the Max Number of Unique Substrings

## Difficulty: Medium

### Problem Statement
Given a string `s`, return the maximum number of **unique** substrings that the given string can be split into.

You can split string `s` into any list of **non-empty** substrings, where the concatenation of the substrings forms the original string. However, you must split the substrings such that **all of them are unique**.

A substring is a contiguous sequence of characters within a string.

---

### Example 1:
**Input:**
```plaintext
s = "ababccc"




public class Solution {
    public int MaxUniqueSplit(string s) {
        return Backtrack(s, new HashSet<string>(), 0);
    }
    
    private int Backtrack(string s, HashSet<string> uniqueSubstrings, int start) {
        if (start == s.Length) {
            return 0;
        }
        
        int maxSplits = 0;
        
        for (int end = start + 1; end <= s.Length; end++) {
            string substring = s.Substring(start, end - start);
            
            if (!uniqueSubstrings.Contains(substring)) {
                uniqueSubstrings.Add(substring);
                maxSplits = Math.Max(maxSplits, 1 + Backtrack(s, uniqueSubstrings, end));
                uniqueSubstrings.Remove(substring);
            }
        }
        
        return maxSplits;
    }
}
