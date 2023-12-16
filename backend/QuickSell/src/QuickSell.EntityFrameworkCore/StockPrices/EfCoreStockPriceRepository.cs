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


namespace QuickSell.StockPrices
{
    public class EfCoreStockPriceRepository : EfCoreRepository<QuickSellDbContext, StockPrice , Guid>, IStockPriceRepository
    {
        public EfCoreStockPriceRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<StockPrice>> GetListAsync(
             string filterText = null,
             string sorting = null,
             string priceType = null, 
             decimal? priceMin = null,
             decimal? priceMax = null, 
             int maxResultCount = int.MaxValue,
             int skipCount = 0,
             CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               priceType
            ,priceMin 
            ,priceMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StockPriceConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string priceType= null 
          ,decimal? priceMin= null 
          ,decimal? priceMax= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,priceType
           ,priceMin 
           ,priceMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<StockPrice> ApplyFilter(
            IQueryable<StockPrice> query,
            string filterText = null
          ,string priceType= null  
          ,decimal? priceMin= null 
          ,decimal? priceMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.PriceType.Contains(filterText)) 
            .WhereIf(priceMin.HasValue, e => e.Price >= priceMin.Value)
            .WhereIf(priceMax.HasValue, e => e.Price >= priceMax.Value)
            .WhereIf(!string.IsNullOrWhiteSpace(priceType),e => e.PriceType.Contains(priceType));
        }
    }
}
