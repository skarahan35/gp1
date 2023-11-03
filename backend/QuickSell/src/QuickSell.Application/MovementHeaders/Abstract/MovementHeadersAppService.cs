
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
using QuickSell.MovementHeaders;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.MovementHeaders
{
public abstract class MovementHeadersAppService :ApplicationService, IMovementHeadersAppService
{
    private readonly IMovementHeaderRepository _movementHeaderRepository;
    private readonly MovementHeaderManager _movementHeaderManager;

    public MovementHeadersAppService(IMovementHeaderRepository movementHeaderRepository,MovementHeaderManager movementHeaderManager)
    {
        _movementHeaderRepository = movementHeaderRepository;
        _movementHeaderManager= movementHeaderManager;
    }

    
        [Authorize(QuickSellPermissions.MovementHeaders.Create)]
    public virtual async Task<MovementHeaderDto> CreateAsync(MovementHeaderCreateDto input)
        {

            var movementHeader = await _movementHeaderManager.CreateAsync(
                input.TypeCode,
                input.ReceiptNo,
                input.FirstAmount,
                input.DiscountAmount,
                input.VATAmount,
                input.TotalAmount,
                input.CustomerCardId,
            );
           
            
            return ObjectMapper.Map<MovementHeader, MovementHeaderDto>(movementHeader);
        }

        [Authorize(QuickSellPermissions.MovementHeaders.Create)]
    public virtual async Task<PagedResultDto<MovementHeaderDto>> GetListAsync(GetMovementHeadersInput input)
        {
            var totalCount = await _movementHeaderRepository.GetCountAsync(input.FilterText, input.TypeCode);
            var items = await _movementHeaderRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.TypeCode
            ,input.ReceiptNoMin
            ,input.ReceiptNoMax 
            ,input.FirstAmountMin
            ,input.FirstAmountMax 
            ,input.DiscountAmountMin
            ,input.DiscountAmountMax 
            ,input.VATAmountMin
            ,input.VATAmountMax 
            ,input.TotalAmountMin
            ,input.TotalAmountMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<MovementHeaderDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< MovementHeader>, List<MovementHeaderDto>>(items)
            };
        }


   

    public virtual async Task< MovementHeaderDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<MovementHeader, MovementHeaderDto>(await _movementHeaderRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.MovementHeaders.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _movementHeaderRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.MovementHeaders.Edit)]
     public virtual async Task<MovementHeaderDto> UpdateAsync(Guid id, MovementHeaderUpdateDto input)
         {
    
            var movementHeader = await _movementHeaderManager.UpdateAsync(
                id,
                input.TypeCode,
                input.ReceiptNo,
                input.FirstAmount,
                input.DiscountAmount,
                input.VATAmount,
                input.TotalAmount,
                input.CustomerCardId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<MovementHeader, MovementHeaderDto>(movementHeader);
         }
    



         

        
         

}
}