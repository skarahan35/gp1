



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Countries;



namespace  QuickSell.Controllers.Countries
{
    public  class CountriesController : AbpController,ICountriesAppService
    {
        private readonly ICountriesAppService _countriesAppService;

        

        public CountriesController(ICountriesAppService countriesAppService)
       {
        _countriesAppService = countriesAppService;
       }

        
    }
}
