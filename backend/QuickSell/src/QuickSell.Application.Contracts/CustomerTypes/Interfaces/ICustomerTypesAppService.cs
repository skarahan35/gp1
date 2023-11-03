

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.CustomerTypes

{
    public interface ICustomerTypesAppService: IApplicationService
    {
        

        Task<PagedResultDto< CustomerTypeDto >> GetListAsync(GetCustomerTypesInput input);

        Task<CustomerTypeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CustomerTypeDto> CreateAsync(CustomerTypeCreateDto input);

        Task<CustomerTypeDto> UpdateAsync(Guid id, CustomerTypeUpdateDto input);

        
    }
}


