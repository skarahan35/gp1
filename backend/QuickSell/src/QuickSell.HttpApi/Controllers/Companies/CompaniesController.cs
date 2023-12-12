



using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.Companies;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace QuickSell.Controllers.Companies
{

    public class CompaniesController : AbpController,ICompaniesAppService
    {
        private readonly ICompaniesAppService _companiesAppService;

        

        public CompaniesController(ICompaniesAppService companiesAppService)
        {
        _companiesAppService = companiesAppService;
        }

        [HttpPost]
        [Route("700401")]
        public async Task<CompanyDto> AddCompany(CompanyDto input)
        {
            return await _companiesAppService.AddCompany(input);
        }
        [HttpGet]
        [Route("700404")]
        public async Task<LoadResult> GetListCompany(DataSourceLoadOptions loadOptions)
        {
            return await _companiesAppService.GetListCompany(loadOptions);
        }
        [HttpGet]
        [Route("700405/{id}")]
        public async Task<DxCompanyLookupDto?> GetCompanyByID(Guid? id)
        {
            return await _companiesAppService.GetCompanyByID(id);
        }
        [HttpDelete]
        [Route("700403/{id}")]
        public async Task DeleteCompany(Guid id)
        {
            await _companiesAppService.DeleteCompany(id);
        }
        [HttpPut]
        [Route("700402/{id}")]
        public async Task<CompanyDto> UpdateCompany(Guid id, IDictionary<string, object> input)
        {
            return await _companiesAppService.UpdateCompany(id, input);
        }
    }
}
