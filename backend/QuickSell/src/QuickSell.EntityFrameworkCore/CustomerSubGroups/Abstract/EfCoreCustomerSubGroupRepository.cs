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


namespace QuickSell.CustomerSubGroups
{
    public abstract class EfCoreCustomerSubGroupRepository : EfCoreRepository<QuickSellDbContext, CustomerSubGroup , Guid>, ICustomerSubGroupRepository
    {
        public EfCoreCustomerSubGroupRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<CustomerSubGroup>> GetListAsync(
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
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CustomerSubGroupConsts.GetDefaultSorting(false) : sorting);
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


        protected virtual IQueryable<CustomerSubGroup> ApplyFilter(
            IQueryable<CustomerSubGroup> query,
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
