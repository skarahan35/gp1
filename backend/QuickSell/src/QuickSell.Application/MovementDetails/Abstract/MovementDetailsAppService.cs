
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
using QuickSell.MovementDetails;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.MovementDetails
{
public abstract class MovementDetailsAppService :ApplicationService, IMovementDetailsAppService
{
    private readonly IMovementDetailsRepository _movementDetailsRepository;
    private readonly MovementDetailsManager _movementDetailsManager;

    public MovementDetailsAppService(IMovementDetailsRepository movementDetailsRepository,MovementDetailsManager movementDetailsManager)
    {
        _movementDetailsRepository = movementDetailsRepository;
        _movementDetailsManager= movementDetailsManager;
    }

    
        [Authorize(QuickSellPermissions.MovementDetails.Create)]
    public virtual async Task<MovementDetailsDto> CreateAsync(MovementDetailsCreateDto input)
        {

            var movementDetails = await _movementDetailsManager.CreateAsync(
                input.TypeCode,
                input.ReceiptNo,
                input.Quantity,
                input.Price,
                input.DiscountRate,
                input.DiscountAmount,
                input.VATRate,
                input.VATAmount,
                input.StockCardId,
            );
           
            
            return ObjectMapper.Map<MovementDetails, MovementDetailsDto>(movementDetails);
        }

        [Authorize(QuickSellPermissions.MovementDetails.Create)]
    public virtual async Task<PagedResultDto<MovementDetailsDto>> GetListAsync(GetMovementDetailsInput input)
        {
            var totalCount = await _movementDetailsRepository.GetCountAsync(input.FilterText, input.TypeCode);
            var items = await _movementDetailsRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.TypeCode
            ,input.ReceiptNoMin
            ,input.ReceiptNoMax 
            ,input.QuantityMin
            ,input.QuantityMax 
            ,input.PriceMin
            ,input.PriceMax 
            ,input.DiscountRateMin
            ,input.DiscountRateMax 
            ,input.DiscountAmountMin
            ,input.DiscountAmountMax 
            ,input.VATRateMin
            ,input.VATRateMax 
            ,input.VATAmountMin
            ,input.VATAmountMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<MovementDetailsDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< MovementDetails>, List<MovementDetailsDto>>(items)
            };
        }


   

    public virtual async Task< MovementDetailsDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<MovementDetails, MovementDetailsDto>(await _movementDetailsRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.MovementDetails.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _movementDetailsRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.MovementDetails.Edit)]
     public virtual async Task<MovementDetailsDto> UpdateAsync(Guid id, MovementDetailsUpdateDto input)
         {
    
            var movementDetails = await _movementDetailsManager.UpdateAsync(
                id,
                input.TypeCode,
                input.ReceiptNo,
                input.Quantity,
                input.Price,
                input.DiscountRate,
                input.DiscountAmount,
                input.VATRate,
                input.VATAmount,
                input.StockCardId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<MovementDetails, MovementDetailsDto>(movementDetails);
         }
    



         

        
         

}
}