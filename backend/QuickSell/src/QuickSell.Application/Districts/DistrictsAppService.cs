
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
using QuickSell.Localization;
using Microsoft.Extensions.Localization;

namespace QuickSell.Districts
{
    public class DistrictsAppService :ApplicationService, IDistrictsAppService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictManager _districtManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public DistrictsAppService(IDistrictRepository districtRepository,
                                   DistrictManager districtManager,
                                   IDataFilter dataFilter,
                                   IStringLocalizer<QuickSellResource> localizer)
        {
            _districtRepository = districtRepository;
            _districtManager= districtManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
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
        public async Task DistrictValidation(DistrictDto input)
        {
            var qry = await _districtRepository.GetQueryableAsync();
            await Validation<District, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<District, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<DistrictDto> AddDistrict(DistrictDto input)
        {
            await DistrictValidation(input);
            var district = await _districtManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<District, DistrictDto>(district);
        }
        public async Task<DistrictDto> UpdateDistrict(Guid id, IDictionary<string, object> input)
        {
            var district = await _districtRepository.GetAsync(id);
            var districtDto = ObjectMapper.Map<District, DistrictDto>(district);
            await DevExtremeUpdate.Update(districtDto, input);

            return await UpdateDistrict(districtDto.Id, districtDto);
        }
        public async Task<DistrictDto> UpdateDistrict(Guid id, DistrictDto input)
        {
            await DistrictValidation(input);
            var customerGroup = await _districtManager.UpdateAsync(
                id,
                input.Code,
                input.Name
            );
            await _districtRepository.UpdateAsync(customerGroup);

            return ObjectMapper.Map<District, DistrictDto>(customerGroup);
        }
        public async Task DeleteDistrict(Guid id)
        {
            await _districtRepository.DeleteAsync(id);
        }
    }
}