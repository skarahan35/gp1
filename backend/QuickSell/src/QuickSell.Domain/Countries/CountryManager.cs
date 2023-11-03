using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.Countries
{
    public class CountryManager : DomainService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Country> CreateAsync(
              string? code, 
              string? name
        )
        {

            var country = new Country(
             GuidGenerator.Create(),
               code, 
               name
             );

            return await _countryRepository.InsertAsync(country);
        }

        public async Task<Country> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _countryRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var country = await AsyncExecuter.FirstOrDefaultAsync(query);

                country.Code=code;
                country.Name=name;

         country.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _countryRepository.UpdateAsync(country);
        }

    }
}