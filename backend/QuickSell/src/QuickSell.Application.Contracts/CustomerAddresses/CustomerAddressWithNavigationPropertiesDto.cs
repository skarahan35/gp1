using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.CustomerCards;
using QuickSell.Districts;
using QuickSell.Cities;
using QuickSell.Countries;

namespace QuickSell.CustomerAddresses
{
    
    public class CustomerAddressWithNavigationPropertiesDto 
    {
    
        public CustomerAddressDto  CustomerAddress  {get; set;}
        
        public CustomerCardDto CustomerCard { get; set; }
        
        public DistrictDto District { get; set; }
        
        public CityDto City { get; set; }
        
        public CountryDto Country { get; set; }
        
       


        

        
       


        
    }
}
