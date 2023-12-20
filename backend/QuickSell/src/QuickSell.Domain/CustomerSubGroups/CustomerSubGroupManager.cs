using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.CustomerSubGroups
{
    public class CustomerSubGroupManager : DomainService
    {
        private readonly ICustomerSubGroupRepository _customerSubGroupRepository;

        public CustomerSubGroupManager(ICustomerSubGroupRepository customerSubGroupRepository)
        {
            _customerSubGroupRepository = customerSubGroupRepository;
        }

        public async Task<CustomerSubGroup> CreateAsync(
              string? code, 
              string? name
        )
        {

            var customerSubGroup = new CustomerSubGroup(
             GuidGenerator.Create(),
               code, 
               name
             );

            return await _customerSubGroupRepository.InsertAsync(customerSubGroup);
        }

        public async Task<CustomerSubGroup> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _customerSubGroupRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var customerSubGroup = await AsyncExecuter.FirstOrDefaultAsync(query);

                customerSubGroup.Code=code;
                customerSubGroup.Name=name;

         customerSubGroup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _customerSubGroupRepository.UpdateAsync(customerSubGroup);
        }

    }
}