using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.StockTypes
{
    public class GetStockTypesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public bool? Condition { get; set; }  
        public GetStockTypesInput()
        {

        }
    }
}
