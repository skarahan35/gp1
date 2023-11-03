
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
using QuickSell.StockGroups;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.StockGroups
{
public abstract class StockGroupsAppService :ApplicationService, IStockGroupsAppService
{
    private readonly IStockGroupRepository _stockGroupRepository;
    private readonly StockGroupManager _stockGroupManager;

    public StockGroupsAppService(IStockGroupRepository stockGroupRepository,StockGroupManager stockGroupManager)
    {
        _stockGroupRepository = stockGroupRepository;
        _stockGroupManager= stockGroupManager;
    }

    
        [Authorize(QuickSellPermissions.StockGroups.Create)]
    public virtual async Task<StockGroupDto> CreateAsync(StockGroupCreateDto input)
        {

            var stockGroup = await _stockGroupManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<StockGroup, StockGroupDto>(stockGroup);
        }

        [Authorize(QuickSellPermissions.StockGroups.Create)]
    public virtual async Task<PagedResultDto<StockGroupDto>> GetListAsync(GetStockGroupsInput input)
        {
            var totalCount = await _stockGroupRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _stockGroupRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<StockGroupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< StockGroup>, List<StockGroupDto>>(items)
            };
        }


   

    public virtual async Task< StockGroupDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StockGroup, StockGroupDto>(await _stockGroupRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.StockGroups.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _stockGroupRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.StockGroups.Edit)]
     public virtual async Task<StockGroupDto> UpdateAsync(Guid id, StockGroupUpdateDto input)
         {
    
            var stockGroup = await _stockGroupManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<StockGroup, StockGroupDto>(stockGroup);
         }
    



         

        
         

}
}