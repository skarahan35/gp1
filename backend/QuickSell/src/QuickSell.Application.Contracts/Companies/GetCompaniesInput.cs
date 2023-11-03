using Volo.Abp.Application.Dtos;
using System;
using QuickSell.Enums;

namespace QuickSell.Companies
{
    public class GetCompaniesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  CompanyName { get; set; } 
        public string  Road { get; set; } 
        public string  Street { get; set; } 
        public string  BuildingName { get; set; } 
        public string  TaxOffice { get; set; } 
        public string  Currency { get; set; } 
        public string  WebSite { get; set; } 
        public string  IncomingMail { get; set; } 
        public string  SendingMail { get; set; } 
        public string  WorkingYear { get; set; } 
             
        public int? BuildingNoMin { get; set; } 
        public int? BuildingNoMax { get; set; } 
        public int? PostCodeMin { get; set; } 
        public int? PostCodeMax { get; set; } 
        public int? TaxNoMin { get; set; } 
        public int? TaxNoMax { get; set; } 
        public int? QuantityDecimalMin { get; set; } 
        public int? QuantityDecimalMax { get; set; } 
        public int? PriceDecimalMin { get; set; } 
        public int? PriceDecimalMax { get; set; } 
        public int? AmountDecimalMin { get; set; } 
        public int? AmountDecimalMax { get; set; } 
        public DateEnum? DateFormat { get; set; }  
        public GetCompaniesInput()
        {

        }
    }
}
