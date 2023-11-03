



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.MovementHeaders;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.MovementHeaders
{
    
    [Route("api/movement-headers")]
    
    public abstract class MovementHeadersController : AbpController,IMovementHeadersAppService
    {
        private readonly IMovementHeadersAppService _movementHeadersAppService;

        

        public MovementHeadersController(IMovementHeadersAppService movementHeadersAppService)
       {
        _movementHeadersAppService = movementHeadersAppService;
       }

        [HttpPost]
        
        public virtual Task<MovementHeaderDto> CreateAsync( MovementHeaderCreateDto  input)
        {
            
                return _movementHeadersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MovementHeaderDto> UpdateAsync(Guid id,  MovementHeaderUpdateDto  input)
        {
            return _movementHeadersAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MovementHeaderDto>> GetListAsync(GetMovementHeadersInput input)
        {
            return _movementHeadersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MovementHeaderDto> GetAsync( Guid id)
        {
            return _movementHeadersAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _movementHeadersAppService.DeleteAsync(id);
        }
    }
}
