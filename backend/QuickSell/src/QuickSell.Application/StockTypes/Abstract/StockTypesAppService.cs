
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickSell.Permissions;
using QuickSell.StockTypes;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.StockTypes
{
public abstract class StockTypesAppService :ApplicationService, IStockTypesAppService
{
    private readonly IStockTypeRepository _stockTypeRepository;
    private readonly StockTypeManager _stockTypeManager;

    public StockTypesAppService(IStockTypeRepository stockTypeRepository,StockTypeManager stockTypeManager)
    {
        _stockTypeRepository = stockTypeRepository;
        _stockTypeManager= stockTypeManager;
    }

    
        [Authorize(QuickSellPermissions.StockTypes.Create)]
    public virtual async Task<StockTypeDto> CreateAsync(StockTypeCreateDto input)
        {

            var stockType = await _stockTypeManager.CreateAsync(
                input.Code,
                input.Name,
                input.Condition, 
            );
           
            
            return ObjectMapper.Map<StockType, StockTypeDto>(stockType);
        }

        [Authorize(QuickSellPermissions.StockTypes.Create)]
    public virtual async Task<PagedResultDto<StockTypeDto>> GetListAsync(GetStockTypesInput input)
        {
            var totalCount = await _stockTypeRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _stockTypeRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.ConditionMin
            ,input.ConditionMax 
          
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<StockTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< StockType>, List<StockTypeDto>>(items)
            };
        }


   

    public virtual async Task< StockTypeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StockType, StockTypeDto>(await _stockTypeRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.StockTypes.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _stockTypeRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.StockTypes.Edit)]
     public virtual async Task<StockTypeDto> UpdateAsync(Guid id, StockTypeUpdateDto input)
         {
    
            var stockType = await _stockTypeManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.Condition, 
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<StockType, StockTypeDto>(stockType);
         }
    



         

        
         

}
}