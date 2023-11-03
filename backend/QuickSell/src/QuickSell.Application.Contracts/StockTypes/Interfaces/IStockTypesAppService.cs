

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.StockTypes

{
    public interface IStockTypesAppService: IApplicationService
    {
        

        Task<PagedResultDto< StockTypeDto >> GetListAsync(GetStockTypesInput input);

        Task<StockTypeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StockTypeDto> CreateAsync(StockTypeCreateDto input);

        Task<StockTypeDto> UpdateAsync(Guid id, StockTypeUpdateDto input);

        
    }
}


