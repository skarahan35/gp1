using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.StockCards
{
    public class StockCardManager : DomainService
    {
        private readonly IStockCardRepository _stockCardRepository;

        public StockCardManager(IStockCardRepository stockCardRepository)
        {
            _stockCardRepository = stockCardRepository;
        }

        public async Task<StockCard> CreateAsync(
              string? code, 
              string? name,
              Guid? stockTypeID,
              Guid? stockUnitID,
              Guid? stockGroupID,
              string currencyType, 
              decimal? transferredQuantity, 
              decimal? availableQuantity, 
              decimal? totalEntryQuantity, 
              decimal? totalOutputQuantity, 
              int? vAtRate, 
              int? discountRate, 
              decimal? price1, 
              decimal? price2, 
              decimal? price3
              
        )
        {

            var stockCard = new StockCard(
             GuidGenerator.Create(),
               code, 
               name,
               stockTypeID,
               stockUnitID,
               stockGroupID,
               currencyType, 
               transferredQuantity, 
               availableQuantity, 
               totalEntryQuantity, 
               totalOutputQuantity, 
               vAtRate, 
               discountRate, 
               price1, 
               price2, 
               price3
             );

            return await _stockCardRepository.InsertAsync(stockCard);
        }

        public async Task<StockCard> UpdateAsync(
           Guid id,
          string? code, 
          string? name,
          Guid? stockTypeID,
          Guid? stockUnitID,
          Guid? stockGroupID,
          string currencyType, 
          decimal? transferredQuantity, 
          decimal? availableQuantity, 
          decimal? totalEntryQuantity, 
          decimal? totalOutputQuantity, 
          int? vAtRate, 
          int? discountRate, 
          decimal? price1, 
          decimal? price2, 
          decimal? price3, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockCardRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockCard = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockCard.Code=code;
                stockCard.Name=name;
                stockCard.StockTypeID = stockTypeID;
                stockCard.StockUnitID = stockUnitID;
                stockCard.StockGroupID = stockGroupID;
                stockCard.CurrencyType=currencyType;
                 stockCard.TransferredQuantity=transferredQuantity;
                 stockCard.AvailableQuantity=availableQuantity;
                 stockCard.TotalEntryQuantity=totalEntryQuantity;
                 stockCard.TotalOutputQuantity=totalOutputQuantity;
                 stockCard.VATRate=vAtRate;
                 stockCard.DiscountRate=discountRate;
                 stockCard.Price1=price1;
                 stockCard.Price2=price2;
                 stockCard.Price3=price3;

         stockCard.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockCardRepository.UpdateAsync(stockCard);
        }

    }
}