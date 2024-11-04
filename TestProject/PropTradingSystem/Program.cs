using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropTradingSystem.Models;

namespace PropTradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
                                                
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

            Console.WriteLine("Database migration completed and test data seeded.");
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddDbContext<PropTradingContext>(options =>
                        options.UseSqlServer("Data Source=APP-OP\\TEST;Initial Catalog=PropTradingSystem;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True")));
    }
}
