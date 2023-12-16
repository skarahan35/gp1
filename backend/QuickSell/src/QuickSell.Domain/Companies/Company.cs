using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using QuickSell.Enums;
namespace QuickSell.Companies
{

    public  class Company : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(128,MinimumLength=0)]
        public string? CompanyName { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string? Road { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string? Street { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string? BuildingName { get; set; }
        public int? BuildingNo { get; set; }
        public int? PostCode { get; set; }
        public Guid? DistrictID { get; set; }
        public Guid? CityID { get; set; }
        public Guid? CountryID { get; set; }
        public int? TaxNo { get; set; }
        [StringLength(128,MinimumLength=0)]
        public string? TaxOffice { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string? Currency { get; set; }
        public DateEnum? DateFormat { get; set; }
        [StringLength(128,MinimumLength=0)]
        public string? WebSite { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string? IncomingMail { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string? SendingMail { get; set; }
        [StringLength(4,MinimumLength=0)]
        public string? WorkingYear { get; set; }
        public int? QuantityDecimal { get; set; }
        public int? PriceDecimal { get; set; }
        public int? AmountDecimal { get; set; }    
        public Guid? TenantId { get; set; }


        public Company()
        {

        }

        
        public Company
        (
            Guid id
          ,string? companyName 
          ,string? road 
          ,string? street 
          ,string? buildingName 
          ,string? taxOffice 
          ,string? currency 
          ,string? webSite 
          ,string? incomingMail 
          ,string? sendingMail 
          ,string? workingYear 
          ,int? buildingNo
          ,int? postCode
          ,int? taxNo
          ,int? quantityDecimal
          ,int? priceDecimal
          ,int? amountDecimal
          , DateEnum? dateFormat
          ,Guid? districtID
          ,Guid? cityID
          ,Guid? countryID
            

        )


        {
               Id = id;
                CompanyName=companyName;
                Road=road;
                Street=street;
                BuildingName=buildingName;
                TaxOffice=taxOffice;
                Currency=currency;
                WebSite=webSite;
                IncomingMail=incomingMail;
                SendingMail=sendingMail;
                WorkingYear=workingYear;
                BuildingNo=buildingNo;
                PostCode=postCode;
                TaxNo=taxNo;
                QuantityDecimal=quantityDecimal;
                PriceDecimal=priceDecimal;
                AmountDecimal=amountDecimal;
                 DateFormat=dateFormat; 
                DistrictID=districtID;
                CityID=cityID;
                CountryID=countryID;

        }


        
    }
}
