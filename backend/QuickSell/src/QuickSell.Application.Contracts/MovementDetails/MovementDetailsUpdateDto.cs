using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.StockCards;

namespace QuickSell.MovementDetails
{

    public class MovementDetailUpdateDto: IHasConcurrencyStamp
    {
        public string? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? StockCardID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VATRate { get; set; }
        public decimal? VATAmount { get; set; }

        public string? ConcurrencyStamp { get; set; }
    }
}


