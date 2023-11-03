using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.StockCards;

namespace QuickSell.StockPrices
{
    
    public class StockPriceWithNavigationPropertiesDto 
    {
    
        public StockPriceDto  StockPrice  {get; set;}
        
        public StockCardDto StockCard { get; set; }
        
       


        

        
       


        
    }
}
