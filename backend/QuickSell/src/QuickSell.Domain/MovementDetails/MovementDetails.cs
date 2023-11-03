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
    
    public  class MovementDetails : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public string TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public UNKNOWN_TYPE StockCardID { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? DiscountRate { get; set; }
        public int? DiscountAmount { get; set; }
        public int? VATRate { get; set; }
        public int? VATAmount { get; set; }
        public Guid? StockCardId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public MovementDetails()
        {

        }

        
        public MovementDetails
        (
            Guid id
          ,string typeCode 
          ,int? receiptNo

          ,int? quantity

          ,int? price

          ,int? discountRate

          ,int? discountAmount

          ,int? vAtRate

          ,int? vAtAmount

          ,Guid? stockCardId
            

        )


        {
               Id = id;
                TypeCode=typeCode;
                ReceiptNo=receiptNo;
                Quantity=quantity;
                Price=price;
                DiscountRate=discountRate;
                DiscountAmount=discountAmount;
                VATRate=vAtRate;
                VATAmount=vAtAmount;
                StockCardId=stockCardId;

        }


        
    }
}
