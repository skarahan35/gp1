using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Linq;
using Volo.Abp.Data;
using QuickSell.Tools;
using System.Collections.Generic;

namespace QuickSell.StockTypes
{
    public class StockTypesAppService :ApplicationService, IStockTypesAppService
    {
        private readonly IStockTypeRepository _stockTypeRepository;
        private readonly StockTypeManager _stockTypeManager;
        private readonly IDataFilter _dataFilter;

        public StockTypesAppService(IStockTypeRepository stockTypeRepository,
                                    StockTypeManager stockTypeManager,
                                    IDataFilter dataFilter)
        {
            _stockTypeRepository = stockTypeRepository;
            _stockTypeManager= stockTypeManager;
            _dataFilter = dataFilter;
        }
        public async Task<LoadResult> GetListStockType(DataSourceLoadOptions loadOptions)
        {
            var getStockType = await _stockTypeRepository.GetQueryableAsync();

            var getJoinedData = from stktyp in getStockType
                                select new DxStockTypeLookupDto
                                {
                                    Id= stktyp.Id,
                                    Code = stktyp.Code,
                                    Name = stktyp.Name,
                                    Condition = stktyp.Condition
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxStockTypeLookupDto?> GetStockTypeByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getStockType = (await _stockTypeRepository.GetQueryableAsync());
                var stockTypes = (from stktyp in getStockType
                                  where stktyp.Id == id
                                  select new DxStockTypeLookupDto
                                  {
                                      Id = stktyp.Id,
                                      Code = stktyp.Code,
                                      Name = stktyp.Name,
                                      Condition = stktyp.Condition
                                  }).FirstOrDefault();
                return stockTypes;
            }
        }
        public async Task<StockTypeDto> AddStockType(StockTypeDto input)
        {
            var stockType = await _stockTypeManager.CreateAsync(
              input.Code,
              input.Name,
              input.Condition
          );
            return ObjectMapper.Map<StockType, StockTypeDto>(stockType);
        }
        public async Task<StockTypeDto> UpdateStockType(Guid id, IDictionary<string, object> input)
        {
            var stockType = await _stockTypeRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(stockType, input);
            await _stockTypeRepository.UpdateAsync(updated);
            return ObjectMapper.Map<StockType, StockTypeDto>(updated);
        }
        public async Task DeleteStockType(Guid id)
        {
            await _stockTypeRepository.DeleteAsync(id);
        }
    }
}