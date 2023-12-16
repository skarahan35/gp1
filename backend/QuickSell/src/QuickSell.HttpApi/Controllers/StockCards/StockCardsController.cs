using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.StockCards;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace QuickSell.Controllers.StockCards
{

    
    public class StockCardsController : AbpController,IStockCardsAppService
    {
        private readonly IStockCardsAppService _stockCardsAppService;

        public StockCardsController(IStockCardsAppService stockCardsAppService)
        {
            _stockCardsAppService = stockCardsAppService;
        }

        [HttpPost]
        [Route("100101")]
        public async Task<StockCardDto> AddStockCard(StockCardDto input)
        {
            return await _stockCardsAppService.AddStockCard(input);
        }
        [HttpGet]
        [Route("100104")]
        public async Task<LoadResult> GetListStockCard(DataSourceLoadOptions loadOptions)
        {
            return await _stockCardsAppService.GetListStockCard(loadOptions);
        }
        [HttpGet]
        [Route("100105/{id}")]
        public async Task<DxStockCardLookupDto?> GetStockCardByID(Guid? id)
        {
            return await _stockCardsAppService.GetStockCardByID(id);
        }
        [HttpDelete]
        [Route("100103/{id}")]
        public async Task DeleteStockCard(Guid id)
        {
            await _stockCardsAppService.DeleteStockCard(id);
        }
        [HttpPut]
        [Route("100102/{id}")]
        public async Task<StockCardDto> UpdateStockCard(Guid id, IDictionary<string, object> input)
        {
            return await _stockCardsAppService.UpdateStockCard(id, input);
        }
    }
}
