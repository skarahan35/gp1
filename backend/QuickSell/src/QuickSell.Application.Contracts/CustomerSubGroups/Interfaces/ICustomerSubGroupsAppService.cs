

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.CustomerSubGroups

{
    public interface ICustomerSubGroupsAppService: IApplicationService
    {
        Task<LoadResult> GetListCustomerSubGroup(DataSourceLoadOptions loadOptions);
        Task<DxCustomerSubGroupLookupDto?> GetCustomerSubGroupByID(Guid? id);
        Task<CustomerSubGroupDto> AddCustomerSubGroup(CustomerSubGroupDto input);
        Task<CustomerSubGroupDto> UpdateCustomerSubGroup(Guid id, IDictionary<string, object> input);
        Task DeleteCustomerSubGroup(Guid id);

    }
}


