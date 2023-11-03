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
         ,string code= null 
         ,string name= null 
         ,string currencyType= null 
         ,int? transferredQuantityMin= null 
         ,int? transferredQuantityMax= null 
         ,int? availableQuantityMin= null 
         ,int? availableQuantityMax= null 
         ,int? totalEntryQuantityMin= null 
         ,int? totalEntryQuantityMax= null 
         ,int? totalOutputQuantityMin= null 
         ,int? totalOutputQuantityMax= null 
         ,int? vAtRateMin= null 
         ,int? vAtRateMax= null 
         ,int? discountRateMin= null 
         ,int? discountRateMax= null 
         ,int? price1Min= null 
         ,int? price1Max= null 
         ,int? price2Min= null 
         ,int? price2Max= null 
         ,int? price3Min= null 
         ,int? price3Max= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string code= null , 
          string name= null , 
          string currencyType= null , 
          int? transferredQuantityMin= null , 
          int? transferredQuantityMax= null ,
          int? availableQuantityMin= null , 
          int? availableQuantityMax= null ,
          int? totalEntryQuantityMin= null , 
          int? totalEntryQuantityMax= null ,
          int? totalOutputQuantityMin= null , 
          int? totalOutputQuantityMax= null ,
          int? vAtRateMin= null , 
          int? vAtRateMax= null ,
          int? discountRateMin= null , 
          int? discountRateMax= null ,
          int? price1Min= null , 
          int? price1Max= null ,
          int? price2Min= null , 
          int? price2Max= null ,
          int? price3Min= null , 
          int? price3Max= null ,
        CancellationToken cancellationToken = default);

        

    }
}
