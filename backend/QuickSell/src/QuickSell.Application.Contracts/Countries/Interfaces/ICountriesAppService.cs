

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.Countries

{
    public interface ICountriesAppService: IApplicationService
    {
        Task<LoadResult> GetListCountry(DataSourceLoadOptions loadOptions);
        Task<DxCountryLookupDto?> GetCountryByID(Guid? id);
        Task<CountryDto> AddCountry(CountryDto input);
        Task<CountryDto> UpdateCountry(Guid id, IDictionary<string, object> input);
        Task DeleteCountry(Guid id);
    }
}


