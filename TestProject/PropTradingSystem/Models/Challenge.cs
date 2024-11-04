using System;

namespace PropTradingSystem.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TargetProfit { get; set; }
        public decimal MaxDrawdown { get; set; }
        public int DurationDays { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TraderId { get; set; }  
        public Trader Trader { get; set; }
    }
}
