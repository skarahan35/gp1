using Volo.Abp.AspNetCore.Mvc;
using QuickSell.CustomerSubGroups;

namespace QuickSell.Controllers.CustomerSubGroups
{

    public class CustomerSubGroupsController : AbpController, ICustomerSubGroupsAppService
    {
        private readonly ICustomerSubGroupsAppService _customerSubGroupsAppService;



        public CustomerSubGroupsController(ICustomerSubGroupsAppService customerSubGroupsAppService)
        {
            _customerSubGroupsAppService = customerSubGroupsAppService;
        }
    }
}
