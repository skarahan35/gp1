using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.CustomerAddresses
{
    


    public interface ICustomerAddressRepository : IRepository<CustomerAddress, Guid>
{

  

  
      Task<List< CustomerAddress>> GetListAsync(
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
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string addressCode= null , 
          string road= null , 
          string street= null , 
          string buildingName= null , 
          int? buildingNoMin= null , 
          int? buildingNoMax= null ,
          int? postCodeMin= null , 
          int? postCodeMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}
