using Volo.Abp.Application.Services;

namespace QuickSell.Prefixes
{
    public abstract class PrefixesAppService : ApplicationService, IPrefixesAppService
    {
        private readonly IPrefixRepository _prefixRepository;
        private readonly PrefixManager _prefixManager;

        public PrefixesAppService(IPrefixRepository prefixRepository, PrefixManager prefixManager)
        {
            _prefixRepository = prefixRepository;
            _prefixManager = prefixManager;
        }
    }
}