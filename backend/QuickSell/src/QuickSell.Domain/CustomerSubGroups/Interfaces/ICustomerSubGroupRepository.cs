using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.CustomerSubGroups
{
    


    public interface ICustomerSubGroupRepository : IRepository<CustomerSubGroup, Guid>
{

  

  
      Task<List< CustomerSubGroup>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string? code= null 
         ,string? name= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string? code= null , 
          string? name= null , 
        CancellationToken cancellationToken = default);

        

    }
}
