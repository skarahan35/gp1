



using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.Countries;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace QuickSell.Controllers.Countries
{
    public  class CountriesController : AbpController,ICountriesAppService
    {
        private readonly ICountriesAppService _countriesAppService;

        public CountriesController(ICountriesAppService countriesAppService)
        {
        _countriesAppService = countriesAppService;
        }

        [HttpPost]
        [Route("700101")]
        public async Task<CountryDto> AddCountry(CountryDto input)
        {
            return await _countriesAppService.AddCountry(input);
        }
        [HttpGet]
        [Route("700104")]
        public async Task<LoadResult> GetListCountry(DataSourceLoadOptions loadOptions)
        {
            return await _countriesAppService.GetListCountry(loadOptions);
        }
        [HttpGet]
        [Route("700105/{id}")]
        public async Task<DxCountryLookupDto?> GetCountryByID(Guid? id)
        {
            return await _countriesAppService.GetCountryByID(id);
        }
        [HttpDelete]
        [Route("700103/{id}")]
        public async Task DeleteCountry(Guid id)
        {
            await _countriesAppService.DeleteCountry(id);
        }
        [HttpPut]
        [Route("700102/{id}")]
        public async Task<CountryDto> UpdateCountry(Guid id, IDictionary<string, object> input)
        {
            return await _countriesAppService.UpdateCountry(id, input);
        }

    }
}
