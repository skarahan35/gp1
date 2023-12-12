

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.CustomerCards

{
    public interface ICustomerCardsAppService: IApplicationService
    {
        Task<LoadResult> GetListCustomerCard(DataSourceLoadOptions loadOptions);
        Task<DxCustomerCardLookupDto?> GetCustomerCardByID(Guid? id);
        Task<CustomerCardDto> AddCustomerCard(CustomerCardDto input);
        Task<CustomerCardDto> UpdateCustomerCard(Guid id, IDictionary<string, object> input);
        Task DeleteCustomerCard(Guid id);
    }
}


