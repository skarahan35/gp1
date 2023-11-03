



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockGroups;


namespace  QuickSell.Controllers.StockGroups
{
    
    public class StockGroupsController : AbpController,IStockGroupsAppService
    {
        private readonly IStockGroupsAppService _stockGroupsAppService;

        

        public StockGroupsController(IStockGroupsAppService stockGroupsAppService)
       {
        _stockGroupsAppService = stockGroupsAppService;
       }

    }
}
