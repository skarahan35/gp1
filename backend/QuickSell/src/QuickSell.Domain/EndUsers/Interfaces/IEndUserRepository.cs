using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QuickSell.EndUsers
{
    


    public interface IEndUserRepository : IRepository<EndUser, Guid>
{

  

  
      Task<List< EndUser>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string? userName= null 
         ,string? name= null 
         ,string? surName = null 
         ,string? eMail = null 
         ,string? phoneNumber = null 
         ,string? address = null 
         ,string? password = null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string? userName = null , 
          string? name = null , 
          string? surName = null , 
          string? eMail = null , 
          string? phoneNumber = null , 
          string? address = null , 
          string? password = null , 
        CancellationToken cancellationToken = default);

        

    }
}
