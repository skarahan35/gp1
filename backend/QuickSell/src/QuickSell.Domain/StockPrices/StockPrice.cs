using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.StockCards;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace QuickSell.StockPrices
{
    
    public  class StockPrice : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public Guid? StockCardID { get; set; }
        public decimal? Price { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string PriceType { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


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
