using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.StockPrices
{
    public class DxStockPriceLookupDto
    {
        public Guid Id { get; set; }
        public Guid? StockCardID { get; set; }
        public decimal? Price { get; set; }
        public string PriceType { get; set; }
    }
}
