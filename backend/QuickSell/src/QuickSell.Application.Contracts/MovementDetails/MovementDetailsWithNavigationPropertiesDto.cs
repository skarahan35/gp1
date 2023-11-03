using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.StockCards;

namespace QuickSell.MovementDetails
{
    
    public class MovementDetailsWithNavigationPropertiesDto 
    {
    
        public MovementDetailsDto  MovementDetails  {get; set;}
        
        public StockCardDto StockCard { get; set; }
        
       


        

        
       


        
    }
}
