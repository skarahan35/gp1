



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockUnits;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.StockUnits
{
    
    [Route("api/stock-units")]
    
    public abstract class StockUnitsController : AbpController,IStockUnitsAppService
    {
        private readonly IStockUnitsAppService _stockUnitsAppService;

        

        public StockUnitsController(IStockUnitsAppService stockUnitsAppService)
       {
        _stockUnitsAppService = stockUnitsAppService;
       }

        [HttpPost]
        
        public virtual Task<StockUnitDto> CreateAsync( StockUnitCreateDto  input)
        {
            
                return _stockUnitsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StockUnitDto> UpdateAsync(Guid id,  StockUnitUpdateDto  input)
        {
            return _stockUnitsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StockUnitDto>> GetListAsync(GetStockUnitsInput input)
        {
            return _stockUnitsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StockUnitDto> GetAsync( Guid id)
        {
            return _stockUnitsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _stockUnitsAppService.DeleteAsync(id);
        }
    }
}
