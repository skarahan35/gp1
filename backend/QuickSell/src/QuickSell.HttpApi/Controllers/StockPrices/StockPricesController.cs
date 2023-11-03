



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockPrices;




namespace  QuickSell.Controllers.StockPrices
{
    
    public class StockPricesController : AbpController,IStockPricesAppService
    {
        private readonly IStockPricesAppService _stockPricesAppService;

        

        public StockPricesController(IStockPricesAppService stockPricesAppService)
       {
        _stockPricesAppService = stockPricesAppService;
       }

    }
}
