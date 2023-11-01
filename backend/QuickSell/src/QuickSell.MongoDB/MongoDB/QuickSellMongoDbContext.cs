using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace QuickSell.MongoDB;

[ConnectionStringName(QuickSellDbProperties.ConnectionStringName)]
public class QuickSellMongoDbContext : AbpMongoDbContext, IQuickSellMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureQuickSell();
    }
}
