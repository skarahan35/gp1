



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerGroups;



namespace  QuickSell.Controllers.CustomerGroups
{
    
    public class CustomerGroupsController : AbpController,ICustomerGroupsAppService
    {
        private readonly ICustomerGroupsAppService _customerGroupsAppService;

        

        public CustomerGroupsController(ICustomerGroupsAppService customerGroupsAppService)
       {
        _customerGroupsAppService = customerGroupsAppService;
       }

        
    }
}
