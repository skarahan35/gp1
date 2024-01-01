using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.CustomerCards;
using QuickSell.Shared;
using QuickSell.MovementDetails;

namespace QuickSell.MovementHeaders
{
    public class MovementDTO
    {
        public MovementHeaderDto Header { get; set; }
        public List<DataChange> Details { get; set; }
    }
    public class MovementHeaderDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? CustomerCardID { get; set; }
        public decimal? FirstAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public Guid? AddressID { get; set; }
        public PaymentType? PaymentType { get; set; }
        public string? ConcurrencyStamp { get; set; }   
    }
}


