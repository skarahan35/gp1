using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using System.Linq;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using QuickSell.Shared;

namespace QuickSell.CustomerTypes
{
    public class CustomerTypesAppService :ApplicationService, ICustomerTypesAppService
    {
        private readonly ICustomerTypeRepository _customerTypeRepository;
        private readonly CustomerTypeManager _customerTypeManager;
        private readonly IDataFilter _dataFilter;
    
        public CustomerTypesAppService(ICustomerTypeRepository customerTypeRepository,CustomerTypeManager customerTypeManager,IDataFilter dataFilter)
        {
            _customerTypeRepository = customerTypeRepository;
            _customerTypeManager= customerTypeManager;
            _dataFilter = dataFilter;
        }

        public async Task<LoadResult> GetListCustomerType(DataSourceLoadOptions loadOptions)
        {
            var getCustomerType = await _customerTypeRepository.GetQueryableAsync();

            var getJoinedData = from cstmrtyp in getCustomerType
                                select new DxCustomerTypeLookupDto
                                {
                                    Id = cstmrtyp.Id,
                                    Code = cstmrtyp.Code,
                                    Name = cstmrtyp.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCustomerTypeLookupDto?> GetCustomerTypeByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCustomerType = (await _customerTypeRepository.GetQueryableAsync());
                var customerTypes = (from cstmrtyp in getCustomerType
                                  where cstmrtyp.Id == id
                                  select new DxCustomerTypeLookupDto
                                  {
                                      Id = cstmrtyp.Id,
                                      Code = cstmrtyp.Code,
                                      Name = cstmrtyp.Name
                                  }).FirstOrDefault();
                return customerTypes;
            }
        }
        public async Task<CustomerTypeDto> AddCustomerType(CustomerTypeDto input)
        {
            var customerType = await _customerTypeManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(customerType);
        }
        public async Task<CustomerTypeDto> UpdateCustomerType(Guid id, IDictionary<string, object> input)
        {
            var customerType = await _customerTypeRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(customerType, input);
            await _customerTypeRepository.UpdateAsync(updated);
            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(updated);
        }
        public async Task DeleteCustomerType(Guid id)
        {
            await _customerTypeRepository.DeleteAsync(id);
        }
    }
}