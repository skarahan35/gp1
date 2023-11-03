using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.StockPrices;
using QuickSell.MovementDetails;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockGroups;

namespace QuickSell.StockCards
{
    
    public class StockCardWithNavigationPropertiesDto 
    {
    
        public StockCardDto  StockCard  {get; set;}
        
        public StockTypeDto StockType { get; set; }
        
        public StockUnitDto StockUnit { get; set; }
        
        public StockGroupDto StockGroup { get; set; }
        
       


        

        
       


        
    }
}
