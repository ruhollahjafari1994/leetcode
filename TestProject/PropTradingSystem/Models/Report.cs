using System;
using System.Collections.Generic;

namespace PropTradingSystem.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int TraderId { get; set; } 
        public Trader Trader { get; set; }
        public int? ManagerId { get; set; } 
        public Manager Manager { get; set; }
        public int RiskSummaryId { get; set; }
        public RiskManagement RiskSummary { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Comments { get; set; }
    }
}
