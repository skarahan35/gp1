using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.CustomerAddresses;
using QuickSell.MovementHeaders;
using QuickSell.CustomerTypes;
using QuickSell.CustomerGroups;

namespace QuickSell.CustomerCards
{
    
    public class CustomerCardWithNavigationPropertiesDto 
    {
    
        public CustomerCardDto  CustomerCard  {get; set;}
        
        public CustomerTypeDto CustomerType { get; set; }
        
        public CustomerGroupDto CustomerGroup { get; set; }
        
       


        

        
       


        
    }
}
