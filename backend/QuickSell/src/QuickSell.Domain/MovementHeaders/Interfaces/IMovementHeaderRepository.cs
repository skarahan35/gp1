using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.MovementHeaders
{
    


    public interface IMovementHeaderRepository : IRepository<MovementHeader, Guid>
{

  

  
      Task<List< MovementHeader>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string typeCode= null 
         ,int? receiptNoMin= null 
         ,int? receiptNoMax= null 
         ,int? firstAmountMin= null 
         ,int? firstAmountMax= null 
         ,int? discountAmountMin= null 
         ,int? discountAmountMax= null 
         ,int? vAtAmountMin= null 
         ,int? vAtAmountMax= null 
         ,int? totalAmountMin= null 
         ,int? totalAmountMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string typeCode= null , 
          int? receiptNoMin= null , 
          int? receiptNoMax= null ,
          int? firstAmountMin= null , 
          int? firstAmountMax= null ,
          int? discountAmountMin= null , 
          int? discountAmountMax= null ,
          int? vAtAmountMin= null , 
          int? vAtAmountMax= null ,
          int? totalAmountMin= null , 
          int? totalAmountMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}
