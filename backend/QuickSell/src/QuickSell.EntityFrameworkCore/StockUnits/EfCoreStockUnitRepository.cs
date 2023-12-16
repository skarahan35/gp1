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


namespace QuickSell.StockUnits
{
    public class EfCoreStockUnitRepository : EfCoreRepository<QuickSellDbContext, StockUnit , Guid>, IStockUnitRepository
    {
        public EfCoreStockUnitRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<StockUnit>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string code= null 
            ,string name= null 
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               code
,
               name
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StockUnitConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string code= null 
          ,string name= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,code
,name
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<StockUnit> ApplyFilter(
            IQueryable<StockUnit> query,
            string filterText = null
          ,string code= null  
          ,string name= null  
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Code.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Name.Contains(filterText)) 

            .WhereIf(!string.IsNullOrWhiteSpace(code),e => e.Code.Contains(code)) 
            .WhereIf(!string.IsNullOrWhiteSpace(name),e => e.Name.Contains(name)) 
         ;
        }
        














        


    }
}
