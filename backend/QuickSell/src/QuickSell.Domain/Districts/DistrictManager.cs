using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.Districts
{
    public class DistrictManager : DomainService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task<District> CreateAsync(
              string code, 
              string name, 
        )
        {

            var district = new District(
             GuidGenerator.Create(),
               code, 
               name, 
             );

            return await _districtRepository.InsertAsync(district);
        }

        public async Task<District> UpdateAsync(
           Guid id,
          string code, 
          string name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _districtRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var district = await AsyncExecuter.FirstOrDefaultAsync(query);

                district.Code=code;
                district.Name=name;

         district.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _districtRepository.UpdateAsync(district);
        }

    }
}