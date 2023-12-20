using Volo.Abp.AspNetCore.Mvc;
using QuickSell.StockSubGroups;


namespace QuickSell.Controllers.StockSubGroups
{
    public abstract class StockSubGroupsController : AbpController, IStockSubGroupsAppService
    {
        private readonly IStockSubGroupsAppService _stockSubGroupsAppService;



        public StockSubGroupsController(IStockSubGroupsAppService stockSubGroupsAppService)
        {
            _stockSubGroupsAppService = stockSubGroupsAppService;
        }

    }
}
