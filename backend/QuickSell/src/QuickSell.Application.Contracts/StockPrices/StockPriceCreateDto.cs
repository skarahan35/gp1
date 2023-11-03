using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.StockCards;

namespace QuickSell.StockPrices
{

    public class StockPriceCreateDto
    {
        
        public UNKNOWN_TYPE StockID { get; set; }
        public int? StockPrice { get; set; }
        public string StockPriceType { get; set; }
        public Guid? StockCardId { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}


