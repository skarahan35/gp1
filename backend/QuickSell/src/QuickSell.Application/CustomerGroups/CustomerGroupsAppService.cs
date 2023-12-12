
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickSell.Permissions;
using QuickSell.CustomerGroups;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using Volo.Abp.Data;
using QuickSell.Tools;

namespace QuickSell.CustomerGroups
{
    public class CustomerGroupsAppService :ApplicationService, ICustomerGroupsAppService
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupManager _customerGroupManager;
        private readonly IDataFilter _dataFilter;
    
        public CustomerGroupsAppService(ICustomerGroupRepository customerGroupRepository,
                                        CustomerGroupManager customerGroupManager,
                                        IDataFilter dataFilter)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupManager= customerGroupManager;
            _dataFilter = dataFilter;
        }
        public async Task<LoadResult> GetListCustomerGroup(DataSourceLoadOptions loadOptions)
        {
            var getCustomerGroup = await _customerGroupRepository.GetQueryableAsync();

            var getJoinedData = from cstmrgrp in getCustomerGroup
                                select new DxCustomerGroupLookupDto
                                {
                                    Id = cstmrgrp.Id,
                                    Code = cstmrgrp.Code,
                                    Name = cstmrgrp.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCustomerGroupLookupDto?> GetCustomerGroupByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCustomerGroup = (await _customerGroupRepository.GetQueryableAsync());
                var customerGroup = (from cstmrgrp in getCustomerGroup
                                     where cstmrgrp.Id == id
                                  select new DxCustomerGroupLookupDto
                                  {
                                      Id = cstmrgrp.Id,
                                      Code = cstmrgrp.Code,
                                      Name = cstmrgrp.Name
                                  }).FirstOrDefault();
                return customerGroup;
            }
        }
        public async Task<CustomerGroupDto> AddCustomerGroup(CustomerGroupDto input)
        {
            var customerGroup = await _customerGroupManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
        }
        public async Task<CustomerGroupDto> UpdateCustomerGroup(Guid id, IDictionary<string, object> input)
        {
            var customerGroup = await _customerGroupRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(customerGroup, input);
            await _customerGroupRepository.UpdateAsync(updated);
            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(updated);
        }
        public async Task DeleteCustomerGroup(Guid id)
        {
            await _customerGroupRepository.DeleteAsync(id);
        }

    }
}