using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace QuickSell;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(QuickSellDomainSharedModule)
)]
public class QuickSellDomainModule : AbpModule
{

}
