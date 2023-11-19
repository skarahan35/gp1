



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Cities;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace  QuickSell.Controllers.Cities
{
    
    public class CitiesController : AbpController,ICitiesAppService
    {
        private readonly ICitiesAppService _citiesAppService;
        public CitiesController(ICitiesAppService citiesAppService)
        {
        _citiesAppService = citiesAppService;
        }

        [HttpPost]
        [Route("700201")]
        public async Task<CityDto> AddCity(CityDto input)
        {
            return await _citiesAppService.AddCity(input);
        }
        [HttpGet]
        [Route("700204")]
        public async Task<LoadResult> GetListCity(DataSourceLoadOptions loadOptions)
        {
            return await _citiesAppService.GetListCity(loadOptions);
        }
        [HttpGet]
        [Route("700205/{id}")]
        public async Task<DxCityLookupDto?> GetCityByID(Guid? id)
        {
            return await _citiesAppService.GetCityByID(id);
        }
        [HttpDelete]
        [Route("700203/{id}")]
        public async Task DeleteCity(Guid id)
        {
            await _citiesAppService.DeleteCity(id);
        }
        [HttpPut]
        [Route("700202/{id}")]
        public async Task<CityDto> UpdateCity(Guid id, IDictionary<string, object> input)
        {
            return await _citiesAppService.UpdateCity(id, input);
        }
    }
}
