



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Districts;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.Districts
{
    
    [Route("api/districts")]
    
    public abstract class DistrictsController : AbpController,IDistrictsAppService
    {
        private readonly IDistrictsAppService _districtsAppService;

        

        public DistrictsController(IDistrictsAppService districtsAppService)
       {
        _districtsAppService = districtsAppService;
       }

        [HttpPost]
        
        public virtual Task<DistrictDto> CreateAsync( DistrictCreateDto  input)
        {
            
                return _districtsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DistrictDto> UpdateAsync(Guid id,  DistrictUpdateDto  input)
        {
            return _districtsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<DistrictDto>> GetListAsync(GetDistrictsInput input)
        {
            return _districtsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DistrictDto> GetAsync( Guid id)
        {
            return _districtsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _districtsAppService.DeleteAsync(id);
        }
    }
}
