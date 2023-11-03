using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.Districts;
using QuickSell.Cities;
using QuickSell.Countries;

namespace QuickSell.Companies
{
    
    public class CompanyWithNavigationPropertiesDto 
    {
    
        public CompanyDto  Company  {get; set;}
        
        public DistrictDto District { get; set; }
        
        public CityDto City { get; set; }
        
        public CountryDto Country { get; set; }
        
       


        

        
       


        
    }
}
