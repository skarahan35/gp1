using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.MovementDetails
{
    public class GetMovementDetailInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  TypeCode { get; set; } 
             
        public int? ReceiptNoMin { get; set; } 
        public int? ReceiptNoMax { get; set; } 
        public int? QuantityMin { get; set; } 
        public int? QuantityMax { get; set; } 
        public int? PriceMin { get; set; } 
        public int? PriceMax { get; set; } 
        public int? DiscountRateMin { get; set; } 
        public int? DiscountRateMax { get; set; } 
        public int? DiscountAmountMin { get; set; } 
        public int? DiscountAmountMax { get; set; } 
        public int? VATRateMin { get; set; } 
        public int? VATRateMax { get; set; } 
        public int? VATAmountMin { get; set; } 
        public int? VATAmountMax { get; set; } 
        public GetMovementDetailInput()
        {

        }
    }
}
