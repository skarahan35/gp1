



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockTypes;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace  QuickSell.Controllers.StockTypes
{
    public class StockTypesController : AbpController,IStockTypesAppService
    {
        private readonly IStockTypesAppService _stockTypesAppService;
        public StockTypesController(IStockTypesAppService stockTypesAppService)
        {
            _stockTypesAppService = stockTypesAppService;
        }
        [HttpPost]
        [Route("api/stock-types/stock-type-add")]
        public async Task<StockTypeDto> AddStockType(StockTypeDto input)
        {
            return await _stockTypesAppService.AddStockType(input);
        }
        [HttpGet]
        [Route("stock-type-getlist")]
        public async Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions)
        {
            return await _stockTypesAppService.GetListStockType(loadOptions);
        }
        [HttpGet]
        [Route("stock-type-getbyid/{id}")]
        public async Task<DxStockTypeLookupDto?> GetStockTypeByID(Guid? id)
        {
            return await _stockTypesAppService.GetStockTypeByID(id);
        }
        [HttpDelete]
        [Route("stock-type-delete")]
        public async Task DeleteStockType(Guid id)
        {
            await _stockTypesAppService.DeleteStockType(id);
        }
        [HttpPut]
        [Route("stock-type-update/{id}")]
        public async Task<StockTypeDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            return await _stockTypesAppService.UpdateStockType(id, input);
        }
    }
}
