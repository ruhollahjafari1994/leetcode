namespace PropTradingSystem.Models
{
    public class RiskManagement
    {
        public int Id { get; set; }
        public int AccountId { get; set; }  
        public Account Account { get; set; }
        public decimal MaxDailyLoss { get; set; }
        public decimal MaxOverallLoss { get; set; }
        public decimal MaxPositionSize { get; set; }
    }
}
