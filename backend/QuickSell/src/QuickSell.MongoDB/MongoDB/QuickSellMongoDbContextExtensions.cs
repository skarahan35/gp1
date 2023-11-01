using Volo.Abp;
using Volo.Abp.MongoDB;

namespace QuickSell.MongoDB;

public static class QuickSellMongoDbContextExtensions
{
    public static void ConfigureQuickSell(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
