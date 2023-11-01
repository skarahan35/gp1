using QuickSell.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QuickSell;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(QuickSellEntityFrameworkCoreTestModule)
    )]
public class QuickSellDomainTestModule : AbpModule
{

}
