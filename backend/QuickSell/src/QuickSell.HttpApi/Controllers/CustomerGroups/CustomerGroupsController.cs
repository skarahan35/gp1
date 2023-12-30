
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.CustomerGroups;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.Controllers.CustomerGroups
{

    public class CustomerGroupsController : AbpController,ICustomerGroupsAppService
    {
        private readonly ICustomerGroupsAppService _customerGroupsAppService;

        

        public CustomerGroupsController(ICustomerGroupsAppService customerGroupsAppService)
        {
            _customerGroupsAppService = customerGroupsAppService;
        }
        [HttpPost]
        [Route("200401")]
        public async Task<CustomerGroupDto> AddCustomerGroup(CustomerGroupDto input)
        {
            return await _customerGroupsAppService.AddCustomerGroup(input);
        }
        [HttpGet]
        [Route("200404")]
        public async Task<LoadResult> GetListCustomerGroup(DataSourceLoadOptions loadOptions)
        {
            return await _customerGroupsAppService.GetListCustomerGroup(loadOptions);
        }
        [HttpGet]
        [Route("200405/{id}")]
        public async Task<DxCustomerGroupLookupDto?> GetCustomerGroupByID(Guid? id)
        {
            return await _customerGroupsAppService.GetCustomerGroupByID(id);
        }
        [HttpDelete]
        [Route("200403/{id}")]
        public async Task DeleteCustomerGroup(Guid id)
        {
            await _customerGroupsAppService.DeleteCustomerGroup(id);
        }
        [HttpPut]
        [Route("200402/{id}")]
        public async Task<CustomerGroupDto> UpdateCustomerGroup(Guid id, IDictionary<string, object> input)
        {
            return await _customerGroupsAppService.UpdateCustomerGroup(id, input);
        }

    }
}
