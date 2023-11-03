using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.Districts
{
    public class GetDistrictsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
             
        public GetDistrictsInput()
        {

        }
    }
}
