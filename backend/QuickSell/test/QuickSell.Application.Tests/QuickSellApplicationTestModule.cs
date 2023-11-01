using Volo.Abp.Modularity;

namespace QuickSell;

[DependsOn(
    typeof(QuickSellApplicationModule),
    typeof(QuickSellDomainTestModule)
    )]
public class QuickSellApplicationTestModule : AbpModule
{

}
