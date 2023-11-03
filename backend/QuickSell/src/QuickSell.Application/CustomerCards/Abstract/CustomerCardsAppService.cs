
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
using QuickSell.CustomerCards;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.CustomerCards
{
public abstract class CustomerCardsAppService :ApplicationService, ICustomerCardsAppService
{
    private readonly ICustomerCardRepository _customerCardRepository;
    private readonly CustomerCardManager _customerCardManager;

    public CustomerCardsAppService(ICustomerCardRepository customerCardRepository,CustomerCardManager customerCardManager)
    {
        _customerCardRepository = customerCardRepository;
        _customerCardManager= customerCardManager;
    }

    
        [Authorize(QuickSellPermissions.CustomerCards.Create)]
    public virtual async Task<CustomerCardDto> CreateAsync(CustomerCardCreateDto input)
        {

            var customerCard = await _customerCardManager.CreateAsync(
                input.Code,
                input.Name,
                input.TaxOffice,
                input.TCNumber,
                input.AuthorizedPerson,
                input.EMail,
                input.TaxNo,
                input.RiskLimit,
                input.CustomerTypeId,
                input.CustomerGroupId,
            );
           
            
            return ObjectMapper.Map<CustomerCard, CustomerCardDto>(customerCard);
        }

        [Authorize(QuickSellPermissions.CustomerCards.Create)]
    public virtual async Task<PagedResultDto<CustomerCardDto>> GetListAsync(GetCustomerCardsInput input)
        {
            var totalCount = await _customerCardRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.TaxOffice, input.TCNumber, input.AuthorizedPerson, input.EMail);
            var items = await _customerCardRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.TaxOffice
            ,input.TCNumber
            ,input.AuthorizedPerson
            ,input.EMail
            ,input.TaxNoMin
            ,input.TaxNoMax 
            ,input.RiskLimitMin
            ,input.RiskLimitMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CustomerCardDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< CustomerCard>, List<CustomerCardDto>>(items)
            };
        }


   

    public virtual async Task< CustomerCardDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CustomerCard, CustomerCardDto>(await _customerCardRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.CustomerCards.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _customerCardRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.CustomerCards.Edit)]
     public virtual async Task<CustomerCardDto> UpdateAsync(Guid id, CustomerCardUpdateDto input)
         {
    
            var customerCard = await _customerCardManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.TaxOffice,
                input.TCNumber,
                input.AuthorizedPerson,
                input.EMail,
                input.TaxNo,
                input.RiskLimit,
                input.CustomerTypeId,
                input.CustomerGroupId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<CustomerCard, CustomerCardDto>(customerCard);
         }
    



         

        
         

}
}