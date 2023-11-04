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
        [Route("100401")]
        public async Task<StockGroupDto> AddStockGroup(StockGroupDto input)
        {
            return await _stockGroupsAppService.AddStockGroup(input);
        }
        [HttpGet]
        [Route("100404")]
        public async Task<LoadResult> GetListStockGroup(DataSourceLoadOptions loadOptions)
        {
            return await _stockGroupsAppService.GetListStockGroup(loadOptions);
        }
        [HttpGet]
        [Route("100405/{id}")]
        public async Task<DxStockGroupLookupDto?> GetStockGroupByID(Guid? id)
        {
            return await _stockGroupsAppService.GetStockGroupByID(id);
        }
        [HttpDelete]
        [Route("100403/{id}")]
        public async Task DeleteStockGroup(Guid id)
        {
            await _stockGroupsAppService.DeleteStockGroup(id);
        }
        [HttpPut]
        [Route("100402/{id}")]
        public async Task<StockGroupDto> UpdateStockGroup(Guid id, IDictionary<string, object> input)
        {
            return await _stockGroupsAppService.UpdateStockGroup(id, input);
        }
    }
}
