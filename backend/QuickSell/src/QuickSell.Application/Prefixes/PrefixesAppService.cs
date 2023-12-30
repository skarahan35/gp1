using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Linq;
using Volo.Abp.Data;
using QuickSell.Localization;
using Microsoft.Extensions.Localization;

namespace QuickSell.Prefixes
{
    public class PrefixesAppService : ApplicationService, IPrefixesAppService
    {
        private readonly IPrefixRepository _prefixRepository;
        private readonly PrefixManager _prefixManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public PrefixesAppService(IPrefixRepository prefixRepository,
                                  PrefixManager prefixManager,
                                  IDataFilter dataFilter,
                                  IStringLocalizer<QuickSellResource> localizer)
        {
            _prefixRepository = prefixRepository;
            _prefixManager = prefixManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }
        public async Task<LoadResult> GetListPrefix(DataSourceLoadOptions loadOptions)
        {
            var getPrefix = await _prefixRepository.GetQueryableAsync();

            var getJoinedData = from prfx in getPrefix
                                select new DxPrefixLookupDto
                                {
                                    Id = prfx.Id,
                                    Code = prfx.Code,
                                    Name = prfx.Name,
                                    Parameter = prfx.Parameter,
                                    BeUsed = prfx.BeUsed
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxPrefixLookupDto?> GetPrefixByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getPrefix = (await _prefixRepository.GetQueryableAsync());
                var Prefixs = (from prfx in getPrefix
                                  where prfx.Id == id
                                  select new DxPrefixLookupDto
                                  {
                                      Id = prfx.Id,
                                      Code = prfx.Code,
                                      Name = prfx.Name,
                                      Parameter = prfx.Parameter,
                                      BeUsed = prfx.BeUsed
                                  }).FirstOrDefault();
                return Prefixs;
            }
        }
        public async Task PrefixValidation(PrefixDto input)
        {
            var qry = await _prefixRepository.GetQueryableAsync();
            await Validation<Prefix, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
        }
        public async Task<PrefixDto> AddPrefix(PrefixDto input)
        {
            var prefix = await _prefixManager.CreateAsync(
              input.Code,
              input.Name,
              input.Parameter,
              input.BeUsed
              );
            await PrefixValidation(input);
            return ObjectMapper.Map<Prefix, PrefixDto>(prefix);
        }
        public async Task<PrefixDto> UpdatePrefix(Guid id, IDictionary<string, object> input)
        {
            var prefix = await _prefixRepository.GetAsync(id);
            var prefixDto = ObjectMapper.Map<Prefix, PrefixDto>(prefix);
            await DevExtremeUpdate.Update(prefixDto, input);

            return await BPUpdateEmployees(prefixDto.Id, prefixDto);
        }
        public async Task<PrefixDto> BPUpdateEmployees(Guid id, PrefixDto input)
        {
            await PrefixValidation(input);
            var prefix = await _prefixManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.Parameter,
                input.BeUsed
            );
            await _prefixRepository.UpdateAsync(prefix);

            return ObjectMapper.Map<Prefix, PrefixDto>(prefix);
        }
        public async Task DeletePrefix(Guid id)
        {
            await _prefixRepository.DeleteAsync(id);
        }
    }
}