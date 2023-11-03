

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.Countries

{
    public interface ICountriesAppService: IApplicationService
    {
        

        Task<PagedResultDto< CountryDto >> GetListAsync(GetCountriesInput input);

        Task<CountryDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CountryDto> CreateAsync(CountryCreateDto input);

        Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input);

        
    }
}


