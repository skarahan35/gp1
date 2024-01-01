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
using Microsoft.Extensions.Localization;
using QuickSell.Localization;
using Volo.Abp.ObjectMapping;

namespace QuickSell.StockSubGroups
{
    public abstract class StockSubGroupsAppService : ApplicationService, IStockSubGroupsAppService
    {
        private readonly IStockSubGroupRepository _stockSubGroupRepository;
        private readonly StockSubGroupManager _stockSubGroupManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public StockSubGroupsAppService(IStockSubGroupRepository stockSubGroupRepository,
                                        StockSubGroupManager stockSubGroupManager,
                                        IDataFilter dataFilter,
                                        IStringLocalizer<QuickSellResource> localizer)
        {
            _stockSubGroupRepository = stockSubGroupRepository;
            _stockSubGroupManager = stockSubGroupManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }
        public async Task<LoadResult> GetListStockSubGroup(DataSourceLoadOptions loadOptions)
        {
            var getStockSubGroup = await _stockSubGroupRepository.GetQueryableAsync();

            var getJoinedData = from stksbgrp in getStockSubGroup
                                select new DxStockSubGroupLookupDto
                                {
                                    Id = stksbgrp.Id,
                                    Code = stksbgrp.Code,
                                    Name = stksbgrp.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxStockSubGroupLookupDto?> GetStockSubGroupByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getStockSubGroup = (await _stockSubGroupRepository.GetQueryableAsync());
                var stockSubGroups = (from stksbgrp in getStockSubGroup
                                   where stksbgrp.Id == id
                                   select new DxStockSubGroupLookupDto
                                   {
                                       Id = stksbgrp.Id,
                                       Code = stksbgrp.Code,
                                       Name = stksbgrp.Name,
                                   }).FirstOrDefault();
                return stockSubGroups;
            }
        }
        public async Task StockSubGroupValidation(StockSubGroupDto input)
        {
            var qry = await _stockSubGroupRepository.GetQueryableAsync();
            await Validation<StockSubGroup, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<StockSubGroup, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<StockSubGroupDto> AddStockSubGroup(StockSubGroupDto input)
        {
            await StockSubGroupValidation(input);
            var stockSubGroup = await _stockSubGroupManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<StockSubGroup, StockSubGroupDto>(stockSubGroup);
        }
        public async Task<StockSubGroupDto> UpdateStockSubGroup(Guid id, IDictionary<string, object> input)
        {
            var stockSubGroup = await _stockSubGroupRepository.GetAsync(id);
            var stockSubGroupDto = ObjectMapper.Map<StockSubGroup, StockSubGroupDto>(stockSubGroup);
            await DevExtremeUpdate.Update(stockSubGroupDto, input);

            return await UpdateStockSubGroup(stockSubGroupDto.Id, stockSubGroupDto);
        }
        public async Task<StockSubGroupDto> UpdateStockSubGroup(Guid id, StockSubGroupDto input)
        {
            await StockSubGroupValidation(input);
            var stockSubGroup = await _stockSubGroupManager.UpdateAsync(
              id,
              input.Code,
              input.Name
            );
            await _stockSubGroupRepository.UpdateAsync(stockSubGroup);

            return ObjectMapper.Map<StockSubGroup, StockSubGroupDto>(stockSubGroup);
        }
        public async Task DeleteStockSubGroup(Guid id)
        {
            await _stockSubGroupRepository.DeleteAsync(id);
        }
    }
}