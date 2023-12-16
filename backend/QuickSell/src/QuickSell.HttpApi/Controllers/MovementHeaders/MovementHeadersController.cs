using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using QuickSell.MovementHeaders;
using System.Collections.Generic;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.Controllers.MovementHeaders
{
    
    public class MovementHeadersController : AbpController,IMovementHeadersAppService
    {
        private readonly IMovementHeadersAppService _movementHeadersAppService;

        

        public MovementHeadersController(IMovementHeadersAppService movementHeadersAppService)
        {
             _movementHeadersAppService = movementHeadersAppService;
        }
        [HttpPost]
        [Route("300101")]
        public async Task<MovementHeaderDto> AddMovementHeader(MovementHeaderDto input)
        {
            return await _movementHeadersAppService.AddMovementHeader(input);
        }
        [HttpGet]
        [Route("300104")]
        public async Task<LoadResult> GetListMovementHeader(DataSourceLoadOptions loadOptions)
        {
            return await _movementHeadersAppService.GetListMovementHeader(loadOptions);
        }
        [HttpGet]
        [Route("300105/{id}")]
        public async Task<DxMovementHeaderLookupDto?> GetMovementHeaderByID(Guid? id)
        {
            return await _movementHeadersAppService.GetMovementHeaderByID(id);
        }
        [HttpDelete]
        [Route("300103/{id}")]
        public async Task DeleteMovementHeader(Guid id)
        {
            await _movementHeadersAppService.DeleteMovementHeader(id);
        }
        [HttpPut]
        [Route("300102/{id}")]
        public async Task<MovementHeaderDto> UpdateMovementHeader(Guid id, IDictionary<string, object> input)
        {
            return await _movementHeadersAppService.UpdateMovementHeader(id, input);
        }
    }
}
