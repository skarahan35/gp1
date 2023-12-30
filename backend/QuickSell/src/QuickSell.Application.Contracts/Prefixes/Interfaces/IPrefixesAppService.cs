using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using QuickSell.Shared;

namespace QuickSell.Prefixes

{
    public interface IPrefixesAppService: IApplicationService
    {
        Task<LoadResult> GetListPrefix(DataSourceLoadOptions loadOptions);
        Task<DxPrefixLookupDto?> GetPrefixByID(Guid? id);
        Task<PrefixDto> AddPrefix(PrefixDto input);
        Task<PrefixDto> UpdatePrefix(Guid id, IDictionary<string, object> input);
        Task DeletePrefix(Guid id);
    }
}


