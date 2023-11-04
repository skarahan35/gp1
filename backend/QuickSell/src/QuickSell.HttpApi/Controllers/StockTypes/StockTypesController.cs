



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
        [Route("100201")]
        public async Task<StockTypeDto> AddStockType(StockTypeDto input)
        {
            return await _stockTypesAppService.AddStockType(input);
        }
        [HttpGet]
        [Route("100204")]
        public async Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions)
        {
            return await _stockTypesAppService.GetListStockType(loadOptions);
        }
        [HttpGet]
        [Route("100205/{id}")]
        public async Task<DxStockTypeLookupDto?> GetStockTypeByID(Guid? id)
        {
            return await _stockTypesAppService.GetStockTypeByID(id);
        }
        [HttpDelete]
        [Route("100203/{id}")]
        public async Task DeleteStockType(Guid id)
        {
            await _stockTypesAppService.DeleteStockType(id);
        }
        [HttpPut]
        [Route("100202/{id}")]
        public async Task<StockTypeDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            return await _stockTypesAppService.UpdateStockType(id, input);
        }
    }
}
