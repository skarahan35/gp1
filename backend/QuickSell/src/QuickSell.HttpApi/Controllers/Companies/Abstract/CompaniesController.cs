



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Companies;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  QuickSell.Controllers.Companies
{
    
    [Route("api/companies")]
    
    public abstract class CompaniesController : AbpController,ICompaniesAppService
    {
        private readonly ICompaniesAppService _companiesAppService;

        

        public CompaniesController(ICompaniesAppService companiesAppService)
       {
        _companiesAppService = companiesAppService;
       }

        [HttpPost]
        
        public virtual Task<CompanyDto> CreateAsync( CompanyCreateDto  input)
        {
            
                return _companiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyDto> UpdateAsync(Guid id,  CompanyUpdateDto  input)
        {
            return _companiesAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyDto>> GetListAsync(GetCompaniesInput input)
        {
            return _companiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyDto> GetAsync( Guid id)
        {
            return _companiesAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _companiesAppService.DeleteAsync(id);
        }
    }
}
