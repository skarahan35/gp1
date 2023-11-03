using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.MovementDetails
{
    public class DxMovementDetailLookupDto
    {
        public Guid Id { get; set; }
        public string? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? StockCardID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VATRate { get; set; }
        public decimal? VATAmount { get; set; }
    }
}
