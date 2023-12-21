using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using Volo.Abp.Data;
using System.Linq;

namespace QuickSell.CustomerSubGroups
{
    public class CustomerSubGroupsAppService : ApplicationService, ICustomerSubGroupsAppService
    {
        private readonly ICustomerSubGroupRepository _customerSubGroupRepository;
        private readonly CustomerSubGroupManager _customerSubGroupManager;
        private readonly IDataFilter _dataFilter;

        public CustomerSubGroupsAppService(ICustomerSubGroupRepository customerSubGroupRepository,
                                           CustomerSubGroupManager customerSubGroupManager,
                                           IDataFilter dataFilter)
        {
            _customerSubGroupRepository = customerSubGroupRepository;
            _customerSubGroupManager = customerSubGroupManager;
            _dataFilter = dataFilter;
        }
        public async Task<LoadResult> GetListCustomerSubGroup(DataSourceLoadOptions loadOptions)
        {
            var getCustomerSubGroup = await _customerSubGroupRepository.GetQueryableAsync();

            var getJoinedData = from cstmrsbgrp in getCustomerSubGroup
                                select new DxCustomerSubGroupLookupDto
                                {
                                    Id = cstmrsbgrp.Id,
                                    Code = cstmrsbgrp.Code,
                                    Name = cstmrsbgrp.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCustomerSubGroupLookupDto?> GetCustomerSubGroupByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCustomerSubGroup = (await _customerSubGroupRepository.GetQueryableAsync());
                var CustomerSubGroup = (from cstmrsbgrp in getCustomerSubGroup
                                     where cstmrsbgrp.Id == id
                                     select new DxCustomerSubGroupLookupDto
                                     {
                                         Id = cstmrsbgrp.Id,
                                         Code = cstmrsbgrp.Code,
                                         Name = cstmrsbgrp.Name
                                     }).FirstOrDefault();
                return CustomerSubGroup;
            }
        }
        public async Task<CustomerSubGroupDto> AddCustomerSubGroup(CustomerSubGroupDto input)
        {
            var customerSubGroup = await _customerSubGroupManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<CustomerSubGroup, CustomerSubGroupDto>(customerSubGroup);
        }
        public async Task<CustomerSubGroupDto> UpdateCustomerSubGroup(Guid id, IDictionary<string, object> input)
        {
            var customerSubGroup = await _customerSubGroupRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(customerSubGroup, input);
            await _customerSubGroupRepository.UpdateAsync(updated);
            return ObjectMapper.Map<CustomerSubGroup, CustomerSubGroupDto>(updated);
        }
        public async Task DeleteCustomerSubGroup(Guid id)
        {
            await _customerSubGroupRepository.DeleteAsync(id);
        }
    }
}