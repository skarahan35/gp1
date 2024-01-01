using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.CustomerCards;
using QuickSell.Shared;

namespace QuickSell.MovementHeaders
{

    public class MovementHeaderCreateDto
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
    }
}


