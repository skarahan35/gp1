
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.CustomerCards;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;

namespace QuickSell.Controllers.CustomerCards
{

    public class CustomerCardsController : AbpController,ICustomerCardsAppService
    {
        private readonly ICustomerCardsAppService _customerCardsAppService;

        

        public CustomerCardsController(ICustomerCardsAppService customerCardsAppService)
        {
            _customerCardsAppService = customerCardsAppService;
        }

        [HttpPost]
        [Route("200301")]
        public async Task<CustomerCardDto> AddCustomerCard(CustomerCardDto input)
        {
            return await _customerCardsAppService.AddCustomerCard(input);
        }
        [HttpGet]
        [Route("200304")]
        public async Task<LoadResult> GetListCustomerCard(DataSourceLoadOptions loadOptions)
        {
            return await _customerCardsAppService.GetListCustomerCard(loadOptions);
        }
        [HttpGet]
        [Route("200305/{id}")]
        public async Task<DxCustomerCardLookupDto?> GetCustomerCardByID(Guid? id)
        {
            return await _customerCardsAppService.GetCustomerCardByID(id);
        }
        [HttpDelete]
        [Route("200303/{id}")]
        public async Task DeleteCustomerCard(Guid id)
        {
            await _customerCardsAppService.DeleteCustomerCard(id);
        }
        [HttpPut]
        [Route("200302/{id}")]
        public async Task<CustomerCardDto> UpdateCustomerCard(Guid id, IDictionary<string, object> input)
        {
            return await _customerCardsAppService.UpdateCustomerCard(id, input);
        }
    }
}
