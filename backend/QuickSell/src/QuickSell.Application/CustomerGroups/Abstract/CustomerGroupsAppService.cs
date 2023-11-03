
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
using QuickSell.CustomerGroups;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.CustomerGroups
{
public abstract class CustomerGroupsAppService :ApplicationService, ICustomerGroupsAppService
{
    private readonly ICustomerGroupRepository _customerGroupRepository;
    private readonly CustomerGroupManager _customerGroupManager;

    public CustomerGroupsAppService(ICustomerGroupRepository customerGroupRepository,CustomerGroupManager customerGroupManager)
    {
        _customerGroupRepository = customerGroupRepository;
        _customerGroupManager= customerGroupManager;
    }

    
        [Authorize(QuickSellPermissions.CustomerGroups.Create)]
    public virtual async Task<CustomerGroupDto> CreateAsync(CustomerGroupCreateDto input)
        {

            var customerGroup = await _customerGroupManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
        }

        [Authorize(QuickSellPermissions.CustomerGroups.Create)]
    public virtual async Task<PagedResultDto<CustomerGroupDto>> GetListAsync(GetCustomerGroupsInput input)
        {
            var totalCount = await _customerGroupRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _customerGroupRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CustomerGroupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< CustomerGroup>, List<CustomerGroupDto>>(items)
            };
        }


   

    public virtual async Task< CustomerGroupDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(await _customerGroupRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.CustomerGroups.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _customerGroupRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.CustomerGroups.Edit)]
     public virtual async Task<CustomerGroupDto> UpdateAsync(Guid id, CustomerGroupUpdateDto input)
         {
    
            var customerGroup = await _customerGroupManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
         }
    



         

        
         

}
}