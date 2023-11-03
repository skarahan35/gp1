



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerTypes;



namespace  QuickSell.Controllers.CustomerTypes
{
    
    public class CustomerTypesController : AbpController,ICustomerTypesAppService
    {
        private readonly ICustomerTypesAppService _customerTypesAppService;

        

        public CustomerTypesController(ICustomerTypesAppService customerTypesAppService)
       {
        _customerTypesAppService = customerTypesAppService;
       }

        
    }
}
