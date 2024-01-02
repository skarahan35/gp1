using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using QuickSell.Shared;

namespace QuickSell.MovementHeaders
{


    public  class MovementHeader : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public TypeEnum? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? CustomerCardID { get; set; }
        public decimal? FirstAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? TotalAmount { get; set; }  
        public Guid? AddressID { get; set; }  
        public PaymentType? PaymentType { get; set; }  

        public Guid? TenantId { get; set; }


        public MovementHeader()
        {

        }

        
        public MovementHeader
        (
            Guid id
          , TypeEnum? typeCode 
          ,int? receiptNo
          , Guid? customerCardID
          , decimal? firstAmount
          , decimal? discountAmount
          , decimal? vAtAmount
          , decimal? totalAmount
          ,Guid? addressID
          ,PaymentType? paymentType
          
            

        )


        {
               Id = id;
                TypeCode=typeCode;
                ReceiptNo=receiptNo;
            CustomerCardID = customerCardID;
            FirstAmount =firstAmount;
                DiscountAmount=discountAmount;
                VATAmount=vAtAmount;
                TotalAmount=totalAmount;
            AddressID = addressID;
            PaymentType = paymentType;

        }


        
    }
}
