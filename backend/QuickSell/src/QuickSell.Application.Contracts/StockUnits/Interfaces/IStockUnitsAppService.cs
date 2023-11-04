

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
        Task<LoadResult> GetListStockUnit(DataSourceLoadOptions loadOptions);
        Task<DxStockUnitLookupDto?> GetStockUnitByID(Guid? id);
        Task<StockUnitDto> AddStockUnit(StockUnitDto input);
        Task<StockUnitDto> UpdateStockUnit(Guid id, IDictionary<string, object> input);
        Task DeleteStockUnit(Guid id);
    }
}


