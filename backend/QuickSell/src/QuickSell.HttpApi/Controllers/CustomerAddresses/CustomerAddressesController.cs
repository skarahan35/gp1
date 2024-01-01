using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerAddresses;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;

namespace  QuickSell.Controllers.CustomerAddresses
{

    public class CustomerAddressesController : AbpController, ICustomerAddressesAppService
    {
        private readonly ICustomerAddressesAppService _customerAddressesAppService;

        

        public CustomerAddressesController(ICustomerAddressesAppService customerAddressesAppService)
        {
            _customerAddressesAppService = customerAddressesAppService;
        }

        [HttpPost]
        [Route("200201")]
        public async Task<CustomerAddressDto> AddCustomerAddress(CustomerAddressDto input)
        {
            return await _customerAddressesAppService.AddCustomerAddress(input);
        }
        [HttpGet]
        [Route("200204")]
        public async Task<LoadResult> GetListCustomerAddress(DataSourceLoadOptions loadOptions)
        {
            return await _customerAddressesAppService.GetListCustomerAddress(loadOptions);
        }
        [HttpGet]
        [Route("200205/{id}")]
        public async Task<DxCustomerAddressLookupDto?> GetCustomerAddressByID(Guid? id)
        {
            return await _customerAddressesAppService.GetCustomerAddressByID(id);
        }
        [HttpDelete]
        [Route("200203/{id}")]
        public async Task DeleteCustomerAddress(Guid id)
        {
            await _customerAddressesAppService.DeleteCustomerAddress(id);
        }
        [HttpPut]
        [Route("200202/{id}")]
        public async Task<CustomerAddressDto> UpdateCustomerAddress(Guid id, IDictionary<string, object> input)
        {
            return await _customerAddressesAppService.UpdateCustomerAddress(id, input);
        }
        [HttpGet]
        [Route("200206/{id}")]
        public async Task<List<CustomerAddress>> GetCustomerId(Guid id)
        {
            return await _customerAddressesAppService.GetCustomerId(id);
        }
    }
}
