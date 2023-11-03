
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
using QuickSell.StockUnits;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.StockUnits
{
public abstract class StockUnitsAppService :ApplicationService, IStockUnitsAppService
{
    private readonly IStockUnitRepository _stockUnitRepository;
    private readonly StockUnitManager _stockUnitManager;

    public StockUnitsAppService(IStockUnitRepository stockUnitRepository,StockUnitManager stockUnitManager)
    {
        _stockUnitRepository = stockUnitRepository;
        _stockUnitManager= stockUnitManager;
    }

    
        [Authorize(QuickSellPermissions.StockUnits.Create)]
    public virtual async Task<StockUnitDto> CreateAsync(StockUnitCreateDto input)
        {

            var stockUnit = await _stockUnitManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
        }

        [Authorize(QuickSellPermissions.StockUnits.Create)]
    public virtual async Task<PagedResultDto<StockUnitDto>> GetListAsync(GetStockUnitsInput input)
        {
            var totalCount = await _stockUnitRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _stockUnitRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<StockUnitDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< StockUnit>, List<StockUnitDto>>(items)
            };
        }


   

    public virtual async Task< StockUnitDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StockUnit, StockUnitDto>(await _stockUnitRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.StockUnits.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _stockUnitRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.StockUnits.Edit)]
     public virtual async Task<StockUnitDto> UpdateAsync(Guid id, StockUnitUpdateDto input)
         {
    
            var stockUnit = await _stockUnitManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
         }
    



         

        
         

}
}