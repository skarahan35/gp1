

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.StockPrices

{
    public interface IStockPricesAppService: IApplicationService
    {
        

        Task<PagedResultDto< StockPriceDto >> GetListAsync(GetStockPricesInput input);

        Task<StockPriceDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StockPriceDto> CreateAsync(StockPriceCreateDto input);

        Task<StockPriceDto> UpdateAsync(Guid id, StockPriceUpdateDto input);

        
    }
}


