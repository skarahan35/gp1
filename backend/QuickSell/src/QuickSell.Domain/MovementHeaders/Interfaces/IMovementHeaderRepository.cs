using QuickSell.Shared;
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
         , TypeEnum? typeCode = null 
         ,int? receiptNoMin= null 
         ,int? receiptNoMax= null 
         ,decimal? firstAmountMin= null 
         ,decimal? firstAmountMax= null 
         ,decimal? discountAmountMin= null 
         ,decimal? discountAmountMax= null 
         ,decimal? vAtAmountMin= null 
         ,decimal? vAtAmountMax= null 
         ,decimal? totalAmountMin= null 
         ,decimal? totalAmountMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         , PaymentType? paymentType = null
         , CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          TypeEnum? typeCode = null , 
          int? receiptNoMin= null , 
          int? receiptNoMax= null ,
          decimal? firstAmountMin= null ,
          decimal? firstAmountMax= null ,
          decimal? discountAmountMin= null ,
          decimal? discountAmountMax= null ,
          decimal? vAtAmountMin= null ,
          decimal? vAtAmountMax= null ,
          decimal? totalAmountMin= null ,
          decimal? totalAmountMax= null ,
          PaymentType? paymentType = null,
        CancellationToken cancellationToken = default);

        

    }
}
