using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.StockCards;

namespace QuickSell.MovementDetails
{

    public class MovementDetailsCreateDto
    {
        
        public string TypeCode { get; set; }
        public int? ReceiptNo { get; set; }
        public UNKNOWN_TYPE StockCardID { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? DiscountRate { get; set; }
        public int? DiscountAmount { get; set; }
        public int? VATRate { get; set; }
        public int? VATAmount { get; set; }
        public Guid? StockCardId { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}


