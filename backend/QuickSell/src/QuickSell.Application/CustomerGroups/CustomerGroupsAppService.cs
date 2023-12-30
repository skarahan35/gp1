
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
using QuickSell.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.ObjectMapping;

namespace QuickSell.CustomerGroups
{
    public class CustomerGroupsAppService :ApplicationService, ICustomerGroupsAppService
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupManager _customerGroupManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;


        public CustomerGroupsAppService(ICustomerGroupRepository customerGroupRepository,
                                        CustomerGroupManager customerGroupManager,
                                        IDataFilter dataFilter,
                                        IStringLocalizer<QuickSellResource> localizer)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupManager= customerGroupManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
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
        public async Task CustomerGroupValidation(CustomerGroupDto input)
        {
            var qry = await _customerGroupRepository.GetQueryableAsync();
            await Validation<CustomerGroup, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<CustomerGroup, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<CustomerGroupDto> AddCustomerGroup(CustomerGroupDto input)
        {
            await CustomerGroupValidation(input);
            var customerGroup = await _customerGroupManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
        }
        public async Task<CustomerGroupDto> UpdateCustomerGroup(Guid id, IDictionary<string, object> input)
        {
            var customerGroup = await _customerGroupRepository.GetAsync(id);
            var customerGroupDto = ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
            await DevExtremeUpdate.Update(customerGroupDto, input);

            return await UpdateCustomerGroup(customerGroupDto.Id, customerGroupDto);
        }
        public async Task<CustomerGroupDto> UpdateCustomerGroup(Guid id, CustomerGroupDto input)
        {
            await CustomerGroupValidation(input);
            var customerGroup = await _customerGroupManager.UpdateAsync(
                id,
                input.Code,
                input.Name
            );
            await _customerGroupRepository.UpdateAsync(customerGroup);

            return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
        }
        public async Task DeleteCustomerGroup(Guid id)
        {
            await _customerGroupRepository.DeleteAsync(id);
        }

    }
}