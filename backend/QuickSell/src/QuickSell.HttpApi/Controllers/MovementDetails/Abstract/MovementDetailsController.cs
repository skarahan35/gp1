



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.MovementDetails;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.MovementDetails
{
    
    [Route("api/movement-details")]
    
    public abstract class MovementDetailsController : AbpController,IMovementDetailsAppService
    {
        private readonly IMovementDetailsAppService _movementDetailsAppService;

        

        public MovementDetailsController(IMovementDetailsAppService movementDetailsAppService)
       {
        _movementDetailsAppService = movementDetailsAppService;
       }

        [HttpPost]
        
        public virtual Task<MovementDetailsDto> CreateAsync( MovementDetailsCreateDto  input)
        {
            
                return _movementDetailsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MovementDetailsDto> UpdateAsync(Guid id,  MovementDetailsUpdateDto  input)
        {
            return _movementDetailsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MovementDetailsDto>> GetListAsync(GetMovementDetailsInput input)
        {
            return _movementDetailsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MovementDetailsDto> GetAsync( Guid id)
        {
            return _movementDetailsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _movementDetailsAppService.DeleteAsync(id);
        }
    }
}
