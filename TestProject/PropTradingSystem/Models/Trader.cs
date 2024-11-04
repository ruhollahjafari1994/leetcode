namespace PropTradingSystem.Models
{                      
    public class Trader
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public List<Challenge> Challenges { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
