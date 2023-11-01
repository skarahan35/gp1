using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QuickSell.EntityFrameworkCore;

[ConnectionStringName(QuickSellDbProperties.ConnectionStringName)]
public interface IQuickSellDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
