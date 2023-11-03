using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.StockPrices
{
    


    public interface IStockPriceRepository : IRepository<StockPrice, Guid>
{

  

  
      Task<List< StockPrice>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string stockPriceType= null 
         ,int? stockPriceMin= null 
         ,int? stockPriceMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string stockPriceType= null , 
          int? stockPriceMin= null , 
          int? stockPriceMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}
