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


namespace QuickSell.CustomerAddresses
{
    public abstract class EfCoreCustomerAddressRepository : EfCoreRepository<QuickSellDbContext, CustomerAddress , Guid>, ICustomerAddressRepository
    {
        public EfCoreCustomerAddressRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<CustomerAddress>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string addressCode= null 
            ,string road= null 
            ,string street= null 
            ,string buildingName= null 
            ,int? buildingNoMin= null 
            ,int? buildingNoMax= null 
            ,int? postCodeMin= null 
            ,int? postCodeMax= null 
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               addressCode
,
               road
,
               street
,
               buildingName
            ,buildingNoMin 
            ,buildingNoMax 
            ,postCodeMin 
            ,postCodeMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CustomerAddressConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string addressCode= null 
          ,string road= null 
          ,string street= null 
          ,string buildingName= null 
          ,int? buildingNoMin= null 
          ,int? buildingNoMax= null 
          ,int? postCodeMin= null 
          ,int? postCodeMax= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,addressCode
,road
,street
,buildingName
           ,buildingNoMin 
           ,buildingNoMax 
           ,postCodeMin 
           ,postCodeMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<CustomerAddress> ApplyFilter(
            IQueryable<CustomerAddress> query,
            string filterText = null
          ,string addressCode= null  
          ,string road= null  
          ,string street= null  
          ,string buildingName= null  
          ,int? buildingNoMin= null 
          ,int? buildingNoMax= null 
          ,int? postCodeMin= null 
          ,int? postCodeMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.AddressCode.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Road.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Street.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.BuildingName.Contains(filterText)) 
            .WhereIf(buildingNoMin.HasValue, e => e.BuildingNo >= buildingNoMin.Value)
            .WhereIf(buildingNoMax.HasValue, e => e.BuildingNo >= buildingNoMax.Value)
            .WhereIf(postCodeMin.HasValue, e => e.PostCode >= postCodeMin.Value)
            .WhereIf(postCodeMax.HasValue, e => e.PostCode >= postCodeMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(addressCode),e => e.AddressCode.Contains(addressCode)) 
            .WhereIf(!string.IsNullOrWhiteSpace(road),e => e.Road.Contains(road)) 
            .WhereIf(!string.IsNullOrWhiteSpace(street),e => e.Street.Contains(street)) 
            .WhereIf(!string.IsNullOrWhiteSpace(buildingName),e => e.BuildingName.Contains(buildingName)) 
         ;
        }
        














        


    }
}
