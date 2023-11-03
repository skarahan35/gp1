using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.StockTypes
{
    


    public interface IStockTypeRepository : IRepository<StockType, Guid>
{

  

  
      Task<List< StockType>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string code= null 
         ,string name= null 
         ,bool? condition= null 
       
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string code= null , 
          string name= null , 
          bool? condition= null , 
          
        CancellationToken cancellationToken = default);

        

    }
}
