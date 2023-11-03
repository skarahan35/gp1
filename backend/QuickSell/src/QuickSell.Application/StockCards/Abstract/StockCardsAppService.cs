
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
using QuickSell.StockCards;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.StockCards
{
public abstract class StockCardsAppService :ApplicationService, IStockCardsAppService
{
    private readonly IStockCardRepository _stockCardRepository;
    private readonly StockCardManager _stockCardManager;

    public StockCardsAppService(IStockCardRepository stockCardRepository,StockCardManager stockCardManager)
    {
        _stockCardRepository = stockCardRepository;
        _stockCardManager= stockCardManager;
    }

    
        [Authorize(QuickSellPermissions.StockCards.Create)]
    public virtual async Task<StockCardDto> CreateAsync(StockCardCreateDto input)
        {

            var stockCard = await _stockCardManager.CreateAsync(
                input.Code,
                input.Name,
                input.CurrencyType,
                input.TransferredQuantity,
                input.AvailableQuantity,
                input.TotalEntryQuantity,
                input.TotalOutputQuantity,
                input.VATRate,
                input.DiscountRate,
                input.Price1,
                input.Price2,
                input.Price3,
                input.StockTypeId,
                input.StockUnitId,
                input.StockGroupId,
            );
           
            
            return ObjectMapper.Map<StockCard, StockCardDto>(stockCard);
        }

        [Authorize(QuickSellPermissions.StockCards.Create)]
    public virtual async Task<PagedResultDto<StockCardDto>> GetListAsync(GetStockCardsInput input)
        {
            var totalCount = await _stockCardRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.CurrencyType);
            var items = await _stockCardRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.CurrencyType
            ,input.TransferredQuantityMin
            ,input.TransferredQuantityMax 
            ,input.AvailableQuantityMin
            ,input.AvailableQuantityMax 
            ,input.TotalEntryQuantityMin
            ,input.TotalEntryQuantityMax 
            ,input.TotalOutputQuantityMin
            ,input.TotalOutputQuantityMax 
            ,input.VATRateMin
            ,input.VATRateMax 
            ,input.DiscountRateMin
            ,input.DiscountRateMax 
            ,input.Price1Min
            ,input.Price1Max 
            ,input.Price2Min
            ,input.Price2Max 
            ,input.Price3Min
            ,input.Price3Max 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<StockCardDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< StockCard>, List<StockCardDto>>(items)
            };
        }


   

    public virtual async Task< StockCardDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StockCard, StockCardDto>(await _stockCardRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.StockCards.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _stockCardRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.StockCards.Edit)]
     public virtual async Task<StockCardDto> UpdateAsync(Guid id, StockCardUpdateDto input)
         {
    
            var stockCard = await _stockCardManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.CurrencyType,
                input.TransferredQuantity,
                input.AvailableQuantity,
                input.TotalEntryQuantity,
                input.TotalOutputQuantity,
                input.VATRate,
                input.DiscountRate,
                input.Price1,
                input.Price2,
                input.Price3,
                input.StockTypeId,
                input.StockUnitId,
                input.StockGroupId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<StockCard, StockCardDto>(stockCard);
         }
    



         

        
         

}
}