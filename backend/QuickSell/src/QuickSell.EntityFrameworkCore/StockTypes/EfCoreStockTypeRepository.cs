using Microsoft.EntityFrameworkCore;
using QuickSell.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QuickSell.StockTypes
{
    public class EfCoreStockTypeRepository : EfCoreRepository<QuickSellDbContext, StockType, Guid>, IStockTypeRepository
    {
        public EfCoreStockTypeRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }




        public async Task<List<StockType>> GetListAsync(
             string filterText = null
            , string sorting = null
            , string code = null
            , string name = null

            , int maxResultCount = int.MaxValue
            , int skipCount = 0
            , CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText,
               code,
               name

            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StockTypeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          , string code = null
          , string name = null
          , ApprovalStatusEnum? approvalStatus = null
          , DateTime? dateLockMin = null
          , DateTime? dateLockMax = null
          , DateTime? datePassiveMin = null
          , DateTime? datePassiveMax = null
              , CheckStockQuantityEnum? checkStockQuantity = null
         , StockBelowOptMinEnum? stockBelowOptimum = null
         , StockBelowOptMinEnum? stockBelowMinimum = null
         , YesOrNoEnum? isPassive = null

           , CancellationToken cancellationToken = default
            )
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code
   , name
   , approvalStatus
              , dateLockMax
              , dateLockMin
              , datePassiveMax
              , datePassiveMin
              , checkStockQuantity
              , stockBelowOptimum
              , stockBelowMinimum
              , isPassive
            );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<StockType> ApplyFilter(
            IQueryable<StockType> query,
            string filterText = null
          , string code = null
          , string name = null
          , ApprovalStatusEnum? approvalStatus = null
          , DateTime? dateLockMin = null
          , DateTime? dateLockMax = null
          , DateTime? datePassiveMin = null
          , DateTime? datePassiveMax = null
              , CheckStockQuantityEnum? checkStockQuantity = null
         , StockBelowOptMinEnum? stockBelowOptimum = null
         , StockBelowOptMinEnum? stockBelowMinimum = null
         , YesOrNoEnum? isPassive = null


)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.Contains(filterText))
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
            .WhereIf(dateLockMin.HasValue, e => e.DateLock >= dateLockMin.Value)
            .WhereIf(dateLockMax.HasValue, e => e.DateLock >= dateLockMax.Value)
            .WhereIf(datePassiveMin.HasValue, e => e.DatePassive >= datePassiveMin.Value)
            .WhereIf(datePassiveMax.HasValue, e => e.DatePassive >= datePassiveMax.Value)
            .WhereIf(checkStockQuantity.HasValue, e => e.CheckStockQuantity == checkStockQuantity.Value)
            .WhereIf(stockBelowOptimum.HasValue, e => e.StockBelowOptimum == stockBelowOptimum.Value)
            .WhereIf(stockBelowMinimum.HasValue, e => e.StockBelowMinimum == stockBelowMinimum.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
            .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
            .WhereIf(approvalStatus.HasValue, e => e.ApprovalStatus >= approvalStatus.Value)
         ;
        }
    }
