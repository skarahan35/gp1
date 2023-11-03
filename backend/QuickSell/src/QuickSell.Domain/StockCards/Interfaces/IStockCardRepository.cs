using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.StockCards
{
    


    public interface IStockCardRepository : IRepository<StockCard, Guid>
{

  

  
      Task<List< StockCard>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string? code= null 
         ,string? name= null 
         ,string currencyType= null 
         ,decimal? transferredQuantityMin= null 
         ,decimal? transferredQuantityMax= null 
         ,decimal? availableQuantityMin= null 
         ,decimal? availableQuantityMax= null 
         ,decimal? totalEntryQuantityMin= null 
         ,decimal? totalEntryQuantityMax= null 
         ,decimal? totalOutputQuantityMin= null 
         ,decimal? totalOutputQuantityMax= null 
         ,int? vAtRateMin= null 
         ,int? vAtRateMax= null 
         ,int? discountRateMin= null 
         ,int? discountRateMax= null 
         ,decimal? price1Min= null 
         ,decimal? price1Max= null 
         ,decimal? price2Min= null 
         ,decimal? price2Max= null 
         ,decimal? price3Min= null 
         ,decimal? price3Max= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string? code= null , 
          string? name= null , 
          string currencyType= null , 
          decimal? transferredQuantityMin= null , 
          decimal? transferredQuantityMax= null ,
          decimal? availableQuantityMin= null , 
          decimal? availableQuantityMax= null ,
          decimal? totalEntryQuantityMin= null , 
          decimal? totalEntryQuantityMax= null ,
          decimal? totalOutputQuantityMin= null , 
          decimal? totalOutputQuantityMax= null ,
          int? vAtRateMin= null , 
          int? vAtRateMax= null ,
          int? discountRateMin= null , 
          int? discountRateMax= null ,
          decimal? price1Min= null , 
          decimal? price1Max= null ,
          decimal? price2Min= null , 
          decimal? price2Max= null ,
          decimal? price3Min= null , 
          decimal? price3Max= null ,
        CancellationToken cancellationToken = default);

        

    }
}
