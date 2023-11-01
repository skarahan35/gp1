using Localization.Resources.AbpUi;
using QuickSell.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace QuickSell;

[DependsOn(
    typeof(QuickSellApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class QuickSellHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(QuickSellHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<QuickSellResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
