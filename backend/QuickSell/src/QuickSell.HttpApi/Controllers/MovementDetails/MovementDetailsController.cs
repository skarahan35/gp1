



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.MovementDetails;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;
using QuickSell.Shared;

namespace  QuickSell.Controllers.MovementDetails
{
    
    public class MovementDetailsController : AbpController,IMovementDetailsAppService
    {
        private readonly IMovementDetailsAppService _movementDetailsAppService;

        public MovementDetailsController(IMovementDetailsAppService movementDetailsAppService)
        {
        _movementDetailsAppService = movementDetailsAppService;
        }
        [HttpPost]
        [Route("300201")]
        public async Task<MovementDetailDto> AddMovementDetail(MovementDetailDto input)
        {
            return await _movementDetailsAppService.AddMovementDetail(input);
        }
        [HttpGet]
        [Route("300204")]
        public async Task<LoadResult> GetListMovementDetail(DataSourceLoadOptions loadOptions)
        {
            return await _movementDetailsAppService.GetListMovementDetail(loadOptions);
        }
        [HttpGet]
        [Route("300205/{id}")]
        public async Task<DxMovementDetailLookupDto?> GetMovementDetailByID(Guid? id)
        {
            return await _movementDetailsAppService.GetMovementDetailByID(id);
        }
        [HttpDelete]
        [Route("300203/{id}")]
        public async Task DeleteMovementDetail(Guid id)
        {
            await _movementDetailsAppService.DeleteMovementDetail(id);
        }
        [HttpPut]
        [Route("300202/{id}")]
        public async Task<MovementDetailDto> UpdateMovementDetail(Guid id, IDictionary<string, object> input)
        {
            return await _movementDetailsAppService.UpdateMovementDetail(id, input);
        }
    }
}
