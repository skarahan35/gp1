using Volo.Abp.AspNetCore.Mvc;
using QuickSell.Prefixes;


namespace QuickSell.Controllers.Prefixes
{
    public abstract class PrefixesController : AbpController, IPrefixesAppService
    {
        private readonly IPrefixesAppService _prefixesAppService;



        public PrefixesController(IPrefixesAppService prefixesAppService)
        {
            _prefixesAppService = prefixesAppService;
        }

    }
}
