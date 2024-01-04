using Volo.Abp.AspNetCore.Mvc;
using QuickSell.StockSubGroups;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System;

namespace QuickSell.Controllers.StockSubGroups
{
    public class StockSubGroupsController : AbpController, IStockSubGroupsAppService
    {
        private readonly IStockSubGroupsAppService _stockSubGroupsAppService;



        public StockSubGroupsController(IStockSubGroupsAppService stockSubGroupsAppService)
        {
            _stockSubGroupsAppService = stockSubGroupsAppService;
        }
        [HttpPost]
        [Route("100601")]
        public async Task<StockSubGroupDto> AddStockSubGroup(StockSubGroupDto input)
        {
            return await _stockSubGroupsAppService.AddStockSubGroup(input);
        }
        [HttpGet]
        [Route("100604")]
        public async Task<LoadResult> GetListStockSubGroup(DataSourceLoadOptions loadOptions)
        {
            return await _stockSubGroupsAppService.GetListStockSubGroup(loadOptions);
        }
        [HttpGet]
        [Route("100605/{id}")]
        public async Task<DxStockSubGroupLookupDto?> GetStockSubGroupByID(Guid? id)
        {
            return await _stockSubGroupsAppService.GetStockSubGroupByID(id);
        }
        [HttpDelete]
        [Route("100603/{id}")]
        public async Task DeleteStockSubGroup(Guid id)
        {
            await _stockSubGroupsAppService.DeleteStockSubGroup(id);
        }
        [HttpPut]
        [Route("100602/{id}")]
        public async Task<StockSubGroupDto> UpdateStockSubGroup(Guid id, IDictionary<string, object> input)
        {
            return await _stockSubGroupsAppService.UpdateStockSubGroup(id, input);
        }
    }
}
