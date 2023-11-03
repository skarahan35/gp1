



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerTypes;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.CustomerTypes
{
    
    [Route("api/customer-types")]
    
    public abstract class CustomerTypesController : AbpController,ICustomerTypesAppService
    {
        private readonly ICustomerTypesAppService _customerTypesAppService;

        

        public CustomerTypesController(ICustomerTypesAppService customerTypesAppService)
       {
        _customerTypesAppService = customerTypesAppService;
       }

        [HttpPost]
        
        public virtual Task<CustomerTypeDto> CreateAsync( CustomerTypeCreateDto  input)
        {
            
                return _customerTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CustomerTypeDto> UpdateAsync(Guid id,  CustomerTypeUpdateDto  input)
        {
            return _customerTypesAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CustomerTypeDto>> GetListAsync(GetCustomerTypesInput input)
        {
            return _customerTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CustomerTypeDto> GetAsync( Guid id)
        {
            return _customerTypesAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _customerTypesAppService.DeleteAsync(id);
        }
    }
}
