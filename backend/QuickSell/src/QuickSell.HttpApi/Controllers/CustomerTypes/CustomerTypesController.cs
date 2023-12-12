using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.CustomerTypes;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System.Collections.Generic;

namespace QuickSell.Controllers.CustomerTypes
{

    public class CustomerTypesController : AbpController,ICustomerTypesAppService
    {
        private readonly ICustomerTypesAppService _customerTypesAppService;

        

        public CustomerTypesController(ICustomerTypesAppService customerTypesAppService)
        {
        _customerTypesAppService = customerTypesAppService;
        }

        [HttpPost]
        [Route("200101")]
        public async Task<CustomerTypeDto> AddCustomerType(CustomerTypeDto input)
        {
            return await _customerTypesAppService.AddCustomerType(input);
        }
        [HttpGet]
        [Route("200104")]
        public async Task<LoadResult> GetListCustomerType(DataSourceLoadOptions loadOptions)
        {
            return await _customerTypesAppService.GetListCustomerType(loadOptions);
        }
        [HttpGet]
        [Route("200105/{id}")]
        public async Task<DxCustomerTypeLookupDto?> GetCustomerTypeByID(Guid? id)
        {
            return await _customerTypesAppService.GetCustomerTypeByID(id);
        }
        [HttpDelete]
        [Route("200103/{id}")]
        public async Task DeleteCustomerType(Guid id)
        {
            await _customerTypesAppService.DeleteCustomerType(id);
        }
        [HttpPut]
        [Route("200102/{id}")]
        public async Task<CustomerTypeDto> UpdateCustomerType(Guid id, IDictionary<string, object> input)
        {
            return await _customerTypesAppService.UpdateCustomerType(id, input);
        }
    }
}
