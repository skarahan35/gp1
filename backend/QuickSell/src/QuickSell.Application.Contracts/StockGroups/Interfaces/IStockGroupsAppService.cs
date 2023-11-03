using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.StockGroups

{
    public interface IStockGroupsAppService: IApplicationService
    {
        Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions);
        Task<DxStockGroupLookupDto?> GetStockTypeByID(Guid? id);
        Task<StockGroupDto> AddStockType(StockGroupDto input);
        Task<StockGroupDto> UpdateStockType(Guid id, IDictionary<string, object> input);
        Task DeleteStockType(Guid id);
    }
}


