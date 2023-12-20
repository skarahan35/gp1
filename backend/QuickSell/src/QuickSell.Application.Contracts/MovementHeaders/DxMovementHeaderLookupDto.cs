using QuickSell.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.MovementHeaders
{
    public class DxMovementHeaderLookupDto
    {
        public Guid Id { get; set; }
        public string? TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public Guid? CustomerCardID { get; set; }
        public int? FirstAmount { get; set; }
        public int? DiscountAmount { get; set; }
        public int? VATAmount { get; set; }
        public int? TotalAmount { get; set; }
        public Guid? AddressID { get; set; }
        public PaymentType? PaymentType { get; set; }
    }
}
