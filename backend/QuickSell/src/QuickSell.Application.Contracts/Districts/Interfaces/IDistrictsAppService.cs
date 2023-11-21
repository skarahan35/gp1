

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.Districts

{
    public interface IDistrictsAppService: IApplicationService
    {
        Task<LoadResult> GetListDistrict(DataSourceLoadOptions loadOptions);
        Task<DxDistrictLookupDto?> GetDistrictByID(Guid? id);
        Task<DistrictDto> AddDistrict(DistrictDto input);
        Task<DistrictDto> UpdateDistrict(Guid id, IDictionary<string, object> input);
        Task DeleteDistrict(Guid id);

    }
}


