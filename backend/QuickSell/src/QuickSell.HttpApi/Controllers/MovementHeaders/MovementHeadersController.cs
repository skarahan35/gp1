



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.MovementHeaders;




namespace  QuickSell.Controllers.MovementHeaders
{
    
    [Route("api/movement-headers")]
    
    public abstract class MovementHeadersController : AbpController,IMovementHeadersAppService
    {
        private readonly IMovementHeadersAppService _movementHeadersAppService;

        

        public MovementHeadersController(IMovementHeadersAppService movementHeadersAppService)
       {
        _movementHeadersAppService = movementHeadersAppService;
       }

    }
}
