public class Program
{
    public static void Main(string[] args)
    {
        
    }
}                 
public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        // مرتب‌سازی آرایه‌های صندلی‌ها و دانش‌آموزان
        Array.Sort(seats);
        Array.Sort(students);

        int totalMoves = 0;

        // محاسبه مجموع حرکت‌ها
        for (int i = 0; i < seats.Length; i++)
        {
            totalMoves += Math.Abs(seats[i] - students[i]);
        }

        return totalMoves;
    }
}
