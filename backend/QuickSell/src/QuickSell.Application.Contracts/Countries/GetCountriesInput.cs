using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.Countries
{
    public class GetCountriesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetCountriesInput()
        {

        }
    }
}
