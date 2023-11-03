using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.StockPrices
{
    public class GetStockPricesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  StockPriceType { get; set; } 
             
        public int? StockPriceMin { get; set; } 
        public int? StockPriceMax { get; set; } 
        public GetStockPricesInput()
        {

        }
    }
}
