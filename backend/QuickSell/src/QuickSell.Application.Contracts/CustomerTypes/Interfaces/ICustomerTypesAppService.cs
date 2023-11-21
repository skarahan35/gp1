

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.CustomerTypes

{
    public interface ICustomerTypesAppService: IApplicationService
    {
        Task<LoadResult> GetListCustomerType(DataSourceLoadOptions loadOptions);
        Task<DxCustomerTypeLookupDto?> GetCustomerTypeByID(Guid? id);
        Task<CustomerTypeDto> AddCustomerType(CustomerTypeDto input);
        Task<CustomerTypeDto> UpdateCustomerType(Guid id, IDictionary<string, object> input);
        Task DeleteCustomerType(Guid id);

    }
}


