

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.CustomerAddresses

{
    public interface ICustomerAddressesAppService: IApplicationService
    {
        

        Task<PagedResultDto< CustomerAddressDto >> GetListAsync(GetCustomerAddressesInput input);

        Task<CustomerAddressDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CustomerAddressDto> CreateAsync(CustomerAddressCreateDto input);

        Task<CustomerAddressDto> UpdateAsync(Guid id, CustomerAddressUpdateDto input);

        
    }
}


