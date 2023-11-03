



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockPrices;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.StockPrices
{
    
    [Route("api/stock-prices")]
    
    public abstract class StockPricesController : AbpController,IStockPricesAppService
    {
        private readonly IStockPricesAppService _stockPricesAppService;

        

        public StockPricesController(IStockPricesAppService stockPricesAppService)
       {
        _stockPricesAppService = stockPricesAppService;
       }

        [HttpPost]
        
        public virtual Task<StockPriceDto> CreateAsync( StockPriceCreateDto  input)
        {
            
                return _stockPricesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StockPriceDto> UpdateAsync(Guid id,  StockPriceUpdateDto  input)
        {
            return _stockPricesAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StockPriceDto>> GetListAsync(GetStockPricesInput input)
        {
            return _stockPricesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StockPriceDto> GetAsync( Guid id)
        {
            return _stockPricesAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _stockPricesAppService.DeleteAsync(id);
        }
    }
}
