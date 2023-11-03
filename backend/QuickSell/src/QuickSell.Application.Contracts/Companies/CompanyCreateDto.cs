using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.Districts;
using QuickSell.Cities;
using QuickSell.Countries;

namespace QuickSell.Companies
{

    public class CompanyCreateDto
    {
        
        public string CompanyName { get; set; }
        public string Road { get; set; }
        public string Street { get; set; }
        public string BuildingName { get; set; }
        public int? BuildingNo { get; set; }
        public int? PostCode { get; set; }
        public UNKNOWN_TYPE DistrictID { get; set; }
        public UNKNOWN_TYPE CityID { get; set; }
        public UNKNOWN_TYPE CountryID { get; set; }
        public int? TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string Currency { get; set; }
        public bool? DateFormat { get; set; }
        public string WebSite { get; set; }
        public string IncomingMail { get; set; }
        public string SendingMail { get; set; }
        public string WorkingYear { get; set; }
        public int? QuantityDecimal { get; set; }
        public int? PriceDecimal { get; set; }
        public int? AmountDecimal { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}


