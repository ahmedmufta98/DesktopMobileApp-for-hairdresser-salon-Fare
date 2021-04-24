using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using eHairdresserSalonFare.Api.Helper;
using eHairdresserSalonFareBugojno.DBContext;
using Microsoft.Extensions.DependencyInjection;

namespace eHairdresserSalonFare.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbSeed.SeedDB(context);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
