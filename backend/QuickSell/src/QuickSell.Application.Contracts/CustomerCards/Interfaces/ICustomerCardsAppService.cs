

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.CustomerCards

{
    public interface ICustomerCardsAppService: IApplicationService
    {
        

        Task<PagedResultDto< CustomerCardDto >> GetListAsync(GetCustomerCardsInput input);

        Task<CustomerCardDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CustomerCardDto> CreateAsync(CustomerCardCreateDto input);

        Task<CustomerCardDto> UpdateAsync(Guid id, CustomerCardUpdateDto input);

        
    }
}


