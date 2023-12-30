using Volo.Abp.AspNetCore.Mvc;
using QuickSell.CustomerSubGroups;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System;
using System.Collections.Generic;

namespace QuickSell.Controllers.CustomerSubGroups
{

    public class CustomerSubGroupsController : AbpController, ICustomerSubGroupsAppService
    {
        private readonly ICustomerSubGroupsAppService _customerSubGroupsAppService;



        public CustomerSubGroupsController(ICustomerSubGroupsAppService customerSubGroupsAppService)
        {
            _customerSubGroupsAppService = customerSubGroupsAppService;
        }
        [HttpPost]
        [Route("200501")]
        public async Task<CustomerSubGroupDto> AddCustomerSubGroup(CustomerSubGroupDto input)
        {
            return await _customerSubGroupsAppService.AddCustomerSubGroup(input);
        }
        [HttpGet]
        [Route("200504")]
        public async Task<LoadResult> GetListCustomerSubGroup(DataSourceLoadOptions loadOptions)
        {
            return await _customerSubGroupsAppService.GetListCustomerSubGroup(loadOptions);
        }
        [HttpGet]
        [Route("200505/{id}")]
        public async Task<DxCustomerSubGroupLookupDto?> GetCustomerSubGroupByID(Guid? id)
        {
            return await _customerSubGroupsAppService.GetCustomerSubGroupByID(id);
        }
        [HttpDelete]
        [Route("200503/{id}")]
        public async Task DeleteCustomerSubGroup(Guid id)
        {
            await _customerSubGroupsAppService.DeleteCustomerSubGroup(id);
        }
        [HttpPut]
        [Route("200502/{id}")]
        public async Task<CustomerSubGroupDto> UpdateCustomerSubGroup(Guid id, IDictionary<string, object> input)
        {
            return await _customerSubGroupsAppService.UpdateCustomerSubGroup(id, input);
        }
    }
}
