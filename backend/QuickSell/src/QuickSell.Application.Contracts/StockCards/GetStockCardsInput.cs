using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.StockCards
{
    public class GetStockCardsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Name { get; set; } 
        public string  CurrencyType { get; set; } 
             
        public int? TransferredQuantityMin { get; set; } 
        public int? TransferredQuantityMax { get; set; } 
        public int? AvailableQuantityMin { get; set; } 
        public int? AvailableQuantityMax { get; set; } 
        public int? TotalEntryQuantityMin { get; set; } 
        public int? TotalEntryQuantityMax { get; set; } 
        public int? TotalOutputQuantityMin { get; set; } 
        public int? TotalOutputQuantityMax { get; set; } 
        public int? VATRateMin { get; set; } 
        public int? VATRateMax { get; set; } 
        public int? DiscountRateMin { get; set; } 
        public int? DiscountRateMax { get; set; } 
        public int? Price1Min { get; set; } 
        public int? Price1Max { get; set; } 
        public int? Price2Min { get; set; } 
        public int? Price2Max { get; set; } 
        public int? Price3Min { get; set; } 
        public int? Price3Max { get; set; } 
        public GetStockCardsInput()
        {

        }
    }
}
