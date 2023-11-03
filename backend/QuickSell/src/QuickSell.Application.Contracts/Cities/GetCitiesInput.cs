using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.Cities
{
    public class GetCitiesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetCitiesInput()
        {

        }
    }
}
