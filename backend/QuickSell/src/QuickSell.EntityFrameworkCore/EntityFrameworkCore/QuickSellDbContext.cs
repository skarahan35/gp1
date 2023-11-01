using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QuickSell.EntityFrameworkCore;

[ConnectionStringName(QuickSellDbProperties.ConnectionStringName)]
public class QuickSellDbContext : AbpDbContext<QuickSellDbContext>, IQuickSellDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public QuickSellDbContext(DbContextOptions<QuickSellDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureQuickSell();
    }
}
