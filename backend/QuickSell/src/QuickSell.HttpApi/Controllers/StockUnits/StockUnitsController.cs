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
        [Route("1-3-1")]
        public async Task<StockUnitDto> AddStockType(StockUnitDto input)
        {
            return await _stockUnitsAppService.AddStockType(input);
        }
        [HttpGet]
        [Route("1-3-4")]
        public async Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions)
        {
            return await _stockUnitsAppService.GetListStockType(loadOptions);
        }
        [HttpGet]
        [Route("1-3-5/{id}")]
        public async Task<DxStockUnitLookupDto?> GetStockTypeByID(Guid? id)
        {
            return await _stockUnitsAppService.GetStockTypeByID(id);
        }
        [HttpDelete]
        [Route("1-3-3")]
        public async Task DeleteStockType(Guid id)
        {
            await _stockUnitsAppService.DeleteStockType(id);
        }
        [HttpPut]
        [Route("1-3-2/{id}")]
        public async Task<StockUnitDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            return await _stockUnitsAppService.UpdateStockType(id, input);
        }

    }
}
