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
using QuickSell.Shared;

namespace QuickSell.MovementHeaders
{
    public class EfCoreMovementHeaderRepository : EfCoreRepository<QuickSellDbContext, MovementHeader , Guid>, IMovementHeaderRepository
    {
        public EfCoreMovementHeaderRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<MovementHeader>> GetListAsync(
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
            , CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               typeCode
            ,receiptNoMin 
            ,receiptNoMax 
            ,firstAmountMin 
            ,firstAmountMax 
            ,discountAmountMin 
            ,discountAmountMax 
            ,vAtAmountMin 
            ,vAtAmountMax 
            ,totalAmountMin 
            ,totalAmountMax 
            ,paymentType 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MovementHeaderConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
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
          , PaymentType? paymentType = null
          , CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,typeCode
           ,receiptNoMin 
           ,receiptNoMax 
           ,firstAmountMin 
           ,firstAmountMax 
           ,discountAmountMin 
           ,discountAmountMax 
           ,vAtAmountMin 
           ,vAtAmountMax 
           ,totalAmountMin 
           ,totalAmountMax 
           ,paymentType 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<MovementHeader> ApplyFilter(
            IQueryable<MovementHeader> query,
            string filterText = null
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
          ,PaymentType? paymentType= null )
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(receiptNoMin.HasValue, e => e.ReceiptNo >= receiptNoMin.Value)
            .WhereIf(receiptNoMax.HasValue, e => e.ReceiptNo >= receiptNoMax.Value)
            .WhereIf(firstAmountMin.HasValue, e => e.FirstAmount >= firstAmountMin.Value)
            .WhereIf(firstAmountMax.HasValue, e => e.FirstAmount >= firstAmountMax.Value)
            .WhereIf(discountAmountMin.HasValue, e => e.DiscountAmount >= discountAmountMin.Value)
            .WhereIf(discountAmountMax.HasValue, e => e.DiscountAmount >= discountAmountMax.Value)
            .WhereIf(vAtAmountMin.HasValue, e => e.VATAmount >= vAtAmountMin.Value)
            .WhereIf(vAtAmountMax.HasValue, e => e.VATAmount >= vAtAmountMax.Value)
            .WhereIf(totalAmountMin.HasValue, e => e.TotalAmount >= totalAmountMin.Value)
            .WhereIf(totalAmountMax.HasValue, e => e.TotalAmount >= totalAmountMax.Value)

            .WhereIf(paymentType.HasValue, e => e.PaymentType == paymentType.Value)
            .WhereIf(typeCode.HasValue, e => e.TypeCode == typeCode.Value)
         ;
        }

    }
}
