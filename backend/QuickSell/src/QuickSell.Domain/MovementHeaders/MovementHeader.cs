using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace QuickSell.MovementHeaders
{

    public  class MovementHeader : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? CustomerCardID { get; set; }
        public int? FirstAmount { get; set; }
        public int? DiscountAmount { get; set; }
        public int? VATAmount { get; set; }
        public int? TotalAmount { get; set; }  
        public Guid? TenantId { get; set; }


        public MovementHeader()
        {

        }

        
        public MovementHeader
        (
            Guid id
          ,string? typeCode 
          ,int? receiptNo
          , Guid? customerCardID
          , int? firstAmount
          ,int? discountAmount
          ,int? vAtAmount
          ,int? totalAmount
          
            

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

        }


        
    }
}
