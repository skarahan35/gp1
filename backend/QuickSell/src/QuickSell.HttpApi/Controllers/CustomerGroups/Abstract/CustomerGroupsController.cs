



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerGroups;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.CustomerGroups
{
    
    [Route("api/customer-groups")]
    
    public abstract class CustomerGroupsController : AbpController,ICustomerGroupsAppService
    {
        private readonly ICustomerGroupsAppService _customerGroupsAppService;

        

        public CustomerGroupsController(ICustomerGroupsAppService customerGroupsAppService)
       {
        _customerGroupsAppService = customerGroupsAppService;
       }

        [HttpPost]
        
        public virtual Task<CustomerGroupDto> CreateAsync( CustomerGroupCreateDto  input)
        {
            
                return _customerGroupsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CustomerGroupDto> UpdateAsync(Guid id,  CustomerGroupUpdateDto  input)
        {
            return _customerGroupsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CustomerGroupDto>> GetListAsync(GetCustomerGroupsInput input)
        {
            return _customerGroupsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CustomerGroupDto> GetAsync( Guid id)
        {
            return _customerGroupsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _customerGroupsAppService.DeleteAsync(id);
        }
    }
}
