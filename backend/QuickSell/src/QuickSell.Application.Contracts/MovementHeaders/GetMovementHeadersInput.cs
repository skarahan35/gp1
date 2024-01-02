using Volo.Abp.Application.Dtos;
using System;
using QuickSell.Shared;

namespace QuickSell.MovementHeaders
{
    public class GetMovementHeadersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public TypeEnum? TypeCode { get; set; } 
             
        public int? ReceiptNoMin { get; set; } 
        public int? ReceiptNoMax { get; set; } 
        public decimal? FirstAmountMin { get; set; } 
        public decimal? FirstAmountMax { get; set; } 
        public decimal? DiscountAmountMin { get; set; } 
        public decimal? DiscountAmountMax { get; set; } 
        public decimal? VATAmountMin { get; set; } 
        public decimal? VATAmountMax { get; set; } 
        public decimal? TotalAmountMin { get; set; } 
        public decimal? TotalAmountMax { get; set; } 
        public GetMovementHeadersInput()
        {

        }
    }
}
