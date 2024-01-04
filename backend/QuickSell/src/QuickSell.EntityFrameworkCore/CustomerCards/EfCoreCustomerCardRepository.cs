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



namespace QuickSell.CustomerCards
{
    public class EfCoreCustomerCardRepository : EfCoreRepository<QuickSellDbContext, CustomerCard , Guid>, ICustomerCardRepository
    {
        public EfCoreCustomerCardRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        
        public async Task<List<CustomerCard>> GetListAsync(
             string filterText = null, 
             string sorting = null, 
             string code = null,
             string name = null, 
             string taxOffice = null, 
             string phoneNumber = null, 
             string authorizedPerson = null, 
             string eMail = null,
             string? taxNo = null, 
             decimal? riskLimitMin = null,
             decimal? riskLimitMax = null, 
             int maxResultCount = int.MaxValue, 
             int skipCount = 0, 
             CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               code,
               name,
               taxOffice,
               phoneNumber,
               authorizedPerson,
               eMail
            ,taxNo
            , riskLimitMin
            , riskLimitMin
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CustomerCardConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null, 
         string code = null, 
         string name = null, 
         string taxOffice = null,
         string phoneNumber = null, 
         string authorizedPerson = null,
         string eMail = null,
         string? taxNo = null, 
         decimal? riskLimitMin = null,
         decimal? riskLimitMax = null, 
         CancellationToken cancellationToken = default)
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,code
           ,name
           ,taxOffice
           ,phoneNumber
           ,authorizedPerson
           ,eMail
           ,taxNo
           ,riskLimitMin 
           ,riskLimitMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<CustomerCard> ApplyFilter(
            IQueryable<CustomerCard> query,
            string filterText = null
          ,string code= null  
          ,string name= null  
          ,string taxOffice= null  
          ,string phoneNumber = null  
          ,string authorizedPerson= null  
          ,string eMail= null  
          , string? taxNo= null
          ,decimal? riskLimitMin= null 
          ,decimal? riskLimitMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Code.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Name.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.TaxOffice.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.PhoneNumber.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.AuthorizedPerson.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.EMail.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.TaxNo.Contains(filterText)) 
            .WhereIf(riskLimitMin.HasValue, e => e.RiskLimit >= riskLimitMin.Value)
            .WhereIf(riskLimitMax.HasValue, e => e.RiskLimit >= riskLimitMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(code),e => e.Code.Contains(code)) 
            .WhereIf(!string.IsNullOrWhiteSpace(name),e => e.Name.Contains(name)) 
            .WhereIf(!string.IsNullOrWhiteSpace(taxOffice),e => e.TaxOffice.Contains(taxOffice)) 
            .WhereIf(!string.IsNullOrWhiteSpace(phoneNumber),e => e.PhoneNumber.Contains(phoneNumber)) 
            .WhereIf(!string.IsNullOrWhiteSpace(authorizedPerson),e => e.AuthorizedPerson.Contains(authorizedPerson)) 
            .WhereIf(!string.IsNullOrWhiteSpace(eMail),e => e.EMail.Contains(eMail)) 
         ;
        }

    }
}
