

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.StockUnits

{
    public interface IStockUnitsAppService: IApplicationService
    {
        

        Task<PagedResultDto< StockUnitDto >> GetListAsync(GetStockUnitsInput input);

        Task<StockUnitDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StockUnitDto> CreateAsync(StockUnitCreateDto input);

        Task<StockUnitDto> UpdateAsync(Guid id, StockUnitUpdateDto input);

        
    }
}


