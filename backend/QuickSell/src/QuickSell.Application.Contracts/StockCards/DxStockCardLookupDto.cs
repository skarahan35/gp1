using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.StockCards
{
    public class DxStockCardLookupDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public Guid? StockTypeID { get; set; }
        public Guid? StockUnitID { get; set; }
        public Guid? StockGroupID { get; set; }
        public decimal? TransferredQuantity { get; set; }
        public decimal? AvailableQuantity { get; set; }
        public decimal? TotalEntryQuantity { get; set; }
        public decimal? TotalOutputQuantity { get; set; }
        public int? VATRate { get; set; }
        public int? DiscountRate { get; set; }
        public string? CurrencyType { get; set; }
        public decimal? Price1 { get; set; }
        public decimal? Price2 { get; set; }
        public decimal? Price3 { get; set; }
    }
}
