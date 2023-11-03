using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.StockPrices
{
    public class StockPriceManager : DomainService
    {
        private readonly IStockPriceRepository _stockPriceRepository;

        public StockPriceManager(IStockPriceRepository stockPriceRepository)
        {
            _stockPriceRepository = stockPriceRepository;
        }

        public async Task<StockPrice> CreateAsync(
              Guid? stockCardID,
              int? price,
              string priceType
        )
        {

            var stockPrice = new StockPrice(
             GuidGenerator.Create(),
               stockCardID,
               price,
               priceType
             );

            return await _stockPriceRepository.InsertAsync(stockPrice);
        }

        public async Task<StockPrice> UpdateAsync(
            Guid id,
           Guid? stockCardID,
           int? price,
           string priceType,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockPriceRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockPrice = await AsyncExecuter.FirstOrDefaultAsync(query);
                stockPrice.StockCardID = stockCardID;
                stockPrice.Price=price;
                 stockPrice.PriceType=priceType;

         stockPrice.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockPriceRepository.UpdateAsync(stockPrice);
        }

    }
}