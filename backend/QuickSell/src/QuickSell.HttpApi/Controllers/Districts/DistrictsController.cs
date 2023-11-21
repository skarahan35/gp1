using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.Districts;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace QuickSell.Controllers.Districts
{


    public class DistrictsController : AbpController,IDistrictsAppService
    {
        private readonly IDistrictsAppService _districtsAppService;

        

        public DistrictsController(IDistrictsAppService districtsAppService)
        {
        _districtsAppService = districtsAppService;
        }
        [HttpPost]
        [Route("700301")]
        public async Task<DistrictDto> AddDistrict(DistrictDto input)
        {
            return await _districtsAppService.AddDistrict(input);
        }
        [HttpGet]
        [Route("700304")]
        public async Task<LoadResult> GetListDistrict(DataSourceLoadOptions loadOptions)
        {
            return await _districtsAppService.GetListDistrict(loadOptions);
        }
        [HttpGet]
        [Route("700305/{id}")]
        public async Task<DxDistrictLookupDto?> GetDistrictByID(Guid? id)
        {
            return await _districtsAppService.GetDistrictByID(id);
        }
        [HttpDelete]
        [Route("700303/{id}")]
        public async Task DeleteDistrict(Guid id)
        {
            await _districtsAppService.DeleteDistrict(id);
        }
        [HttpPut]
        [Route("700302/{id}")]
        public async Task<DistrictDto> UpdateDistrict(Guid id, IDictionary<string, object> input)
        {
            return await _districtsAppService.UpdateDistrict(id, input);
        }
    }
}
