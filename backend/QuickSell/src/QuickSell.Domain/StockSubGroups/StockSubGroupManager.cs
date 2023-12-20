using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.StockSubGroups
{
    public class StockSubGroupManager : DomainService
    {
        private readonly IStockSubGroupRepository _stockSubGroupRepository;

        public StockSubGroupManager(IStockSubGroupRepository stockSubGroupRepository)
        {
            _stockSubGroupRepository = stockSubGroupRepository;
        }

        public async Task<StockSubGroup> CreateAsync(
              string? code, 
              string? name 
        )
        {

            var stockSubGroup = new StockSubGroup(
             GuidGenerator.Create(),
               code, 
               name
             );

            return await _stockSubGroupRepository.InsertAsync(stockSubGroup);
        }

        public async Task<StockSubGroup> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockSubGroupRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockSubGroup = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockSubGroup.Code=code;
                stockSubGroup.Name=name;

         stockSubGroup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockSubGroupRepository.UpdateAsync(stockSubGroup);
        }

    }
}