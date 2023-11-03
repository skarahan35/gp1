using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.CustomerTypes
{
    public class GetCustomerTypesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetCustomerTypesInput()
        {

        }
    }
}
