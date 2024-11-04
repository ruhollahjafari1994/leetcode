namespace PropTradingSystem.Models
{
    // مدل مدیر برای مشاهده گزارش‌ها و تصمیم‌گیری نهایی
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Report> ReviewedReports { get; set; } 
    }
}
