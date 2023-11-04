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
        Task<LoadResult> GetListStockGroup(DataSourceLoadOptions loadOptions);
        Task<DxStockGroupLookupDto?> GetStockGroupByID(Guid? id);
        Task<StockGroupDto> AddStockGroup(StockGroupDto input);
        Task<StockGroupDto> UpdateStockGroup(Guid id, IDictionary<string, object> input);
        Task DeleteStockGroup(Guid id);
    }
}


