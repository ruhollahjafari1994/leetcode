namespace PropTradingSystem.Models
{                               
    public class ProfitShare
    {
        public int Id { get; set; }
        public decimal TraderProfitPercentage { get; set; }  
        public decimal CompanyProfitPercentage { get; set; } 
        public decimal TotalProfit { get; set; } 
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
