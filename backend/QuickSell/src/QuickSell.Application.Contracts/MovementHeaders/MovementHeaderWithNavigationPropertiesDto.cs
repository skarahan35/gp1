using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.CustomerCards;
using QuickSell.CustomerAddresses;

namespace QuickSell.MovementHeaders
{
    
    public class MovementHeaderWithNavigationPropertiesDto 
    {
    
        public MovementHeaderDto  MovementHeader  {get; set;}
        
        public CustomerCardDto CustomerCard { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        
       


        

        
       


        
    }
}
