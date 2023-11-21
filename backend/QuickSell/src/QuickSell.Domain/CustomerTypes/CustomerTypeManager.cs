using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.CustomerTypes
{
    public class CustomerTypeManager : DomainService
    {
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public CustomerTypeManager(ICustomerTypeRepository customerTypeRepository)
        {
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<CustomerType> CreateAsync(
              string? code, 
              string? name
        )
        {

            var customerType = new CustomerType(
             GuidGenerator.Create(),
               code, 
               name
             );

            return await _customerTypeRepository.InsertAsync(customerType);
        }

        public async Task<CustomerType> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _customerTypeRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var customerType = await AsyncExecuter.FirstOrDefaultAsync(query);

                customerType.Code=code;
                customerType.Name=name;

         customerType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _customerTypeRepository.UpdateAsync(customerType);
        }

    }
}