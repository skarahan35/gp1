using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.Cities
{
    public class CityManager : DomainService
    {
        private readonly ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<City> CreateAsync(
              string code, 
              string name
        )
        {

            var city = new City(
             GuidGenerator.Create(),
               code, 
               name
             );

            return await _cityRepository.InsertAsync(city);
        }

        public async Task<City> UpdateAsync(
           Guid id,
          string code, 
          string name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _cityRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var city = await AsyncExecuter.FirstOrDefaultAsync(query);

                city.Code=code;
                city.Name=name;

         city.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _cityRepository.UpdateAsync(city);
        }

    }
}