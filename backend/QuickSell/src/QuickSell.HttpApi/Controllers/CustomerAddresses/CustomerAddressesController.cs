



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerAddresses;



namespace  QuickSell.Controllers.CustomerAddresses
{
    
    public class CustomerAddressesController : AbpController,ICustomerAddressesAppService
    {
        private readonly ICustomerAddressesAppService _customerAddressesAppService;

        

        public CustomerAddressesController(ICustomerAddressesAppService customerAddressesAppService)
       {
        _customerAddressesAppService = customerAddressesAppService;
       }

    }
}
