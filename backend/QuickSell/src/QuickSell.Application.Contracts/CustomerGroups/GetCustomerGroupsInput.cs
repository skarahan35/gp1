using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.CustomerGroups
{
    public class GetCustomerGroupsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetCustomerGroupsInput()
        {

        }
    }
}
