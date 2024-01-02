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


namespace QuickSell.StockCards
{
    public class EfCoreStockCardRepository : EfCoreRepository<QuickSellDbContext, StockCard , Guid>, IStockCardRepository
    {
        public EfCoreStockCardRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<StockCard>> GetListAsync(
             string filterText = null, 
             string sorting = null, 
             string? code = null,
             string? name = null,
             CurrencyTypeEnum? currencyType = null,
             decimal? transferredQuantityMin = null, 
             decimal? transferredQuantityMax = null, 
             decimal? availableQuantityMin = null, 
             decimal? availableQuantityMax = null, 
             decimal? totalEntryQuantityMin = null, 
             decimal? totalEntryQuantityMax = null, 
             decimal? totalOutputQuantityMin = null, 
             decimal? totalOutputQuantityMax = null,
             int? vAtRateMin = null, 
             int? vAtRateMax = null, 
             int? discountRateMin = null, 
             int? discountRateMax = null, 
             decimal? price1Min = null, 
             decimal? price1Max = null, 
             decimal? price2Min = null, 
             decimal? price2Max = null, 
             decimal? price3Min = null, 
             decimal? price3Max = null, 
             int maxResultCount = int.MaxValue,
             int skipCount = 0, 
             CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               code
,
               name
,
               currencyType
            ,transferredQuantityMin 
            ,transferredQuantityMax 
            ,availableQuantityMin 
            ,availableQuantityMax 
            ,totalEntryQuantityMin 
            ,totalEntryQuantityMax 
            ,totalOutputQuantityMin 
            ,totalOutputQuantityMax 
            ,vAtRateMin 
            ,vAtRateMax 
            ,discountRateMin 
            ,discountRateMax 
            ,price1Min 
            ,price1Max 
            ,price2Min 
            ,price2Max 
            ,price3Min 
            ,price3Max 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StockCardConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null,
         string? code = null, 
         string? name = null,
         CurrencyTypeEnum? currencyType = null, 
         decimal? transferredQuantityMin = null,
         decimal? transferredQuantityMax = null, 
         decimal? availableQuantityMin = null,
         decimal? availableQuantityMax = null, 
         decimal? totalEntryQuantityMin = null,
         decimal? totalEntryQuantityMax = null, 
         decimal? totalOutputQuantityMin = null,
         decimal? totalOutputQuantityMax = null, 
         int? vAtRateMin = null, 
         int? vAtRateMax = null, 
         int? discountRateMin = null,
         int? discountRateMax = null, 
         decimal? price1Min = null, 
         decimal? price1Max = null, 
         decimal? price2Min = null,
         decimal? price2Max = null, 
         decimal? price3Min = null, 
         decimal? price3Max = null, 
         CancellationToken cancellationToken = default)
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,code
,name
,currencyType
           ,transferredQuantityMin 
           ,transferredQuantityMax 
           ,availableQuantityMin 
           ,availableQuantityMax 
           ,totalEntryQuantityMin 
           ,totalEntryQuantityMax 
           ,totalOutputQuantityMin 
           ,totalOutputQuantityMax 
           ,vAtRateMin 
           ,vAtRateMax 
           ,discountRateMin 
           ,discountRateMax 
           ,price1Min 
           ,price1Max 
           ,price2Min 
           ,price2Max 
           ,price3Min 
           ,price3Max 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<StockCard> ApplyFilter(
            IQueryable<StockCard> query,
            string filterText = null
          ,string code= null  
          ,string name= null  
          , CurrencyTypeEnum? currencyType = null  
          ,decimal? transferredQuantityMin= null 
          ,decimal? transferredQuantityMax= null 
          ,decimal? availableQuantityMin= null 
          ,decimal? availableQuantityMax= null 
          ,decimal? totalEntryQuantityMin= null 
          ,decimal? totalEntryQuantityMax= null 
          ,decimal? totalOutputQuantityMin= null 
          ,decimal? totalOutputQuantityMax= null 
          ,int? vAtRateMin= null 
          ,int? vAtRateMax= null 
          ,int? discountRateMin= null 
          ,int? discountRateMax= null 
          ,decimal? price1Min= null 
          ,decimal? price1Max= null 
          ,decimal? price2Min= null 
          ,decimal? price2Max= null 
          ,decimal? price3Min= null 
          ,decimal? price3Max= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.Contains(filterText))
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
            .WhereIf(transferredQuantityMin.HasValue, e => e.TransferredQuantity >= transferredQuantityMin.Value)
            .WhereIf(transferredQuantityMax.HasValue, e => e.TransferredQuantity >= transferredQuantityMax.Value)
            .WhereIf(availableQuantityMin.HasValue, e => e.AvailableQuantity >= availableQuantityMin.Value)
            .WhereIf(availableQuantityMax.HasValue, e => e.AvailableQuantity >= availableQuantityMax.Value)
            .WhereIf(totalEntryQuantityMin.HasValue, e => e.TotalEntryQuantity >= totalEntryQuantityMin.Value)
            .WhereIf(totalEntryQuantityMax.HasValue, e => e.TotalEntryQuantity >= totalEntryQuantityMax.Value)
            .WhereIf(totalOutputQuantityMin.HasValue, e => e.TotalOutputQuantity >= totalOutputQuantityMin.Value)
            .WhereIf(totalOutputQuantityMax.HasValue, e => e.TotalOutputQuantity >= totalOutputQuantityMax.Value)
            .WhereIf(vAtRateMin.HasValue, e => e.VATRate >= vAtRateMin.Value)
            .WhereIf(vAtRateMax.HasValue, e => e.VATRate >= vAtRateMax.Value)
            .WhereIf(discountRateMin.HasValue, e => e.DiscountRate >= discountRateMin.Value)
            .WhereIf(discountRateMax.HasValue, e => e.DiscountRate >= discountRateMax.Value)
            .WhereIf(price1Min.HasValue, e => e.Price1 >= price1Min.Value)
            .WhereIf(price1Max.HasValue, e => e.Price1 >= price1Max.Value)
            .WhereIf(price2Min.HasValue, e => e.Price2 >= price2Min.Value)
            .WhereIf(price2Max.HasValue, e => e.Price2 >= price2Max.Value)
            .WhereIf(price3Min.HasValue, e => e.Price3 >= price3Min.Value)
            .WhereIf(price3Max.HasValue, e => e.Price3 >= price3Max.Value)
            .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
            .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
            .WhereIf(currencyType.HasValue, e => e.CurrencyType == currencyType.Value);
        }
    }
}
