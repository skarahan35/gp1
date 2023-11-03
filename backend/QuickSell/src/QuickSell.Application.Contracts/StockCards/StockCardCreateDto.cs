using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockGroups;

namespace QuickSell.StockCards
{

    public class StockCardCreateDto
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        public UNKNOWN_TYPE StockTypeID { get; set; }
        public UNKNOWN_TYPE StockUnitID { get; set; }
        public UNKNOWN_TYPE StockGroupID { get; set; }
        public int? TransferredQuantity { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? TotalEntryQuantity { get; set; }
        public int? TotalOutputQuantity { get; set; }
        public int? VATRate { get; set; }
        public int? DiscountRate { get; set; }
        public string CurrencyType { get; set; }
        public int? Price1 { get; set; }
        public int? Price2 { get; set; }
        public int? Price3 { get; set; }
        public Guid? StockTypeId { get; set; }
        public Guid? StockUnitId { get; set; }
        public Guid? StockGroupId { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}


