using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockUnits;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace  QuickSell.Controllers.StockUnits
{
    
    public class StockUnitsController : AbpController,IStockUnitsAppService
    {
        private readonly IStockUnitsAppService _stockUnitsAppService;
        public StockUnitsController(IStockUnitsAppService stockUnitsAppService)
       {
        _stockUnitsAppService = stockUnitsAppService;
       }
        [HttpPost]
        [Route("100301")]
        public async Task<StockUnitDto> AddStockUnit(StockUnitDto input)
        {
            return await _stockUnitsAppService.AddStockUnit(input);
        }
        [HttpGet]
        [Route("100304")]
        public async Task<LoadResult> GetListStockUnit(DataSourceLoadOptions loadOptions)
        {
            return await _stockUnitsAppService.GetListStockUnit(loadOptions);
        }
        [HttpGet]
        [Route("100305/{id}")]
        public async Task<DxStockUnitLookupDto?> GetStockUnitByID(Guid? id)
        {
            return await _stockUnitsAppService.GetStockUnitByID(id);
        }
        [HttpDelete]
        [Route("100303/{id}")]
        public async Task DeleteStockUnit(Guid id)
        {
            await _stockUnitsAppService.DeleteStockUnit(id);
        }
        [HttpPut]
        [Route("100302/{id}")]
        public async Task<StockUnitDto> UpdateStockUnit(Guid id, IDictionary<string, object> input)
        {
            return await _stockUnitsAppService.UpdateStockUnit(id, input);
        }

    }
}
