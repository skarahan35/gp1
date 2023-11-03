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

namespace QuickSell.MovementDetails
{
    
    public  class MovementDetail : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? StockCardID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VATRate { get; set; }
        public decimal? VATAmount { get; set; }
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public MovementDetail()
        {

        }

        
        public MovementDetail
        (
            Guid id
          ,string? typeCode 
          ,int? receiptNo
          , Guid? stockCardID
          , decimal? quantity
          ,decimal? price
          ,decimal? discountRate
          ,decimal? discountAmount
          ,decimal? vAtRate
          ,decimal? vAtAmount
          
            

        )


        {
               Id = id;
                TypeCode=typeCode;
                ReceiptNo=receiptNo;
                StockCardID = stockCardID;           
                Quantity=quantity;
                Price=price;
                DiscountRate=discountRate;
                DiscountAmount=discountAmount;
                VATRate=vAtRate;
                VATAmount=vAtAmount;

        }


        
    }
}
