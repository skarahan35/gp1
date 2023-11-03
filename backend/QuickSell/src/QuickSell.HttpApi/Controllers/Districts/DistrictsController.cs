



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Districts;



namespace  QuickSell.Controllers.Districts
{
    
    
    public class DistrictsController : AbpController,IDistrictsAppService
    {
        private readonly IDistrictsAppService _districtsAppService;

        

        public DistrictsController(IDistrictsAppService districtsAppService)
       {
        _districtsAppService = districtsAppService;
       }

    }
}
