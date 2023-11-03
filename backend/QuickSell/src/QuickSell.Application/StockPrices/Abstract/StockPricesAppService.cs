
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
using QuickSell.StockPrices;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.StockPrices
{
public abstract class StockPricesAppService :ApplicationService, IStockPricesAppService
{
    private readonly IStockPriceRepository _stockPriceRepository;
    private readonly StockPriceManager _stockPriceManager;

    public StockPricesAppService(IStockPriceRepository stockPriceRepository,StockPriceManager stockPriceManager)
    {
        _stockPriceRepository = stockPriceRepository;
        _stockPriceManager= stockPriceManager;
    }

    
        [Authorize(QuickSellPermissions.StockPrices.Create)]
    public virtual async Task<StockPriceDto> CreateAsync(StockPriceCreateDto input)
        {

            var stockPrice = await _stockPriceManager.CreateAsync(
                input.StockPriceType,
                input.StockPrice,
                input.StockCardId,
            );
           
            
            return ObjectMapper.Map<StockPrice, StockPriceDto>(stockPrice);
        }

        [Authorize(QuickSellPermissions.StockPrices.Create)]
    public virtual async Task<PagedResultDto<StockPriceDto>> GetListAsync(GetStockPricesInput input)
        {
            var totalCount = await _stockPriceRepository.GetCountAsync(input.FilterText, input.StockPriceType);
            var items = await _stockPriceRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.StockPriceType
            ,input.StockPriceMin
            ,input.StockPriceMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<StockPriceDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< StockPrice>, List<StockPriceDto>>(items)
            };
        }


   

    public virtual async Task< StockPriceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StockPrice, StockPriceDto>(await _stockPriceRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.StockPrices.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _stockPriceRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.StockPrices.Edit)]
     public virtual async Task<StockPriceDto> UpdateAsync(Guid id, StockPriceUpdateDto input)
         {
    
            var stockPrice = await _stockPriceManager.UpdateAsync(
                id,
                input.StockPriceType,
                input.StockPrice,
                input.StockCardId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<StockPrice, StockPriceDto>(stockPrice);
         }
    



         

        
         

}
}