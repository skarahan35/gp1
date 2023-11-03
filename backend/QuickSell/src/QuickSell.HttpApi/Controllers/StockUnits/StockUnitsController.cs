



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockUnits;



namespace  QuickSell.Controllers.StockUnits
{
    
    public class StockUnitsController : AbpController,IStockUnitsAppService
    {
        private readonly IStockUnitsAppService _stockUnitsAppService;

        

        public StockUnitsController(IStockUnitsAppService stockUnitsAppService)
       {
        _stockUnitsAppService = stockUnitsAppService;
       }

       
    }
}
