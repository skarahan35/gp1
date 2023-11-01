using QuickSell.Localization;
using Volo.Abp.Application.Services;

namespace QuickSell;

public abstract class QuickSellAppService : ApplicationService
{
    protected QuickSellAppService()
    {
        LocalizationResource = typeof(QuickSellResource);
        ObjectMapperContext = typeof(QuickSellApplicationModule);
    }
}
