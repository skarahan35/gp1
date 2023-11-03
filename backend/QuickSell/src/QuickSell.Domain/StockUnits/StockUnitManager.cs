using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.StockUnits
{
    public class StockUnitManager : DomainService
    {
        private readonly IStockUnitRepository _stockUnitRepository;

        public StockUnitManager(IStockUnitRepository stockUnitRepository)
        {
            _stockUnitRepository = stockUnitRepository;
        }

        public async Task<StockUnit> CreateAsync(
              string? code, 
              string? name
        )
        {

            var stockUnit = new StockUnit(
             GuidGenerator.Create(),
               code, 
               name 
             );

            return await _stockUnitRepository.InsertAsync(stockUnit);
        }

        public async Task<StockUnit> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockUnitRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockUnit = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockUnit.Code=code;
                stockUnit.Name=name;

         stockUnit.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockUnitRepository.UpdateAsync(stockUnit);
        }

    }
}