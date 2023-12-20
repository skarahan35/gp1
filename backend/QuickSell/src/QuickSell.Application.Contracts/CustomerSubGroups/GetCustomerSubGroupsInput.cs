using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.CustomerSubGroups
{
    public class GetCustomerSubGroupsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetCustomerSubGroupsInput()
        {

        }
    }
}
