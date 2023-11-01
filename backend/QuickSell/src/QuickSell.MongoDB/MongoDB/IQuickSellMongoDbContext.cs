using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace QuickSell.MongoDB;

[ConnectionStringName(QuickSellDbProperties.ConnectionStringName)]
public interface IQuickSellMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
