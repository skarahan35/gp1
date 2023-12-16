
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;

namespace QuickSell.StockPrices
{
    public class StockPricesAppService :ApplicationService, IStockPricesAppService
    {
        private readonly IStockPriceRepository _stockPriceRepository;
        private readonly StockPriceManager _stockPriceManager;
        private readonly IDataFilter _dataFilter;

        public StockPricesAppService(IStockPriceRepository stockPriceRepository,
                                     StockPriceManager stockPriceManager,
                                     IDataFilter dataFilter)
        {
            _stockPriceRepository = stockPriceRepository;
            _stockPriceManager= stockPriceManager;
            _dataFilter= dataFilter;
        }
        public async Task<LoadResult> GetListStockPrice(DataSourceLoadOptions loadOptions)
        {
            var getStockPrice = await _stockPriceRepository.GetQueryableAsync();

            var getJoinedData = from stkprc in getStockPrice
                                select new DxStockPriceLookupDto
                                {
                                    Id = stkprc.Id,
                                    StockCardID = stkprc.StockCardID,
                                    Price = stkprc.Price
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxStockPriceLookupDto?> GetStockPriceByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getStockPrice = (await _stockPriceRepository.GetQueryableAsync());
                var stockPrice = (from stkprc in getStockPrice
                                  where stkprc.Id == id
                                  select new DxStockPriceLookupDto
                                  {
                                      Id = stkprc.Id,
                                      StockCardID = stkprc.StockCardID,
                                      Price = stkprc.Price
                                  }).FirstOrDefault();
                return stockPrice;
            }
        }
        public async Task<StockPriceDto> AddStockPrice(StockPriceDto input)
        {
            var stockPrice = await _stockPriceManager.CreateAsync(
              input.StockCardID,
              input.Price,
              input.PriceType
          );
            return ObjectMapper.Map<StockPrice, StockPriceDto>(stockPrice);
        }
        public async Task<StockPriceDto> UpdateStockPrice(Guid id, IDictionary<string, object> input)
        {
            var stockPrice = await _stockPriceRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(stockPrice, input);
            await _stockPriceRepository.UpdateAsync(updated);
            return ObjectMapper.Map<StockPrice, StockPriceDto>(updated);
        }
        public async Task DeleteStockPrice(Guid id)
        {
            await _stockPriceRepository.DeleteAsync(id);
        }

    }
}