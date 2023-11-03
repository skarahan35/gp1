using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QuickSell.EntityFrameworkCore;

public class QuickSellHttpApiHostMigrationsDbContext : AbpDbContext<QuickSellHttpApiHostMigrationsDbContext>
{
    public QuickSellHttpApiHostMigrationsDbContext(DbContextOptions<QuickSellHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureQuickSell();
    }
}
