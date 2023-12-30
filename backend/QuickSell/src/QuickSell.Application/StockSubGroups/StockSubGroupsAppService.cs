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

namespace QuickSell.StockSubGroups
{
    public abstract class StockSubGroupsAppService : ApplicationService, IStockSubGroupsAppService
    {
        private readonly IStockSubGroupRepository _stockSubGroupRepository;
        private readonly StockSubGroupManager _stockSubGroupManager;
        private readonly IDataFilter _dataFilter;

        public StockSubGroupsAppService(IStockSubGroupRepository stockSubGroupRepository,
                                        StockSubGroupManager stockSubGroupManager,
                                        IDataFilter dataFilter)
        {
            _stockSubGroupRepository = stockSubGroupRepository;
            _stockSubGroupManager = stockSubGroupManager;
            _dataFilter = dataFilter;
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
        public async Task<StockSubGroupDto> AddStockSubGroup(StockSubGroupDto input)
        {
            var stockSubGroup = await _stockSubGroupManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<StockSubGroup, StockSubGroupDto>(stockSubGroup);
        }
        public async Task<StockSubGroupDto> UpdateStockSubGroup(Guid id, IDictionary<string, object> input)
        {
            var stockSubGroup = await _stockSubGroupRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(stockSubGroup, input);
            await _stockSubGroupRepository.UpdateAsync(updated);
            return ObjectMapper.Map<StockSubGroup, StockSubGroupDto>(updated);
        }
        public async Task DeleteStockSubGroup(Guid id)
        {
            await _stockSubGroupRepository.DeleteAsync(id);
        }
    }
}