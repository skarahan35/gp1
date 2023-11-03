using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.StockUnits
{
    public class DxStockUnitLookupDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
