using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QuickSell.EntityFrameworkCore;

public class QuickSellHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<QuickSellHttpApiHostMigrationsDbContext>
{
    public QuickSellHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<QuickSellHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("QuickSell"));

        return new QuickSellHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
