using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.StockGroups
{
    public class StockGroupManager : DomainService
    {
        private readonly IStockGroupRepository _stockGroupRepository;

        public StockGroupManager(IStockGroupRepository stockGroupRepository)
        {
            _stockGroupRepository = stockGroupRepository;
        }

        public async Task<StockGroup> CreateAsync(
              string code, 
              string name, 
        )
        {

            var stockGroup = new StockGroup(
             GuidGenerator.Create(),
               code, 
               name, 
             );

            return await _stockGroupRepository.InsertAsync(stockGroup);
        }

        public async Task<StockGroup> UpdateAsync(
           Guid id,
          string code, 
          string name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockGroupRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockGroup = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockGroup.Code=code;
                stockGroup.Name=name;

         stockGroup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockGroupRepository.UpdateAsync(stockGroup);
        }

    }
}