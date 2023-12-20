using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.Prefixes
{
    public class PrefixManager : DomainService
    {
        private readonly IPrefixRepository _prefixRepository;

        public PrefixManager(IPrefixRepository prefixRepository)
        {
            _prefixRepository = prefixRepository;
        }

        public async Task<Prefix> CreateAsync(
              string? code, 
              string? name, 
              string? parameter, 
              bool? beUsed
        )
        {

            var prefix = new Prefix(
             GuidGenerator.Create(),
               code, 
               name, 
               parameter, 
                beUsed
             );

            return await _prefixRepository.InsertAsync(prefix);
        }

        public async Task<Prefix> UpdateAsync(
           Guid id,
          string? code, 
          string? name, 
          string? parameter, 
          bool? beUsed, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _prefixRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var prefix = await AsyncExecuter.FirstOrDefaultAsync(query);

                prefix.Code=code;
                prefix.Name=name;
                prefix.Parameter=parameter;
                prefix.BeUsed=beUsed;  

         prefix.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _prefixRepository.UpdateAsync(prefix);
        }

    }
}