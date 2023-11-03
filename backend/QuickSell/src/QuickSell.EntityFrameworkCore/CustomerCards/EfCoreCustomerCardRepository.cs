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
             string tCNumber = null, 
             string authorizedPerson = null, 
             string eMail = null,
             int? taxNoMin = null, 
             int? taxNoMax = null,
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
               tCNumber,
               authorizedPerson,
               eMail
            ,taxNoMin 
            ,taxNoMax 
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
         string tCNumber = null, 
         string authorizedPerson = null,
         string eMail = null,
         int? taxNoMin = null, 
         int? taxNoMax = null,
         decimal? riskLimitMin = null,
         decimal? riskLimitMax = null, 
         CancellationToken cancellationToken = default)
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,code
           ,name
           ,taxOffice
           ,tCNumber
           ,authorizedPerson
           ,eMail
           ,taxNoMin 
           ,taxNoMax 
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
          ,string tCNumber= null  
          ,string authorizedPerson= null  
          ,string eMail= null  
          ,int? taxNoMin= null 
          ,int? taxNoMax= null 
          ,decimal? riskLimitMin= null 
          ,decimal? riskLimitMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Code.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Name.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.TaxOffice.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.TCNumber.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.AuthorizedPerson.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.EMail.Contains(filterText)) 
            .WhereIf(taxNoMin.HasValue, e => e.TaxNo >= taxNoMin.Value)
            .WhereIf(taxNoMax.HasValue, e => e.TaxNo >= taxNoMax.Value)
            .WhereIf(riskLimitMin.HasValue, e => e.RiskLimit >= riskLimitMin.Value)
            .WhereIf(riskLimitMax.HasValue, e => e.RiskLimit >= riskLimitMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(code),e => e.Code.Contains(code)) 
            .WhereIf(!string.IsNullOrWhiteSpace(name),e => e.Name.Contains(name)) 
            .WhereIf(!string.IsNullOrWhiteSpace(taxOffice),e => e.TaxOffice.Contains(taxOffice)) 
            .WhereIf(!string.IsNullOrWhiteSpace(tCNumber),e => e.TCNumber.Contains(tCNumber)) 
            .WhereIf(!string.IsNullOrWhiteSpace(authorizedPerson),e => e.AuthorizedPerson.Contains(authorizedPerson)) 
            .WhereIf(!string.IsNullOrWhiteSpace(eMail),e => e.EMail.Contains(eMail)) 
         ;
        }

    }
}
