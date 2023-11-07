



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.StockPrices;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace  QuickSell.Controllers.StockPrices
{
    
    public class StockPricesController : AbpController,IStockPricesAppService
    {
        private readonly IStockPricesAppService _stockPricesAppService;

        public StockPricesController(IStockPricesAppService stockPricesAppService)
        {
        _stockPricesAppService = stockPricesAppService;
        }

        [HttpPost]
        [Route("100501")]
        public async Task<StockPriceDto> AddStockPrice(StockPriceDto input)
        {
            return await _stockPricesAppService.AddStockPrice(input);
        }
        [HttpGet]
        [Route("100504")]
        public async Task<LoadResult> GetListStockPrice(DataSourceLoadOptions loadOptions)
        {
            return await _stockPricesAppService.GetListStockPrice(loadOptions);
        }
        [HttpGet]
        [Route("100505/{id}")]
        public async Task<DxStockPriceLookupDto?> GetStockPriceByID(Guid? id)
        {
            return await _stockPricesAppService.GetStockPriceByID(id);
        }
        [HttpDelete]
        [Route("100503/{id}")]
        public async Task DeleteStockPrice(Guid id)
        {
            await _stockPricesAppService.DeleteStockPrice(id);
        }
        [HttpPut]
        [Route("100502/{id}")]
        public async Task<StockPriceDto> UpdateStockPrice(Guid id, IDictionary<string, object> input)
        {
            return await _stockPricesAppService.UpdateStockPrice(id, input);
        }
    }
}
