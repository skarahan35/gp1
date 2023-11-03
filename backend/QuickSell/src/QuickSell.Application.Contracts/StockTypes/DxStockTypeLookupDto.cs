using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.StockTypes
{
    public class DxStockTypeLookupDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool? Condition { get; set; }
    }
}
