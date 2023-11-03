



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerAddresses;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.CustomerAddresses
{
    
    [Route("api/customer-addresses")]
    
    public abstract class CustomerAddressesController : AbpController,ICustomerAddressesAppService
    {
        private readonly ICustomerAddressesAppService _customerAddressesAppService;

        

        public CustomerAddressesController(ICustomerAddressesAppService customerAddressesAppService)
       {
        _customerAddressesAppService = customerAddressesAppService;
       }

        [HttpPost]
        
        public virtual Task<CustomerAddressDto> CreateAsync( CustomerAddressCreateDto  input)
        {
            
                return _customerAddressesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CustomerAddressDto> UpdateAsync(Guid id,  CustomerAddressUpdateDto  input)
        {
            return _customerAddressesAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CustomerAddressDto>> GetListAsync(GetCustomerAddressesInput input)
        {
            return _customerAddressesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CustomerAddressDto> GetAsync( Guid id)
        {
            return _customerAddressesAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _customerAddressesAppService.DeleteAsync(id);
        }
    }
}
