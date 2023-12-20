using Volo.Abp.Application.Services;

namespace QuickSell.CustomerSubGroups
{
    public class CustomerSubGroupsAppService : ApplicationService, ICustomerSubGroupsAppService
    {
        private readonly ICustomerSubGroupRepository _customerSubGroupRepository;
        private readonly CustomerSubGroupManager _customerSubGroupManager;

        public CustomerSubGroupsAppService(ICustomerSubGroupRepository customerSubGroupRepository, CustomerSubGroupManager customerSubGroupManager)
        {
            _customerSubGroupRepository = customerSubGroupRepository;
            _customerSubGroupManager = customerSubGroupManager;
        }

    }
}