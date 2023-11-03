using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.CustomerCards;
using QuickSell.Districts;
using QuickSell.Cities;
using QuickSell.Countries;

namespace QuickSell.CustomerAddresses
{

    public class CustomerAddressUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public UNKNOWN_TYPE CustomerCardID { get; set; }
        public string AddressCode { get; set; }
        public string Road { get; set; }
        public string Street { get; set; }
        public string BuildingName { get; set; }
        public int? BuildingNo { get; set; }
        public int? PostCode { get; set; }
        public UNKNOWN_TYPE DistrictID { get; set; }
        public UNKNOWN_TYPE CityID { get; set; }
        public UNKNOWN_TYPE CountryID { get; set; }
        public Guid? CustomerCardId { get; set; }
        
        public Guid? DistrictId { get; set; }
        
        public Guid? CityId { get; set; }
        
        public Guid? CountryId { get; set; }
        
        public string ConcurrencyStamp { get; set; }
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}


