

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.StockUnits

{
    public interface IStockUnitsAppService: IApplicationService
    {
        Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions);
        Task<DxStockUnitLookupDto?> GetStockTypeByID(Guid? id);
        Task<StockUnitDto> AddStockType(StockUnitDto input);
        Task<StockUnitDto> UpdateStockType(Guid id, IDictionary<string, object> input);
        Task DeleteStockType(Guid id);
    }
}


