
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickSell.Permissions;
using QuickSell.Cities;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;

namespace QuickSell.Cities
{
    public class CitiesAppService :ApplicationService, ICitiesAppService
    {
        private readonly ICityRepository _cityRepository;
        private readonly CityManager _cityManager;
        private readonly IDataFilter _dataFilter;
    
        public CitiesAppService(ICityRepository cityRepository,
                                CityManager cityManager,
                                IDataFilter dataFilter)
        {
            _cityRepository = cityRepository;
            _cityManager= cityManager;
            _dataFilter = dataFilter;
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
        public async Task<CityDto> AddCity(CityDto input)
        {
            var city = await _cityManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<City, CityDto>(city);
        }
        public async Task<CityDto> UpdateCity(Guid id, IDictionary<string, object> input)
        {
            var city = await _cityRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(city, input);
            await _cityRepository.UpdateAsync(updated);
            return ObjectMapper.Map<City, CityDto>(city);
        }
        public async Task DeleteCity(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }
    }
}