
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickSell.Permissions;
using QuickSell.Cities;
using QuickSell.Shared;

namespace QuickSell.Cities
{
    public class CitiesAppService :ApplicationService, ICitiesAppService
    {
        private readonly ICityRepository _cityRepository;
        private readonly CityManager _cityManager;
    
        public CitiesAppService(ICityRepository cityRepository,CityManager cityManager)
        {
            _cityRepository = cityRepository;
            _cityManager= cityManager;
        }
    
        
             
    
    }
}