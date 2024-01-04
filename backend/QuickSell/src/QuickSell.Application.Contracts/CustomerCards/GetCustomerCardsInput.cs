using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.CustomerCards
{
    public class GetCustomerCardsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
        public string  TaxOffice { get; set; } 
        public string PhoneNumber { get; set; } 
        public string  AuthorizedPerson { get; set; } 
        public string  EMail { get; set; } 
             
        public string? TaxNo { get; set; } 
        public int? RiskLimitMin { get; set; } 
        public int? RiskLimitMax { get; set; } 
        public GetCustomerCardsInput()
        {

        }
    }
}
