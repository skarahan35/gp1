
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using Volo.Abp.Data;
using System.Linq;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Domain.Repositories;
using Microsoft.Extensions.Localization;
using QuickSell.Localization;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace QuickSell.StockUnits
{
    public class StockUnitsAppService :ApplicationService, IStockUnitsAppService
    {
        private readonly IStockUnitRepository _stockUnitRepository;
        private readonly StockUnitManager _stockUnitManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public StockUnitsAppService(IStockUnitRepository stockUnitRepository,
                                    StockUnitManager stockUnitManager,
                                    IDataFilter dataFilter,
                                    IStringLocalizer<QuickSellResource> localizer)
        {
            _stockUnitRepository = stockUnitRepository;
            _stockUnitManager = stockUnitManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }
        public async Task<LoadResult> GetListStockUnit(DataSourceLoadOptions loadOptions)
        {
            var getStockUnit = await _stockUnitRepository.GetQueryableAsync();

            var getJoinedData = from stkunt in getStockUnit
                                select new DxStockUnitLookupDto
                                {
                                    Id = stkunt.Id,
                                    Code = stkunt.Code,
                                    Name = stkunt.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxStockUnitLookupDto?> GetStockUnitByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getStockUnit = (await _stockUnitRepository.GetQueryableAsync());
                var stockUnits = (from stkunt in getStockUnit
                                  where stkunt.Id == id
                                  select new DxStockUnitLookupDto
                                  {
                                      Id = stkunt.Id,
                                      Code = stkunt.Code,
                                      Name = stkunt.Name,
                                  }).FirstOrDefault();
                return stockUnits;
            }
        }
        public async Task CodeControl(StockUnitDto input)
        {
            var code = await _stockUnitRepository.FirstOrDefaultAsync(x=> x.Code == input.Code);
            if (code != null)
            {
                throw new UserFriendlyException(string.Format(_localizer["Code:AlreadyExist"], nameof(code)));
            }
            else if (input.Code == null)
            {
                throw new UserFriendlyException(string.Format(_localizer["Code:Null"]));
            }
        }
        public async Task<StockUnitDto> AddStockUnit(StockUnitDto input) 
        {
            var stockUnit = await _stockUnitManager.CreateAsync(
              input.Code,
              input.Name
          );
            //await Validation.CodeControl(input, x => x.Code);
            return ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
        }
        public async Task<StockUnitDto> UpdateStockUnit(Guid id, IDictionary<string, object> input)
        {
            var stockUnit = await _stockUnitRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(stockUnit, input);
            await _stockUnitRepository.UpdateAsync(updated);
            return ObjectMapper.Map<StockUnit, StockUnitDto>(updated);
        }
        public async Task DeleteStockUnit(Guid id)
        {
            await _stockUnitRepository.DeleteAsync(id);
        }
    }
}