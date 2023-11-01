using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace QuickSell;

[DependsOn(
    typeof(QuickSellDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class QuickSellApplicationContractsModule : AbpModule
{

}
