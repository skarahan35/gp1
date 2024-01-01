using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.MovementDetails
{
    


    public interface IMovementDetailsRepository : IRepository<MovementDetail, Guid>
{

  

  
      Task<List< MovementDetail>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string typeCode= null 
         ,int? receiptNoMin= null 
         ,int? receiptNoMax= null 
         ,decimal? quantityMin= null 
         ,decimal? quantityMax= null 
         ,decimal? priceMin= null 
         ,decimal? priceMax= null 
         ,decimal? discountRateMin= null 
         ,decimal? discountRateMax= null 
         ,decimal? discountAmountMin= null 
         ,decimal? discountAmountMax= null 
         ,decimal? vAtRateMin= null 
         ,decimal? vAtRateMax= null 
         ,decimal? vAtAmountMin= null 
         ,decimal? vAtAmountMax= null 
         ,decimal? firstAmountMin= null 
         ,decimal? firstAmountMax= null 
         ,decimal? totalAmountMin= null 
         ,decimal? totalAmountMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string typeCode= null , 
          int? receiptNoMin= null , 
          int? receiptNoMax= null ,
          decimal? quantityMin= null , 
          decimal? quantityMax= null ,
          decimal? priceMin= null , 
          decimal? priceMax= null ,
          decimal? discountRateMin= null , 
          decimal? discountRateMax= null ,
          decimal? discountAmountMin= null , 
          decimal? discountAmountMax= null ,
          decimal? vAtRateMin= null , 
          decimal? vAtRateMax= null ,
          decimal? vAtAmountMin= null , 
          decimal? vAtAmountMax= null ,
          decimal? firstAmountMin = null,
          decimal? firstAmountMax = null,
          decimal? totalAmountMin = null,
          decimal? totalAmountMax = null,
        CancellationToken cancellationToken = default);

        

    }
}
