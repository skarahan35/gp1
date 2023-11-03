



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.MovementDetails;


namespace  QuickSell.Controllers.MovementDetails
{
    
    public class MovementDetailsController : AbpController,IMovementDetailsAppService
    {
        private readonly IMovementDetailsAppService _movementDetailsAppService;

        

        public MovementDetailsController(IMovementDetailsAppService movementDetailsAppService)
       {
        _movementDetailsAppService = movementDetailsAppService;
       }

    }
}
