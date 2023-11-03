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

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace QuickSell.StockCards
{
    
    public  class StockCard : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public string Code { get; set; }
        [StringLength(256,MinimumLength=0)]
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
        [StringLength(64,MinimumLength=0)]
        public string CurrencyType { get; set; }
        public int? Price1 { get; set; }
        public int? Price2 { get; set; }
        public int? Price3 { get; set; }
        
        
        public Guid? StockTypeId { get; set; }    
        public Guid? StockUnitId { get; set; }    
        public Guid? StockGroupId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public StockCard()
        {

        }

        
        public StockCard
        (
            Guid id
          ,string code 
          ,string name 
          ,string currencyType 
          ,int? transferredQuantity

          ,int? availableQuantity

          ,int? totalEntryQuantity

          ,int? totalOutputQuantity

          ,int? vAtRate

          ,int? discountRate

          ,int? price1

          ,int? price2

          ,int? price3

          ,Guid? stockTypeId
          ,Guid? stockUnitId
          ,Guid? stockGroupId
            

        )


        {
               Id = id;
                Code=code;
                Name=name;
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
                StockTypeId=stockTypeId;
                StockUnitId=stockUnitId;
                StockGroupId=stockGroupId;

        }


        
    }
}
