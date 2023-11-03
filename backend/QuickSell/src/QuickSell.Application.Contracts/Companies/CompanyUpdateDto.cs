using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.Districts;
using QuickSell.Cities;
using QuickSell.Countries;
using QuickSell.Enums;

namespace QuickSell.Companies
{

    public class CompanyUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Road { get; set; }
        public string? Street { get; set; }
        public string? BuildingName { get; set; }
        public int? BuildingNo { get; set; }
        public int? PostCode { get; set; }
        public Guid? DistrictID { get; set; }
        public Guid? CityID { get; set; }
        public Guid? CountryID { get; set; }
        public int? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? Currency { get; set; }
        public DateEnum? DateFormat { get; set; }
        public string? WebSite { get; set; }
        public string? IncomingMail { get; set; }
        public string? SendingMail { get; set; }
        public string? WorkingYear { get; set; }
        public int? QuantityDecimal { get; set; }
        public int? PriceDecimal { get; set; }
        public int? AmountDecimal { get; set; }

        public string? ConcurrencyStamp { get; set; }




        
        

    }
}


