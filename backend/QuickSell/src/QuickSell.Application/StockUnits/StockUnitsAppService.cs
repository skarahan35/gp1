
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
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Microsoft.Extensions.Localization;
using QuickSell.Localization;

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
                                    InternationalCode = stkunt.InternationalCode,
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
                                      InternationalCode = stkunt.InternationalCode,
                                      Name = stkunt.Name,
                                  }).FirstOrDefault();
                return stockUnits;
            }
        }
        public async Task StockUnitValidation(StockUnitDto input)
        {
            var qry = await _stockUnitRepository.GetQueryableAsync();
            await Validation<StockUnit, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<StockUnit, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<StockUnitDto> AddStockUnit(StockUnitDto input) 
        {
            await StockUnitValidation(input);
            var stockUnit = await _stockUnitManager.CreateAsync(
              input.Code,
              input.InternationalCode,
              input.Name
              );
            return ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
        }
        public async Task<StockUnitDto> UpdateStockUnit(Guid id, IDictionary<string, object> input)
        {
            var stockUnit = await _stockUnitRepository.GetAsync(id);
            var stockUnitDto = ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
            await DevExtremeUpdate.Update(stockUnitDto, input);

            return await BPUpdateEmployees(stockUnitDto.Id, stockUnitDto);
        }
        public async Task<StockUnitDto> BPUpdateEmployees(Guid id, StockUnitDto input)
        {
            await StockUnitValidation(input);
            var stockUnit = await _stockUnitManager.UpdateAsync(
                id,
                input.Code,
                input.InternationalCode,
                input.Name
            );
            await _stockUnitRepository.UpdateAsync(stockUnit);

            return ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
        }
        public async Task DeleteStockUnit(Guid id)
        {
            await _stockUnitRepository.DeleteAsync(id);
        }
    }
}