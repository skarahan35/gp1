using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.CustomerCards;

namespace QuickSell.MovementHeaders
{

    public class MovementHeaderDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        public string TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public UNKNOWN_TYPE CustomerCardID { get; set; }
        public int? FirstAmount { get; set; }
        public int? DiscountAmount { get; set; }
        public int? VATAmount { get; set; }
        public int? TotalAmount { get; set; }
        public Guid? CustomerCardId { get; set; }
        
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}


