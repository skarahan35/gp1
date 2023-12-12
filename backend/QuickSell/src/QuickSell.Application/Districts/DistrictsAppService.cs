
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
using QuickSell.Districts;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;

namespace QuickSell.Districts
{
    public class DistrictsAppService :ApplicationService, IDistrictsAppService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictManager _districtManager;
        private readonly IDataFilter _dataFilter;
    
        public DistrictsAppService(IDistrictRepository districtRepository,
                                   DistrictManager districtManager,
                                   IDataFilter dataFilter)
        {
            _districtRepository = districtRepository;
            _districtManager= districtManager;
            _dataFilter = dataFilter;
        }

        public async Task<LoadResult> GetListDistrict(DataSourceLoadOptions loadOptions)
        {
            var getDistrict = await _districtRepository.GetQueryableAsync();

            var getJoinedData = from dstrict in getDistrict
                                select new DxDistrictLookupDto
                                {
                                    Id = dstrict.Id,
                                    Code = dstrict.Code,
                                    Name = dstrict.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxDistrictLookupDto?> GetDistrictByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getDistrict = (await _districtRepository.GetQueryableAsync());
                var district = (from dstrict in getDistrict
                                where dstrict.Id == id
                            select new DxDistrictLookupDto
                            {
                                Id = dstrict.Id,
                                Code = dstrict.Code,
                                Name = dstrict.Name
                            }).FirstOrDefault();
                return district;
            }
        }
        public async Task<DistrictDto> AddDistrict(DistrictDto input)
        {
            var district = await _districtManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<District, DistrictDto>(district);
        }
        public async Task<DistrictDto> UpdateDistrict(Guid id, IDictionary<string, object> input)
        {
            var district = await _districtRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(district, input);
            await _districtRepository.UpdateAsync(updated);
            return ObjectMapper.Map<District, DistrictDto>(district);
        }
        public async Task DeleteDistrict(Guid id)
        {
            await _districtRepository.DeleteAsync(id);
        }
    }
}