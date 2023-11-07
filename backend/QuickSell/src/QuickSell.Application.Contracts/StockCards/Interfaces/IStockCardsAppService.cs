

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.StockCards

{
    public interface IStockCardsAppService: IApplicationService
    {
        Task<LoadResult> GetListStockCard(DataSourceLoadOptions loadOptions);
        Task<DxStockCardLookupDto?> GetStockCardByID(Guid? id);
        Task<StockCardDto> AddStockCard(StockCardDto input);
        Task<StockCardDto> UpdateStockCard(Guid id, IDictionary<string, object> input);
        Task DeleteStockCard(Guid id);
    }
}


