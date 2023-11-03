
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

namespace QuickSell.StockUnits
{
    public class StockUnitsAppService :ApplicationService, IStockUnitsAppService
    {
        private readonly IStockUnitRepository _stockUnitRepository;
        private readonly StockUnitManager _stockUnitManager;
        private readonly IDataFilter _dataFilter;

        public StockUnitsAppService(IStockUnitRepository stockUnitRepository,
                                    StockUnitManager stockUnitManager,
                                    IDataFilter dataFilter)
        {
            _stockUnitRepository = stockUnitRepository;
            _stockUnitManager = stockUnitManager;
            _dataFilter = dataFilter;
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
        public async Task<DxStockUnitLookupDto?> GetStockTypeByID(Guid? id)
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
        public async Task<StockUnitDto> AddStockType(StockUnitDto input)
        {
            var stockUnit = await _stockUnitManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
        }
        public async Task<StockUnitDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            //Entity üzerinde update işlemi yapıldığı zaman işlem tamamlanmadan update işlemini yapmış oluyor.
            //Bu yüzden de map işlemi ile update edene kadar datayı dto ya dönüştürülüyor.
            var stockUnit = await _stockUnitRepository.GetAsync(id);
            var stockUnitDto = ObjectMapper.Map<StockUnit, StockUnitDto>(stockUnit);
            var updated = await DevExtremeUpdate.Update(stockUnitDto, input);
            var a = ObjectMapper.Map<StockUnitDto, StockUnit>(updated);
            return ObjectMapper.Map<StockUnit, StockUnitDto>(a);
        }
        public async Task DeleteStockType(Guid id)
        {
            await _stockUnitRepository.DeleteAsync(id);
        }
    }
}