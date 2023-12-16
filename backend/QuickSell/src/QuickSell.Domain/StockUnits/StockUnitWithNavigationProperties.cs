using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.StockCards;

namespace QuickSell.StockUnits
{
    
    public class StockUnitWithNavigationProperties 
    {
    
        public StockUnit  StockUnit  {get; set;}
                
    }
}
