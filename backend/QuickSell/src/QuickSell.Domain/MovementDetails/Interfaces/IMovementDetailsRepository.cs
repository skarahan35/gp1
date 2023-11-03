using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.MovementDetails
{
    


    public interface IMovementDetailsRepository : IRepository<MovementDetails, Guid>
{

  

  
      Task<List< MovementDetails>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string typeCode= null 
         ,int? receiptNoMin= null 
         ,int? receiptNoMax= null 
         ,int? quantityMin= null 
         ,int? quantityMax= null 
         ,int? priceMin= null 
         ,int? priceMax= null 
         ,int? discountRateMin= null 
         ,int? discountRateMax= null 
         ,int? discountAmountMin= null 
         ,int? discountAmountMax= null 
         ,int? vAtRateMin= null 
         ,int? vAtRateMax= null 
         ,int? vAtAmountMin= null 
         ,int? vAtAmountMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string typeCode= null , 
          int? receiptNoMin= null , 
          int? receiptNoMax= null ,
          int? quantityMin= null , 
          int? quantityMax= null ,
          int? priceMin= null , 
          int? priceMax= null ,
          int? discountRateMin= null , 
          int? discountRateMax= null ,
          int? discountAmountMin= null , 
          int? discountAmountMax= null ,
          int? vAtRateMin= null , 
          int? vAtRateMax= null ,
          int? vAtAmountMin= null , 
          int? vAtAmountMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}
