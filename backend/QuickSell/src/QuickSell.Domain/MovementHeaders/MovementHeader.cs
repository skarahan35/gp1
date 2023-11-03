using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.CustomerCards;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace QuickSell.MovementHeaders
{
    
    public  class MovementHeader : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public string TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public UNKNOWN_TYPE CustomerCardID { get; set; }
        public int? FirstAmount { get; set; }
        public int? DiscountAmount { get; set; }
        public int? VATAmount { get; set; }
        public int? TotalAmount { get; set; }
        public Guid? CustomerCardId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public MovementHeader()
        {

        }

        
        public MovementHeader
        (
            Guid id
          ,string typeCode 
          ,int? receiptNo

          ,int? firstAmount

          ,int? discountAmount

          ,int? vAtAmount

          ,int? totalAmount

          ,Guid? customerCardId
            

        )


        {
               Id = id;
                TypeCode=typeCode;
                ReceiptNo=receiptNo;
                FirstAmount=firstAmount;
                DiscountAmount=discountAmount;
                VATAmount=vAtAmount;
                TotalAmount=totalAmount;
                CustomerCardId=customerCardId;

        }


        
    }
}
