using Microsoft.EntityFrameworkCore;

namespace PropTradingSystem.Models
{
    public class PropTradingContext : DbContext
    {
        public PropTradingContext(DbContextOptions<PropTradingContext> options) : base(options) { }

        public DbSet<Trader> Traders { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<RiskManagement> RiskManagements { get; set; }
        public DbSet<ProfitShare> ProfitShares { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // رابطه یک‌به‌یک بین Account و RiskManagement
            modelBuilder.Entity<Account>()
                .HasOne(a => a.RiskManagementPolicy)
                .WithOne(r => r.Account)
                .HasForeignKey<RiskManagement>(r => r.AccountId);

            // رابطه یک‌به‌چند بین Trader و Challenge
            modelBuilder.Entity<Trader>()
                .HasMany(t => t.Challenges)
                .WithOne(c => c.Trader)
                .HasForeignKey(c => c.TraderId)
                .OnDelete(DeleteBehavior.Cascade);

            // رابطه یک‌به‌چند بین Trader و Account
            modelBuilder.Entity<Trader>()
                .HasMany(t => t.Accounts)
                .WithOne(a => a.Trader)
                .HasForeignKey(a => a.TraderId)
                .OnDelete(DeleteBehavior.Cascade);

            // رابطه یک‌به‌چند بین Account و Performance
            modelBuilder.Entity<Account>()
                .HasMany(a => a.PerformanceRecords)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // رابطه یک‌به‌چند بین Admin و Report
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Reports)
                .WithOne(r => r.Admin)
                .HasForeignKey(r => r.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

            // رابطه یک‌به‌چند بین Manager و Report
            modelBuilder.Entity<Manager>()
                .HasMany(m => m.ReviewedReports)
                .WithOne(r => r.Manager)
                .HasForeignKey(r => r.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            // رابطه یک‌به‌یک بین Account و ProfitShare
            modelBuilder.Entity<Account>()
                .HasOne(a => a.ProfitShare)
                .WithOne(p => p.Account)
                .HasForeignKey<ProfitShare>(p => p.AccountId);

            // تنظیم رابطه‌های Report
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Trader)
                .WithMany()
                .HasForeignKey(r => r.TraderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.RiskSummary)
                .WithMany()
                .HasForeignKey(r => r.RiskSummaryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
