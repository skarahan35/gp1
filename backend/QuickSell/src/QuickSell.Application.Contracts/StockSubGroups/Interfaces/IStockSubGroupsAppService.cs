using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.StockSubGroups

{
    public interface IStockSubGroupsAppService: IApplicationService
    {
        Task<LoadResult> GetListStockSubGroup(DataSourceLoadOptions loadOptions);
        Task<DxStockSubGroupLookupDto?> GetStockSubGroupByID(Guid? id);
        Task<StockSubGroupDto> AddStockSubGroup(StockSubGroupDto input);
        Task<StockSubGroupDto> UpdateStockSubGroup(Guid id, IDictionary<string, object> input);
        Task DeleteStockSubGroup(Guid id);
    }
}


