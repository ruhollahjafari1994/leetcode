namespace PropTradingSystem.Models
{                                         
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Report> Reports { get; set; }
    }
}
