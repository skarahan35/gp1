



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockTypes;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.StockTypes
{
    
    [Route("api/stock-types")]
    
    public abstract class StockTypesController : AbpController,IStockTypesAppService
    {
        private readonly IStockTypesAppService _stockTypesAppService;

        

        public StockTypesController(IStockTypesAppService stockTypesAppService)
       {
        _stockTypesAppService = stockTypesAppService;
       }

        [HttpPost]
        
        public virtual Task<StockTypeDto> CreateAsync( StockTypeCreateDto  input)
        {
            
                return _stockTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StockTypeDto> UpdateAsync(Guid id,  StockTypeUpdateDto  input)
        {
            return _stockTypesAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StockTypeDto>> GetListAsync(GetStockTypesInput input)
        {
            return _stockTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StockTypeDto> GetAsync( Guid id)
        {
            return _stockTypesAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _stockTypesAppService.DeleteAsync(id);
        }
    }
}
