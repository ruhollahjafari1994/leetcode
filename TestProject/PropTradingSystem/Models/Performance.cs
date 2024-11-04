using System;

namespace PropTradingSystem.Models
{
    public class Performance
    {
        public int Id { get; set; }
        public int AccountId { get; set; } 
        public Account Account { get; set; }
        public decimal ProfitOrLoss { get; set; }
        public DateTime TradeDate { get; set; }
    }
}
