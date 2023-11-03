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


namespace QuickSell.StockPrices
{
    public abstract class EfCoreStockPriceRepository : EfCoreRepository<QuickSellDbContext, StockPrice , Guid>, IStockPriceRepository
    {
        public EfCoreStockPriceRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<StockPrice>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string stockPriceType= null 
            ,int? stockPriceMin= null 
            ,int? stockPriceMax= null 
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               stockPriceType
            ,stockPriceMin 
            ,stockPriceMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StockPriceConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string stockPriceType= null 
          ,int? stockPriceMin= null 
          ,int? stockPriceMax= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,stockPriceType
           ,stockPriceMin 
           ,stockPriceMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<StockPrice> ApplyFilter(
            IQueryable<StockPrice> query,
            string filterText = null
          ,string stockPriceType= null  
          ,int? stockPriceMin= null 
          ,int? stockPriceMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.StockPriceType.Contains(filterText)) 
            .WhereIf(stockPriceMin.HasValue, e => e.StockPrice >= stockPriceMin.Value)
            .WhereIf(stockPriceMax.HasValue, e => e.StockPrice >= stockPriceMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(stockPriceType),e => e.StockPriceType.Contains(stockPriceType)) 
         ;
        }
        














        


    }
}
