using QuickSell.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.MovementHeaders
{
    public class DxMovementHeaderLookupDto
    {
        public Guid Id { get; set; }
        public TypeEnum? TypeCode { get; set; }
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
