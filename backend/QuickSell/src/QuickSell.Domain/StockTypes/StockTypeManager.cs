using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.StockTypes
{
    public class StockTypeManager : DomainService
    {
        private readonly IStockTypeRepository _stockTypeRepository;

        public StockTypeManager(IStockTypeRepository stockTypeRepository)
        {
            _stockTypeRepository = stockTypeRepository;
        }

        public async Task<StockType> CreateAsync(
              string code, 
              string name, 
              bool? condition, 
        )
        {

            var stockType = new StockType(
             GuidGenerator.Create(),
               code, 
               name, 
                condition, 
             );

            return await _stockTypeRepository.InsertAsync(stockType);
        }

        public async Task<StockType> UpdateAsync(
           Guid id,
          string code, 
          string name, 
          bool? condition, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockTypeRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockType = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockType.Code=code;
                stockType.Name=name;
                stockType.Condition=condition;  

         stockType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockTypeRepository.UpdateAsync(stockType);
        }

    }
}