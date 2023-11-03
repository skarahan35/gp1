
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
using QuickSell.CustomerTypes;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.CustomerTypes
{
public abstract class CustomerTypesAppService :ApplicationService, ICustomerTypesAppService
{
    private readonly ICustomerTypeRepository _customerTypeRepository;
    private readonly CustomerTypeManager _customerTypeManager;

    public CustomerTypesAppService(ICustomerTypeRepository customerTypeRepository,CustomerTypeManager customerTypeManager)
    {
        _customerTypeRepository = customerTypeRepository;
        _customerTypeManager= customerTypeManager;
    }

    
        [Authorize(QuickSellPermissions.CustomerTypes.Create)]
    public virtual async Task<CustomerTypeDto> CreateAsync(CustomerTypeCreateDto input)
        {

            var customerType = await _customerTypeManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(customerType);
        }

        [Authorize(QuickSellPermissions.CustomerTypes.Create)]
    public virtual async Task<PagedResultDto<CustomerTypeDto>> GetListAsync(GetCustomerTypesInput input)
        {
            var totalCount = await _customerTypeRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _customerTypeRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CustomerTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< CustomerType>, List<CustomerTypeDto>>(items)
            };
        }


   

    public virtual async Task< CustomerTypeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(await _customerTypeRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.CustomerTypes.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _customerTypeRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.CustomerTypes.Edit)]
     public virtual async Task<CustomerTypeDto> UpdateAsync(Guid id, CustomerTypeUpdateDto input)
         {
    
            var customerType = await _customerTypeManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(customerType);
         }
    



         

        
         

}
}