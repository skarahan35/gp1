using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using QuickSell.StockCards;

namespace QuickSell.StockPrices
{
    
    public class StockPriceWithNavigationProperties 
    {
    
        public StockPrice  StockPrice  {get; set;}
        
        public StockCard StockCard { get; set; }
        
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        

        
       


        
    }
}
