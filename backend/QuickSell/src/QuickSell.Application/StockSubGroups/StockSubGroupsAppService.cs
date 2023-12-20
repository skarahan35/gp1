using Volo.Abp.Application.Services;

namespace QuickSell.StockSubGroups
{
    public abstract class StockSubGroupsAppService : ApplicationService, IStockSubGroupsAppService
    {
        private readonly IStockSubGroupRepository _stockSubGroupRepository;
        private readonly StockSubGroupManager _stockSubGroupManager;

        public StockSubGroupsAppService(IStockSubGroupRepository stockSubGroupRepository, StockSubGroupManager stockSubGroupManager)
        {
            _stockSubGroupRepository = stockSubGroupRepository;
            _stockSubGroupManager = stockSubGroupManager;
        }

    }
}