



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockCards;




namespace  QuickSell.Controllers.StockCards
{
    
    [Route("api/stock-cards")]
    
    public abstract class StockCardsController : AbpController,IStockCardsAppService
    {
        private readonly IStockCardsAppService _stockCardsAppService;

        

        public StockCardsController(IStockCardsAppService stockCardsAppService)
       {
        _stockCardsAppService = stockCardsAppService;
       }

       
    }
}
