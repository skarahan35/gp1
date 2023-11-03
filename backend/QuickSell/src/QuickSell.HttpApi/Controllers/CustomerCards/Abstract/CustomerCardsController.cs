



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerCards;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.CustomerCards
{
    
    [Route("api/customer-cards")]
    
    public abstract class CustomerCardsController : AbpController,ICustomerCardsAppService
    {
        private readonly ICustomerCardsAppService _customerCardsAppService;

        

        public CustomerCardsController(ICustomerCardsAppService customerCardsAppService)
       {
        _customerCardsAppService = customerCardsAppService;
       }

        [HttpPost]
        
        public virtual Task<CustomerCardDto> CreateAsync( CustomerCardCreateDto  input)
        {
            
                return _customerCardsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CustomerCardDto> UpdateAsync(Guid id,  CustomerCardUpdateDto  input)
        {
            return _customerCardsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CustomerCardDto>> GetListAsync(GetCustomerCardsInput input)
        {
            return _customerCardsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CustomerCardDto> GetAsync( Guid id)
        {
            return _customerCardsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _customerCardsAppService.DeleteAsync(id);
        }
    }
}
