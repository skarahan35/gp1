using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.CustomerCards
{
    


    public interface ICustomerCardRepository : IRepository<CustomerCard, Guid>
{

  

  
      Task<List< CustomerCard>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string code= null 
         ,string name= null 
         ,string taxOffice= null 
         ,string phoneNumber = null 
         ,string authorizedPerson= null 
         ,string eMail= null 
         ,int? taxNoMin= null 
         ,int? taxNoMax= null 
         ,decimal? riskLimitMin= null 
         ,decimal? riskLimitMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string code= null , 
          string name= null , 
          string taxOffice= null , 
          string phoneNumber = null , 
          string authorizedPerson= null , 
          string eMail= null , 
          int? taxNoMin= null , 
          int? taxNoMax= null ,
          decimal? riskLimitMin= null , 
          decimal? riskLimitMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}
