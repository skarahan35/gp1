

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.CustomerGroups

{
    public interface ICustomerGroupsAppService: IApplicationService
    {
        Task<LoadResult> GetListCustomerGroup(DataSourceLoadOptions loadOptions);
        Task<DxCustomerGroupLookupDto?> GetCustomerGroupByID(Guid? id);
        Task<CustomerGroupDto> AddCustomerGroup(CustomerGroupDto input);
        Task<CustomerGroupDto> UpdateCustomerGroup(Guid id, IDictionary<string, object> input);
        Task DeleteCustomerGroup(Guid id);
    }
}


