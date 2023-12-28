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


namespace QuickSell.EndUsers
{
    public class EfCoreEndUserRepository : EfCoreRepository<QuickSellDbContext, EndUser , Guid>, IEndUserRepository
    {
        public EfCoreEndUserRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<EndUser>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string userName= null 
            ,string name= null 
            ,string surName= null 
            ,string eMail= null 
            ,string phoneNumber= null 
            ,string address= null 
            ,string password= null 
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               userName
,
               name
,
               surName
,
               eMail
,
               phoneNumber
,
               address
,
               password
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? EndUserConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string userName= null 
          ,string name= null 
          ,string surName= null 
          ,string eMail= null 
          ,string phoneNumber= null 
          ,string address= null 
          ,string password= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,userName
,name
,surName
,eMail
,phoneNumber
,address
,password
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<EndUser> ApplyFilter(
            IQueryable<EndUser> query,
            string filterText = null
          ,string userName= null  
          ,string name= null  
          ,string surName= null  
          ,string eMail= null  
          ,string phoneNumber= null  
          ,string address= null  
          ,string password= null  
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.UserName.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Name.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.SurName.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.EMail.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.PhoneNumber.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Address.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Password.Contains(filterText)) 

            .WhereIf(!string.IsNullOrWhiteSpace(userName),e => e.UserName.Contains(userName)) 
            .WhereIf(!string.IsNullOrWhiteSpace(name),e => e.Name.Contains(name)) 
            .WhereIf(!string.IsNullOrWhiteSpace(surName),e => e.SurName.Contains(surName)) 
            .WhereIf(!string.IsNullOrWhiteSpace(eMail),e => e.EMail.Contains(eMail)) 
            .WhereIf(!string.IsNullOrWhiteSpace(phoneNumber),e => e.PhoneNumber.Contains(phoneNumber)) 
            .WhereIf(!string.IsNullOrWhiteSpace(address),e => e.Address.Contains(address)) 
            .WhereIf(!string.IsNullOrWhiteSpace(password),e => e.Password.Contains(password)) 
         ;
        }
        














        


    }
}
