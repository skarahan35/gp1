using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.StockGroups
{
    public class GetStockGroupsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetStockGroupsInput()
        {

        }
    }
}
