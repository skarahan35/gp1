

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.StockTypes

{
    public interface IStockTypesAppService: IApplicationService
    {
        Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions);
        Task<DxStockTypeLookupDto?> GetStockTypeByID(Guid? id);
        Task<StockTypeDto> AddStockType(StockTypeDto input);
        Task<StockTypeDto> UpdateStockType(Guid id, IDictionary<string, object> input);
        Task DeleteStockType(Guid id);
    }
}


