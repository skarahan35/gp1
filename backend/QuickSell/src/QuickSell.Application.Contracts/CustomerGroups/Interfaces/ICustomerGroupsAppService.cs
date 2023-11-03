

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.CustomerGroups

{
    public interface ICustomerGroupsAppService: IApplicationService
    {
        

        Task<PagedResultDto< CustomerGroupDto >> GetListAsync(GetCustomerGroupsInput input);

        Task<CustomerGroupDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CustomerGroupDto> CreateAsync(CustomerGroupCreateDto input);

        Task<CustomerGroupDto> UpdateAsync(Guid id, CustomerGroupUpdateDto input);

        
    }
}


