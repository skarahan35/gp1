
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;

namespace QuickSell.Countries
{
    public class CountriesAppService :ApplicationService, ICountriesAppService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly CountryManager _countryManager;
        private readonly IDataFilter _dataFilter;
    
        public CountriesAppService(ICountryRepository countryRepository,
                                   CountryManager countryManager,
                                   IDataFilter dataFilter)
        {
            _countryRepository = countryRepository;
            _countryManager= countryManager;
            _dataFilter = dataFilter;
        }
        public async Task<LoadResult> GetListCountry(DataSourceLoadOptions loadOptions)
        {
            var getCountry = await _countryRepository.GetQueryableAsync();

            var getJoinedData = from cntry in getCountry
                                select new DxCountryLookupDto
                                {
                                    Id = cntry.Id,
                                    Code = cntry.Code,
                                    Name = cntry.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCountryLookupDto?> GetCountryByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCountry = (await _countryRepository.GetQueryableAsync());
                var country = (from cntry in getCountry
                            where cntry.Id == id
                            select new DxCountryLookupDto
                            {
                                Id = cntry.Id,
                                Code = cntry.Code,
                                Name = cntry.Name
                            }).FirstOrDefault();
                return country;
            }
        }
        public async Task<CountryDto> AddCountry(CountryDto input)
        {
            var country = await _countryManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<Country, CountryDto>(country);
        }
        public async Task<CountryDto> UpdateCountry(Guid id, IDictionary<string, object> input)
        {
            var country = await _countryRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(country, input);
            await _countryRepository.UpdateAsync(updated);
            return ObjectMapper.Map<Country, CountryDto>(country);
        }
        public async Task DeleteCountry(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
        }
    }
}