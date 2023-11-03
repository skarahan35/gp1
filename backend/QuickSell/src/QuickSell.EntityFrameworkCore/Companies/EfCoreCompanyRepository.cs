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
using QuickSell.Enums;

/// <summary>
///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

///  In order to be able to customize the abstract classes produced with Code Generator,
///  it is necessary to inherit the abstract class and customize it.
///  Restarting Code Generator, any customizations will be lost!!!
/// </summary>


namespace QuickSell.Companies
{
    public class EfCoreCompanyRepository : EfCoreRepository<QuickSellDbContext, Company , Guid>, ICompanyRepository
    {
        public EfCoreCompanyRepository(IDbContextProvider<QuickSellDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<Company>> GetListAsync(
             string? filterText = null,
             string? sorting = null, 
             string? companyName = null,
             string? road = null,
             string? street = null,
             string? buildingName = null,
             string? taxOffice = null, 
             string? currency = null,
             string? webSite = null,
             string? incomingMail = null, 
             string? sendingMail = null,
             string? workingYear = null,
             int? buildingNoMin = null,
             int? buildingNoMax = null, 
             int? postCodeMin = null,
             int? postCodeMax = null, 
             int? taxNoMin = null, 
             int? taxNoMax = null,
             int? quantityDecimalMin = null,
             int? quantityDecimalMax = null, 
             int? priceDecimalMin = null, 
             int? priceDecimalMax = null,
             int? amountDecimalMin = null, 
             int? amountDecimalMax = null, 
             DateEnum? dateFormat = null, 
             int maxResultCount = int.MaxValue,
             int skipCount = 0, CancellationToken 
            cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               companyName,
               road,
               street,
               buildingName,
               taxOffice,
               currency,
               webSite,
               incomingMail,
               sendingMail,
               workingYear,
               buildingNoMin ,
               buildingNoMax ,
               postCodeMin, 
               postCodeMax, 
               taxNoMin, 
               taxNoMax, 
               quantityDecimalMin, 
               quantityDecimalMax, 
               priceDecimalMin, 
               priceDecimalMax, 
               amountDecimalMin, 
               amountDecimalMax, 
               dateFormat
          
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string companyName= null 
          ,string road= null 
          ,string street= null 
          ,string buildingName= null 
          ,string taxOffice= null 
          ,string currency= null 
          ,string webSite= null 
          ,string incomingMail= null 
          ,string sendingMail= null 
          ,string workingYear= null 
          ,int? buildingNoMin= null 
          ,int? buildingNoMax= null 
          ,int? postCodeMin= null 
          ,int? postCodeMax= null 
          ,int? taxNoMin= null 
          ,int? taxNoMax= null 
          ,int? quantityDecimalMin= null 
          ,int? quantityDecimalMax= null 
          ,int? priceDecimalMin= null 
          ,int? priceDecimalMax= null 
          ,int? amountDecimalMin= null 
          ,int? amountDecimalMax= null 
           , DateEnum? dateFormat= null 
          
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,companyName
           ,road
           ,street
           ,buildingName
           ,taxOffice
           ,currency
           ,webSite
           ,incomingMail
           ,sendingMail
           ,workingYear
           ,buildingNoMin 
           ,buildingNoMax 
           ,postCodeMin 
           ,postCodeMax 
           ,taxNoMin 
           ,taxNoMax 
           ,quantityDecimalMin 
           ,quantityDecimalMax 
           ,priceDecimalMin 
           ,priceDecimalMax 
           ,amountDecimalMin 
           ,amountDecimalMax 
           ,dateFormat   
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<Company> ApplyFilter(
            IQueryable<Company> query,
            string filterText = null
          ,string companyName= null  
          ,string road= null  
          ,string street= null  
          ,string buildingName= null  
          ,string taxOffice= null  
          ,string currency= null  
          ,string webSite= null  
          ,string incomingMail= null  
          ,string sendingMail= null  
          ,string workingYear= null  
          ,int? buildingNoMin= null 
          ,int? buildingNoMax= null 
          ,int? postCodeMin= null 
          ,int? postCodeMax= null 
          ,int? taxNoMin= null 
          ,int? taxNoMax= null 
          ,int? quantityDecimalMin= null 
          ,int? quantityDecimalMax= null 
          ,int? priceDecimalMin= null 
          ,int? priceDecimalMax= null 
          ,int? amountDecimalMin= null 
          ,int? amountDecimalMax= null 
          ,DateEnum? dateFormat= null 
          
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.CompanyName.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Road.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Street.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.BuildingName.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.TaxOffice.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Currency.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.WebSite.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.IncomingMail.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.SendingMail.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.WorkingYear.Contains(filterText)) 
            .WhereIf(buildingNoMin.HasValue, e => e.BuildingNo >= buildingNoMin.Value)
            .WhereIf(buildingNoMax.HasValue, e => e.BuildingNo >= buildingNoMax.Value)
            .WhereIf(postCodeMin.HasValue, e => e.PostCode >= postCodeMin.Value)
            .WhereIf(postCodeMax.HasValue, e => e.PostCode >= postCodeMax.Value)
            .WhereIf(taxNoMin.HasValue, e => e.TaxNo >= taxNoMin.Value)
            .WhereIf(taxNoMax.HasValue, e => e.TaxNo >= taxNoMax.Value)
            .WhereIf(quantityDecimalMin.HasValue, e => e.QuantityDecimal >= quantityDecimalMin.Value)
            .WhereIf(quantityDecimalMax.HasValue, e => e.QuantityDecimal >= quantityDecimalMax.Value)
            .WhereIf(priceDecimalMin.HasValue, e => e.PriceDecimal >= priceDecimalMin.Value)
            .WhereIf(priceDecimalMax.HasValue, e => e.PriceDecimal >= priceDecimalMax.Value)
            .WhereIf(amountDecimalMin.HasValue, e => e.AmountDecimal >= amountDecimalMin.Value)
            .WhereIf(amountDecimalMax.HasValue, e => e.AmountDecimal >= amountDecimalMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(companyName),e => e.CompanyName.Contains(companyName)) 
            .WhereIf(!string.IsNullOrWhiteSpace(road),e => e.Road.Contains(road)) 
            .WhereIf(!string.IsNullOrWhiteSpace(street),e => e.Street.Contains(street)) 
            .WhereIf(!string.IsNullOrWhiteSpace(buildingName),e => e.BuildingName.Contains(buildingName)) 
            .WhereIf(!string.IsNullOrWhiteSpace(taxOffice),e => e.TaxOffice.Contains(taxOffice)) 
            .WhereIf(!string.IsNullOrWhiteSpace(currency),e => e.Currency.Contains(currency)) 
            .WhereIf(!string.IsNullOrWhiteSpace(webSite),e => e.WebSite.Contains(webSite)) 
            .WhereIf(!string.IsNullOrWhiteSpace(incomingMail),e => e.IncomingMail.Contains(incomingMail)) 
            .WhereIf(!string.IsNullOrWhiteSpace(sendingMail),e => e.SendingMail.Contains(sendingMail)) 
            .WhereIf(!string.IsNullOrWhiteSpace(workingYear),e => e.WorkingYear.Contains(workingYear)) 
         ;
        }
    }
}
