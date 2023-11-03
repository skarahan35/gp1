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
        
        public UNKNOWN_TYPE StockID { get; set; }
        public int? StockPrice { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string StockPriceType { get; set; }
        public Guid? StockCardId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public StockPrice()
        {

        }

        
        public StockPrice
        (
            Guid id
          ,string stockPriceType 
          ,int? stockPrice

          ,Guid? stockCardId
            

        )


        {
               Id = id;
                StockPriceType=stockPriceType;
                StockPrice=stockPrice;
                StockCardId=stockCardId;

        }


        
    }
}
