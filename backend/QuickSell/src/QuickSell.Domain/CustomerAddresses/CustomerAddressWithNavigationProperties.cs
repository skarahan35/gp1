using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
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
    
    public class CustomerAddressWithNavigationProperties 
    {
    
        public CustomerAddress  CustomerAddress  {get; set;}
        
        public CustomerCard CustomerCard { get; set; }
        
        public District District { get; set; }
        
        public City City { get; set; }
        
        public Country Country { get; set; }
               
    }
}
