using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.CustomerGroups
{
    public class CustomerGroupManager : DomainService
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupManager(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        public async Task<CustomerGroup> CreateAsync(
              string? code, 
              string? name
        )
        {

            var customerGroup = new CustomerGroup(
             GuidGenerator.Create(),
               code, 
               name
             );

            return await _customerGroupRepository.InsertAsync(customerGroup);
        }

        public async Task<CustomerGroup> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _customerGroupRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var customerGroup = await AsyncExecuter.FirstOrDefaultAsync(query);

                customerGroup.Code=code;
                customerGroup.Name=name;

         customerGroup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _customerGroupRepository.UpdateAsync(customerGroup);
        }

    }
}