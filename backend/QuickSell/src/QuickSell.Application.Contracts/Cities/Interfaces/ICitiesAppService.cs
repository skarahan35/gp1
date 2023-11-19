

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.Cities

{
    public interface ICitiesAppService: IApplicationService
    {
        Task<LoadResult> GetListCity(DataSourceLoadOptions loadOptions);
        Task<DxCityLookupDto?> GetCityByID(Guid? id);
        Task<CityDto> AddCity(CityDto input);
        Task<CityDto> UpdateCity(Guid id, IDictionary<string, object> input);
        Task DeleteCity(Guid id);
    }
}


