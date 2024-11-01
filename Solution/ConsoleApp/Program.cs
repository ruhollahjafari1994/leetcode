using System;

class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.LongestPalindrome("babad")); // خروجی: "bab" یا "aba"
        Console.WriteLine(solution.LongestPalindrome("cbbd"));  // خروجی: "bb"

    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 1) return "";

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandFromCenter(s, i, i);       // گسترش از یک کاراکتر (پالیندروم‌های با طول فرد)
                int len2 = ExpandFromCenter(s, i, i + 1);   // گسترش از دو کاراکتر (پالیندروم‌های با طول زوج)
                int len = Math.Max(len1, len2);             // انتخاب پالیندروم با طول بیشتر

                if (len > end - start)
                {                    // به‌روزرسانی طولانی‌ترین پالیندروم
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);     // استخراج زیررشته پالیندروم
        }

        private int ExpandFromCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }
    }

}
