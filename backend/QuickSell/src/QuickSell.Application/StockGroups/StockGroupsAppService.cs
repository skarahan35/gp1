
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
using Volo.Abp.Data;
using QuickSell.Tools;

namespace QuickSell.StockGroups
{
    public class StockGroupsAppService :ApplicationService, IStockGroupsAppService
    {
        private readonly IStockGroupRepository _stockGroupRepository;
        private readonly StockGroupManager _stockGroupManager;
        private readonly IDataFilter _dataFilter;
    
        public StockGroupsAppService(IStockGroupRepository stockGroupRepository,
                                     StockGroupManager stockGroupManager,IDataFilter dataFilter)
        {
            _stockGroupRepository = stockGroupRepository;
            _stockGroupManager= stockGroupManager;
            _dataFilter = dataFilter;
        }

        public async Task<LoadResult> GetListStockUnit(DataSourceLoadOptions loadOptions)
        {
            var getStockGroup = await _stockGroupRepository.GetQueryableAsync();

            var getJoinedData = from stkgrp in getStockGroup
                                select new DxStockGroupLookupDto
                                {
                                    Id = stkgrp.Id,
                                    Code = stkgrp.Code,
                                    Name = stkgrp.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxStockGroupLookupDto?> GetStockTypeByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getStockGroup = (await _stockGroupRepository.GetQueryableAsync());
                var stockGroups = (from stkgrp in getStockGroup
                                  where stkgrp.Id == id
                                  select new DxStockGroupLookupDto
                                  {
                                      Id = stkgrp.Id,
                                      Code = stkgrp.Code,
                                      Name = stkgrp.Name,
                                  }).FirstOrDefault();
                return stockGroups;
            }
        }
        public async Task<StockGroupDto> AddStockType(StockGroupDto input)
        {
            var stockGroup = await _stockGroupManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<StockGroup, StockGroupDto>(stockGroup);
        }
        public async Task<StockGroupDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            //Entity üzerinde update işlemi yapıldığı zaman işlem tamamlanmadan update işlemini yapmış oluyor.
            //Bu yüzden de map işlemi ile update edene kadar datayı dto ya dönüştürülüyor.
            var stockGroup = await _stockGroupRepository.GetAsync(id);
            var stockTypeDto = ObjectMapper.Map<StockGroup, StockGroupDto>(stockGroup);
            var updated = await DevExtremeUpdate.Update(stockTypeDto, input);
            var a = ObjectMapper.Map<StockGroupDto, StockGroup>(updated);
            return ObjectMapper.Map<StockGroup, StockGroupDto>(a);
        }
        public async Task DeleteStockType(Guid id)
        {
            await _stockGroupRepository.DeleteAsync(id);
        }
    }
}