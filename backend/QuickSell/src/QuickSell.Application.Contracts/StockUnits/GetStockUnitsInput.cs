using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.StockUnits
{
    public class GetStockUnitsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; }
        public string InternationalCode { get; set; }
        public string  Name { get; set; } 
             
        public GetStockUnitsInput()
        {

        }
    }
}
