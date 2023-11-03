



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockCards;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


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

        [HttpPost]
        
        public virtual Task<StockCardDto> CreateAsync( StockCardCreateDto  input)
        {
            
                return _stockCardsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StockCardDto> UpdateAsync(Guid id,  StockCardUpdateDto  input)
        {
            return _stockCardsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StockCardDto>> GetListAsync(GetStockCardsInput input)
        {
            return _stockCardsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StockCardDto> GetAsync( Guid id)
        {
            return _stockCardsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _stockCardsAppService.DeleteAsync(id);
        }
    }
}
