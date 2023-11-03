



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockGroups;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.StockGroups
{
    
    [Route("api/stock-groups")]
    
    public abstract class StockGroupsController : AbpController,IStockGroupsAppService
    {
        private readonly IStockGroupsAppService _stockGroupsAppService;

        

        public StockGroupsController(IStockGroupsAppService stockGroupsAppService)
       {
        _stockGroupsAppService = stockGroupsAppService;
       }

        [HttpPost]
        
        public virtual Task<StockGroupDto> CreateAsync( StockGroupCreateDto  input)
        {
            
                return _stockGroupsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StockGroupDto> UpdateAsync(Guid id,  StockGroupUpdateDto  input)
        {
            return _stockGroupsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StockGroupDto>> GetListAsync(GetStockGroupsInput input)
        {
            return _stockGroupsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StockGroupDto> GetAsync( Guid id)
        {
            return _stockGroupsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _stockGroupsAppService.DeleteAsync(id);
        }
    }
}
