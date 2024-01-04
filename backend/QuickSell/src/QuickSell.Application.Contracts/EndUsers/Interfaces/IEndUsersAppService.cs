

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.EndUsers

{
    public interface IEndUsersAppService: IApplicationService
    {
        Task<LoadResult> GetListEndUser(DataSourceLoadOptions loadOptions);
        Task<DxEndUserLookupDto?> GetEndUserByID(Guid? id);
        Task<EndUserDto> AddEndUser(EndUserDto input);
        Task<EndUserDto> UpdateEndUser(Guid id, IDictionary<string, object> input);
        Task DeleteEndUser(Guid id);
        Task<bool> Login(string username, string password);
    }
}


