using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.StockPrices;
using QuickSell.MovementDetails;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockGroups;
using QuickSell.Tools;

namespace QuickSell.StockCards
{
    
    public  class StockCard : FullAuditedAggregateRoot<Guid>, IMultiTenant, ICodeControlFields, INameControlFields
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
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
        [StringLength(64,MinimumLength=0)]
        public string CurrencyType { get; set; }
        public decimal? Price1 { get; set; }
        public decimal? Price2 { get; set; }
        public decimal? Price3 { get; set; }
        public Guid? TenantId { get; set; }


        public StockCard()
        {

        }

        
        public StockCard
        (
            Guid id
          ,string? code 
          ,string? name
          , Guid? stockTypeID
          , Guid? stockUnitID
          , Guid? stockGroupID
          , string currencyType 
          ,decimal? transferredQuantity
          ,decimal? availableQuantity
          ,decimal? totalEntryQuantity
          ,decimal? totalOutputQuantity
          ,int? vAtRate
          ,int? discountRate
          ,decimal? price1
          ,decimal? price2
          ,decimal? price3

        )


        {
               Id = id;
                Code=code;
                Name=name;
                StockTypeID=stockTypeID;
                StockUnitID=stockUnitID;
                StockGroupID=stockGroupID;
                CurrencyType=currencyType;
                TransferredQuantity=transferredQuantity;
                AvailableQuantity=availableQuantity;
                TotalEntryQuantity=totalEntryQuantity;
                TotalOutputQuantity=totalOutputQuantity;
                VATRate=vAtRate;
                DiscountRate=discountRate;
                Price1=price1;
                Price2=price2;
                Price3=price3;

        }


        
    }
}
