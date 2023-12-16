using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
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
    
    public class CustomerCardWithNavigationProperties 
    {
    
        public CustomerCard  CustomerCard  {get; set;}
        
        public CustomerType CustomerType { get; set; }
        
        public CustomerGroup CustomerGroup { get; set; }
               
    }
}
