using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.StockUnits
{
    


    public interface IStockUnitRepository : IRepository<StockUnit, Guid>
{

  

  
      Task<List< StockUnit>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string code= null 
         ,string internationalCode = null 
         ,string name= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string code= null , 
          string internationalCode = null , 
          string name= null , 
        CancellationToken cancellationToken = default);

        

    }
}
