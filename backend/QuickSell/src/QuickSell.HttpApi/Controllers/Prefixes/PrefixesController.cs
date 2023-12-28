using Volo.Abp.AspNetCore.Mvc;
using QuickSell.Prefixes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System;
using System.Collections.Generic;

namespace QuickSell.Controllers.Prefixes
{
    public abstract class PrefixesController : AbpController, IPrefixesAppService
    {
        private readonly IPrefixesAppService _prefixesAppService;

        public PrefixesController(IPrefixesAppService prefixesAppService)
        {
            _prefixesAppService = prefixesAppService;
        }
        [HttpPost]
        [Route("700501")]
        public async Task<PrefixDto> AddPrefix(PrefixDto input)
        {
            return await _prefixesAppService.AddPrefix(input);
        }
        [HttpGet]
        [Route("700504")]
        public async Task<LoadResult> GetListPrefix(DataSourceLoadOptions loadOptions)
        {
            return await _prefixesAppService.GetListPrefix(loadOptions);
        }
        [HttpGet]
        [Route("700505/{id}")]
        public async Task<DxPrefixLookupDto?> GetPrefixByID(Guid? id)
        {
            return await _prefixesAppService.GetPrefixByID(id);
        }
        [HttpDelete]
        [Route("700503/{id}")]
        public async Task DeletePrefix(Guid id)
        {
            await _prefixesAppService.DeletePrefix(id);
        }
        [HttpPut]
        [Route("700502/{id}")]
        public async Task<PrefixDto> UpdatePrefix(Guid id, IDictionary<string, object> input)
        {
            return await _prefixesAppService.UpdatePrefix(id, input);
        }
    }
}
