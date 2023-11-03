using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.MovementHeaders
{
    public class GetMovementHeadersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  TypeCode { get; set; } 
             
        public int? ReceiptNoMin { get; set; } 
        public int? ReceiptNoMax { get; set; } 
        public int? FirstAmountMin { get; set; } 
        public int? FirstAmountMax { get; set; } 
        public int? DiscountAmountMin { get; set; } 
        public int? DiscountAmountMax { get; set; } 
        public int? VATAmountMin { get; set; } 
        public int? VATAmountMax { get; set; } 
        public int? TotalAmountMin { get; set; } 
        public int? TotalAmountMax { get; set; } 
        public GetMovementHeadersInput()
        {

        }
    }
}
