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
              string code, 
              string name, 
              string currencyType, 
              int? transferredQuantity, 
    
              int? availableQuantity, 
    
              int? totalEntryQuantity, 
    
              int? totalOutputQuantity, 
    
              int? vAtRate, 
    
              int? discountRate, 
    
              int? price1, 
    
              int? price2, 
    
              int? price3, 
    
              Guid? stockTypeId,
              Guid? stockUnitId,
              Guid? stockGroupId,
        )
        {

            var stockCard = new StockCard(
             GuidGenerator.Create(),
               code, 
               name, 
               currencyType, 
               transferredQuantity, 
    
               availableQuantity, 
    
               totalEntryQuantity, 
    
               totalOutputQuantity, 
    
               vAtRate, 
    
               discountRate, 
    
               price1, 
    
               price2, 
    
               price3, 
    
               stockTypeId,
               stockUnitId,
               stockGroupId,
             );

            return await _stockCardRepository.InsertAsync(stockCard);
        }

        public async Task<StockCard> UpdateAsync(
           Guid id,
          string code, 
          string name, 
          string currencyType, 
          int? transferredQuantity, 

          int? availableQuantity, 

          int? totalEntryQuantity, 

          int? totalOutputQuantity, 

          int? vAtRate, 

          int? discountRate, 

          int? price1, 

          int? price2, 

          int? price3, 

          Guid? stockTypeId,
          Guid? stockUnitId,
          Guid? stockGroupId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockCardRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockCard = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockCard.Code=code;
                stockCard.Name=name;
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
                stockCard.StockTypeId=stockTypeId;
                stockCard.StockUnitId=stockUnitId;
                stockCard.StockGroupId=stockGroupId;

         stockCard.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockCardRepository.UpdateAsync(stockCard);
        }

    }
}