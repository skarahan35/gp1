
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
using QuickSell.Localization;
using Microsoft.Extensions.Localization;

namespace QuickSell.Cities
{
    public class CitiesAppService :ApplicationService, ICitiesAppService
    {
        private readonly ICityRepository _cityRepository;
        private readonly CityManager _cityManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;
    
        public CitiesAppService(ICityRepository cityRepository,
                                CityManager cityManager,
                                IDataFilter dataFilter,
                                IStringLocalizer<QuickSellResource> localizer)
        {
            _cityRepository = cityRepository;
            _cityManager= cityManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }
        public async Task<LoadResult> GetListCity(DataSourceLoadOptions loadOptions)
        {
            var getCity = await _cityRepository.GetQueryableAsync();

            var getJoinedData = from cty in getCity
                                select new DxCityLookupDto
                                {
                                    Id = cty.Id,
                                    Code = cty.Code,
                                    Name = cty.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCityLookupDto?> GetCityByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCity = (await _cityRepository.GetQueryableAsync());
                var city = (from cty in getCity
                                  where cty.Id == id
                                  select new DxCityLookupDto
                                  {
                                      Id = cty.Id,
                                      Code = cty.Code,
                                      Name = cty.Name
                                  }).FirstOrDefault();
                return city;
            }
        }
        public async Task CityValidation(CityDto input)
        {
            var qry = await _cityRepository.GetQueryableAsync();
            await Validation<City, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<City, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<CityDto> AddCity(CityDto input)
        {
            await CityValidation(input);
            var city = await _cityManager.CreateAsync(
              input.Code,
              input.Name
          );
            
            return ObjectMapper.Map<City, CityDto>(city);
        }
        
        public async Task<CityDto> UpdateCity(Guid id, IDictionary<string, object> input)
        {
            var city = await _cityRepository.GetAsync(id);
            var cityDto = ObjectMapper.Map<City, CityDto>(city);
            await DevExtremeUpdate.Update(cityDto, input);

            return await UpdateCity(cityDto.Id, cityDto);
        }
        public async Task<CityDto> UpdateCity(Guid id, CityDto input)
        {
            await CityValidation(input);
            var city = await _cityManager.UpdateAsync(
                id,
                input.Code,
              input.Name
            );
            await _cityRepository.UpdateAsync(city);

            return ObjectMapper.Map<City, CityDto>(city);
        }
        public async Task DeleteCity(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }
    }
}