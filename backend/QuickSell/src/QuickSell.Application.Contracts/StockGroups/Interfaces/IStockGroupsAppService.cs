

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.StockGroups

{
    public interface IStockGroupsAppService: IApplicationService
    {
        

        Task<PagedResultDto< StockGroupDto >> GetListAsync(GetStockGroupsInput input);

        Task<StockGroupDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StockGroupDto> CreateAsync(StockGroupCreateDto input);

        Task<StockGroupDto> UpdateAsync(Guid id, StockGroupUpdateDto input);

        
    }
}


