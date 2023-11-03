using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using QuickSell.EntityFrameworkCore;

/// <summary>
   ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
   ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
   ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

   ///  In order to be able to customize the abstract classes produced with Code Generator,
   ///  it is necessary to inherit the abstract class and customize it.
   ///  Restarting Code Generator, any customizations will be lost!!!
   /// </summary>


namespace QuickSell.MovementDetails
{
    public abstract class EfCoreMovementDetailsRepository : EfCoreRepository<QuickSellDbContext, MovementDetails , Guid>, IMovementDetailsRepository
    {
        public EfCoreMovementDetailsRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<MovementDetails>> GetListAsync(
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
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               typeCode
            ,receiptNoMin 
            ,receiptNoMax 
            ,quantityMin 
            ,quantityMax 
            ,priceMin 
            ,priceMax 
            ,discountRateMin 
            ,discountRateMax 
            ,discountAmountMin 
            ,discountAmountMax 
            ,vAtRateMin 
            ,vAtRateMax 
            ,vAtAmountMin 
            ,vAtAmountMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MovementDetailsConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
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
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,typeCode
           ,receiptNoMin 
           ,receiptNoMax 
           ,quantityMin 
           ,quantityMax 
           ,priceMin 
           ,priceMax 
           ,discountRateMin 
           ,discountRateMax 
           ,discountAmountMin 
           ,discountAmountMax 
           ,vAtRateMin 
           ,vAtRateMax 
           ,vAtAmountMin 
           ,vAtAmountMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<MovementDetails> ApplyFilter(
            IQueryable<MovementDetails> query,
            string filterText = null
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
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.TypeCode.Contains(filterText)) 
            .WhereIf(receiptNoMin.HasValue, e => e.ReceiptNo >= receiptNoMin.Value)
            .WhereIf(receiptNoMax.HasValue, e => e.ReceiptNo >= receiptNoMax.Value)
            .WhereIf(quantityMin.HasValue, e => e.Quantity >= quantityMin.Value)
            .WhereIf(quantityMax.HasValue, e => e.Quantity >= quantityMax.Value)
            .WhereIf(priceMin.HasValue, e => e.Price >= priceMin.Value)
            .WhereIf(priceMax.HasValue, e => e.Price >= priceMax.Value)
            .WhereIf(discountRateMin.HasValue, e => e.DiscountRate >= discountRateMin.Value)
            .WhereIf(discountRateMax.HasValue, e => e.DiscountRate >= discountRateMax.Value)
            .WhereIf(discountAmountMin.HasValue, e => e.DiscountAmount >= discountAmountMin.Value)
            .WhereIf(discountAmountMax.HasValue, e => e.DiscountAmount >= discountAmountMax.Value)
            .WhereIf(vAtRateMin.HasValue, e => e.VATRate >= vAtRateMin.Value)
            .WhereIf(vAtRateMax.HasValue, e => e.VATRate >= vAtRateMax.Value)
            .WhereIf(vAtAmountMin.HasValue, e => e.VATAmount >= vAtAmountMin.Value)
            .WhereIf(vAtAmountMax.HasValue, e => e.VATAmount >= vAtAmountMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(typeCode),e => e.TypeCode.Contains(typeCode)) 
         ;
        }
        














        


    }
}
