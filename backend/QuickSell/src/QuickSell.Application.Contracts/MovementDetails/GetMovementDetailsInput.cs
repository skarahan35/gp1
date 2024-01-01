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
        public decimal? QuantityMin { get; set; } 
        public decimal? QuantityMax { get; set; } 
        public decimal? PriceMin { get; set; } 
        public decimal? PriceMax { get; set; } 
        public decimal? DiscountRateMin { get; set; } 
        public decimal? DiscountRateMax { get; set; } 
        public decimal? DiscountAmountMin { get; set; } 
        public decimal? DiscountAmountMax { get; set; } 
        public decimal? VATRateMin { get; set; } 
        public decimal? VATRateMax { get; set; } 
        public decimal? VATAmountMin { get; set; } 
        public decimal? VATAmountMax { get; set; }
        public decimal? FirstAmountMin { get; set; }
        public decimal? FirstAmountMax { get; set; }
        public decimal? TotalAmountMin { get; set; }
        public decimal? TotalAmountMax { get; set; }
        public GetMovementDetailInput()
        {

        }
    }
}
