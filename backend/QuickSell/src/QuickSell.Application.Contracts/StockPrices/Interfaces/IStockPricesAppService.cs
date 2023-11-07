using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.StockPrices

{
    public interface IStockPricesAppService: IApplicationService
    {
        Task<LoadResult> GetListStockPrice(DataSourceLoadOptions loadOptions);
        Task<DxStockPriceLookupDto?> GetStockPriceByID(Guid? id);
        Task<StockPriceDto> AddStockPrice(StockPriceDto input);
        Task<StockPriceDto> UpdateStockPrice(Guid id, IDictionary<string, object> input);
        Task DeleteStockPrice(Guid id);
    }
}


