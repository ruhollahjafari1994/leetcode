using System.Collections.Generic;

namespace PropTradingSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxRiskPerTrade { get; set; }
        public int TraderId { get; set; }  
        public Trader Trader { get; set; }
        public RiskManagement RiskManagementPolicy { get; set; }
        public ProfitShare ProfitShare { get; set; }
        public List<Performance> PerformanceRecords { get; set; }
    }
}
