using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.StockSubGroups
{
    public class GetStockSubGroupsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetStockSubGroupsInput()
        {

        }
    }
}
