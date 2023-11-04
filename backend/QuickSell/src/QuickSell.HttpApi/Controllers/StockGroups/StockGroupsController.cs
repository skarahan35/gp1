using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockGroups;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace  QuickSell.Controllers.StockGroups
{
    
    public class StockGroupsController : AbpController,IStockGroupsAppService
    {
        private readonly IStockGroupsAppService _stockGroupsAppService;

        

        public StockGroupsController(IStockGroupsAppService stockGroupsAppService)
       {
        _stockGroupsAppService = stockGroupsAppService;
       }
        [HttpPost]
        [Route("1-4-1")]
        public async Task<StockGroupDto> AddStockType(StockGroupDto input)
        {
            return await _stockGroupsAppService.AddStockType(input);
        }
        [HttpGet]
        [Route("1-4-4")]
        public async Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions)
        {
            return await _stockGroupsAppService.GetListStockType(loadOptions);
        }
        [HttpGet]
        [Route("1-4-5/{id}")]
        public async Task<DxStockGroupLookupDto?> GetStockTypeByID(Guid? id)
        {
            return await _stockGroupsAppService.GetStockTypeByID(id);
        }
        [HttpDelete]
        [Route("1-4-3")]
        public async Task DeleteStockType(Guid id)
        {
            await _stockGroupsAppService.DeleteStockType(id);
        }
        [HttpPut]
        [Route("1-4-2/{id}")]
        public async Task<StockGroupDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            return await _stockGroupsAppService.UpdateStockType(id, input);
        }
    }
}
