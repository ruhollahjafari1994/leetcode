using System;

class Program
{
    public static void Main(string[] args)
    {
        int[] nums1 = { 1, 3 };
        int[] nums2 = { 2 };
        Solution solution = new Solution();
        double result = solution.FindMedianSortedArrays(nums1, nums2);
        Console.WriteLine(result);

    }

    public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // اطمینان از اینکه nums1 کوتاه‌تر از nums2 است
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);

        int m = nums1.Length;
        int n = nums2.Length;
        int halfLen = (m + n + 1) / 2;
        int minIndex = 0, maxIndex = m;

        while (minIndex <= maxIndex)
        {
            int i = (minIndex + maxIndex) / 2;
            int j = halfLen - i;

            if (i < m && nums2[j - 1] > nums1[i])
            {
                minIndex = i + 1;  // افزایش i برای جستجو بیشتر
            }
            else if (i > 0 && nums1[i - 1] > nums2[j])
            {
                maxIndex = i - 1;  // کاهش i برای جستجو کمتر
            }
            else
            {
                // حالت مطلوب را پیدا کردیم
                int maxOfLeft;
                if (i == 0)
                {
                    maxOfLeft = nums2[j - 1];
                }
                else if (j == 0)
                {
                    maxOfLeft = nums1[i - 1];
                }
                else
                {
                    maxOfLeft = Math.Max(nums1[i - 1], nums2[j - 1]);
                }

                if ((m + n) % 2 == 1)
                {
                    return maxOfLeft; // اگر تعداد کل عناصر فرد باشد، میانه maxOfLeft خواهد بود
                }

                int minOfRight;
                if (i == m)
                {
                    minOfRight = nums2[j];
                }
                else if (j == n)
                {
                    minOfRight = nums1[i];
                }
                else
                {
                    minOfRight = Math.Min(nums1[i], nums2[j]);
                }

                return (maxOfLeft + minOfRight) / 2.0; // اگر تعداد کل عناصر زوج باشد، میانه میانگین maxOfLeft و minOfRight است
            }
        }

        throw new ArgumentException("Input arrays are not valid");
    }
}

}
 