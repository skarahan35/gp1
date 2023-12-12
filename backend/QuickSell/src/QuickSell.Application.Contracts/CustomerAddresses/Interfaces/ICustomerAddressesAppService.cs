

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.CustomerAddresses

{
    public interface ICustomerAddressesAppService: IApplicationService
    {
        Task<LoadResult> GetListCustomerAddress(DataSourceLoadOptions loadOptions);
        Task<DxCustomerAddressLookupDto?> GetCustomerAddressByID(Guid? id);
        Task<CustomerAddressDto> AddCustomerAddress(CustomerAddressDto input);
        Task<CustomerAddressDto> UpdateCustomerAddress(Guid id, IDictionary<string, object> input);
        Task DeleteCustomerAddress(Guid id);
    }
}


