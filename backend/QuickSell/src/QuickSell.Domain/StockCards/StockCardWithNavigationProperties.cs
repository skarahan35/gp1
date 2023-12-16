using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
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
    
    public class StockCardWithNavigationProperties 
    {
    
        public StockCard  StockCard  {get; set;}
        
        public StockType StockType { get; set; }
        
        public StockUnit StockUnit { get; set; }
        
        public StockGroup StockGroup { get; set; }
                
    }
}
