using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.Prefixes
{
    public class GetPrefixesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
        public string  Parameter { get; set; } 
             
        public bool? BeUsed { get; set; }  
        public GetPrefixesInput()
        {

        }
    }
}
