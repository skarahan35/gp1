using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.EndUsers
{
    public class EndUserManager : DomainService
    {
        private readonly IEndUserRepository _endUserRepository;

        public EndUserManager(IEndUserRepository endUserRepository)
        {
            _endUserRepository = endUserRepository;
        }

        public async Task<EndUser> CreateAsync(
              string? userName, 
              string? name, 
              string? surName, 
              string? eMail, 
              string? phoneNumber, 
              string? address, 
              string? password 
        )
        {

            var endUser = new EndUser(
             GuidGenerator.Create(),
               userName, 
               name, 
               surName, 
               eMail, 
               phoneNumber, 
               address, 
               password
             );

            return await _endUserRepository.InsertAsync(endUser);
        }

        public async Task<EndUser> UpdateAsync(
           Guid id,
          string? userName, 
          string? name, 
          string? surName, 
          string? eMail, 
          string? phoneNumber, 
          string? address, 
          string? password, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _endUserRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var endUser = await AsyncExecuter.FirstOrDefaultAsync(query);

                endUser.UserName=userName;
                endUser.Name=name;
                endUser.SurName=surName;
                endUser.EMail=eMail;
                endUser.PhoneNumber=phoneNumber;
                endUser.Address=address;
                endUser.Password=password;

         endUser.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _endUserRepository.UpdateAsync(endUser);
        }

    }
}