using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace QuickSell.StockPrices
{

    public  class StockPrice : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public Guid? StockCardID { get; set; }
        public decimal? Price { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string PriceType { get; set; }    
        public Guid? TenantId { get; set; }


        public StockPrice()
        {

        }

        
        public StockPrice
        (
            Guid id
           ,Guid? stockCardID
          , decimal? price
          , string priceType 
            

        )


        {
               Id = id;
            StockCardID = stockCardID;
            Price = price;
            PriceType = priceType;

        }


        
    }
}
