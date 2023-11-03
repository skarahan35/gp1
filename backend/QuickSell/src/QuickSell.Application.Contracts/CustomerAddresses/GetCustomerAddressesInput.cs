using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.CustomerAddresses
{
    public class GetCustomerAddressesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  AddressCode { get; set; } 
        public string  Road { get; set; } 
        public string  Street { get; set; } 
        public string  BuildingName { get; set; } 
             
        public int? BuildingNoMin { get; set; } 
        public int? BuildingNoMax { get; set; } 
        public int? PostCodeMin { get; set; } 
        public int? PostCodeMax { get; set; } 
        public GetCustomerAddressesInput()
        {

        }
    }
}
