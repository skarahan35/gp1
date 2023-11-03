using QuickSell.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.Companies
{
    


    public interface ICompanyRepository : IRepository<Company, Guid>
{
      Task<List< Company>> GetListAsync(
         string? filterText = null
         ,string? sorting = null
         ,string? companyName= null 
         ,string? road= null 
         ,string? street= null 
         ,string? buildingName= null 
         ,string? taxOffice= null 
         ,string? currency= null 
         ,string? webSite= null 
         ,string? incomingMail= null 
         ,string? sendingMail= null 
         ,string? workingYear= null 
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
       
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string? filterText = null,
          string? companyName= null , 
          string? road= null , 
          string? street= null , 
          string? buildingName= null , 
          string? taxOffice= null , 
          string? currency= null , 
          string? webSite= null , 
          string? incomingMail= null , 
          string? sendingMail= null , 
          string? workingYear= null , 
          int? buildingNoMin= null , 
          int? buildingNoMax= null ,
          int? postCodeMin= null , 
          int? postCodeMax= null ,
          int? taxNoMin= null , 
          int? taxNoMax= null ,
          int? quantityDecimalMin= null , 
          int? quantityDecimalMax= null ,
          int? priceDecimalMin= null , 
          int? priceDecimalMax= null ,
          int? amountDecimalMin= null , 
          int? amountDecimalMax= null ,
          DateEnum? dateFormat= null , 
          
        CancellationToken cancellationToken = default);

        

    }
}
