using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.StockCards;

namespace QuickSell.StockPrices
{

    public class StockPriceUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public Guid? StockCardID { get; set; }
        public decimal? Price { get; set; }
        public string PriceType { get; set; }
        public string? ConcurrencyStamp { get; set; }

    }
}


