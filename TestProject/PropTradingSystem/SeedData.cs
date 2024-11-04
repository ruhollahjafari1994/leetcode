using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PropTradingSystem.Models;

namespace PropTradingSystem
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PropTradingContext(
                serviceProvider.GetRequiredService<DbContextOptions<PropTradingContext>>()))
            {
                if (context.Traders.Any())
                {
                    return; // اگر داده‌ای وجود دارد، داده‌های جدیدی وارد نشود
                }

                // ایجاد یک تریدر
                var trader = new Trader { Name = "John Doe" };
                context.Traders.Add(trader);

                // ایجاد یک چالش برای تریدر
                var challenge = new Challenge
                {
                    Name = "Profit Challenge",
                    TargetProfit = 1000m,
                    MaxDrawdown = 500m,
                    DurationDays = 30,
                    Trader = trader,
                    IsCompleted = false,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30)
                };
                context.Challenges.Add(challenge);

                // ایجاد یک حساب برای تریدر
                var account = new Account
                {
                    Balance = 5000m,
                    MaxRiskPerTrade = 100m,
                    Trader = trader
                };
                context.Accounts.Add(account);

                // ایجاد یک رکورد مدیریت ریسک برای حساب
                var riskManagement = new RiskManagement
                {
                    Account = account,
                    MaxDailyLoss = 300m,
                    MaxOverallLoss = 1000m,
                    MaxPositionSize = 50m
                };
                context.RiskManagements.Add(riskManagement);

                // ایجاد یک رکورد تقسیم سود برای حساب
                var profitShare = new ProfitShare
                {
                    Account = account,
                    TraderProfitPercentage = 70m,
                    CompanyProfitPercentage = 30m,
                    TotalProfit = 0m
                };
                context.ProfitShares.Add(profitShare);

                // ایجاد چندین رکورد عملکرد برای حساب
                var performance1 = new Performance
                {
                    Account = account,
                    ProfitOrLoss = 200m,
                    TradeDate = DateTime.Now.AddDays(-5)
                };

                var performance2 = new Performance
                {
                    Account = account,
                    ProfitOrLoss = -150m,
                    TradeDate = DateTime.Now.AddDays(-3)
                };

                context.Performances.AddRange(performance1, performance2);

                // ایجاد ادمین و مدیر برای گزارش‌ها
                var admin = new Admin { Name = "Admin User" };
                var manager = new Manager { Name = "Manager User" };
                context.Admins.Add(admin);
                context.Managers.Add(manager);

                // ایجاد گزارش برای تریدر
                var report = new Report
                {
                    Admin = admin,
                    Trader = trader,
                    Manager = manager,
                    RiskSummary = riskManagement,
                    CreatedDate = DateTime.Now,
                    Comments = "Trader showed good performance with moderate risk management."
                };
                context.Reports.Add(report);

                // ذخیره تغییرات در پایگاه داده
                context.SaveChanges();
            }
        }

    }
}
