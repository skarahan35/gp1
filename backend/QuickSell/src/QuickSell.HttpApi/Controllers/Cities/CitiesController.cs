



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Cities;



namespace  QuickSell.Controllers.Cities
{
    
    public class CitiesController : AbpController,ICitiesAppService
    {
        private readonly ICitiesAppService _citiesAppService;

        

        public CitiesController(ICitiesAppService citiesAppService)
       {
        _citiesAppService = citiesAppService;
       }

        
    }
}
