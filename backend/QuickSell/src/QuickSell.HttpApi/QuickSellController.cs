using QuickSell.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QuickSell;

public abstract class QuickSellController : AbpControllerBase
{
    protected QuickSellController()
    {
        LocalizationResource = typeof(QuickSellResource);
    }
}
