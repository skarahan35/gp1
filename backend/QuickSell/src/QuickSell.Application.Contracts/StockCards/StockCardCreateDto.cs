using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockGroups;
using QuickSell.Shared;

namespace QuickSell.StockCards
{

    public class StockCardCreateDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public Guid? StockTypeID { get; set; }
        public Guid? StockUnitID { get; set; }
        public Guid? StockGroupID { get; set; }
        public decimal? TransferredQuantity { get; set; }
        public decimal? AvailableQuantity { get; set; }
        public decimal? TotalEntryQuantity { get; set; }
        public decimal? TotalOutputQuantity { get; set; }
        public int? VATRate { get; set; }
        public int? DiscountRate { get; set; }
        public CurrencyTypeEnum? CurrencyType { get; set; }
        public decimal? Price1 { get; set; }
        public decimal? Price2 { get; set; }
        public decimal? Price3 { get; set; }

    }
}


