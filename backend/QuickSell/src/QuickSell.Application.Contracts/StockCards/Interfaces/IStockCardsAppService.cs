

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.StockCards

{
    public interface IStockCardsAppService: IApplicationService
    {
        

        Task<PagedResultDto< StockCardDto >> GetListAsync(GetStockCardsInput input);

        Task<StockCardDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StockCardDto> CreateAsync(StockCardCreateDto input);

        Task<StockCardDto> UpdateAsync(Guid id, StockCardUpdateDto input);

        
    }
}


