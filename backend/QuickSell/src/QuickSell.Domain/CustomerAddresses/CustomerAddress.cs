using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.CustomerCards;
using QuickSell.Districts;
using QuickSell.Cities;
using QuickSell.Countries;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace QuickSell.CustomerAddresses
{
    
    public  class CustomerAddress : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public Guid? CustomerCardID { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string AddressCode { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string Road { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string Street { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string BuildingName { get; set; }
        public int? BuildingNo { get; set; }
        public int? PostCode { get; set; }
        public Guid? DistrictID { get; set; }
        public Guid? CityID { get; set; }
        public Guid? CountryID { get; set; }
        public Guid? CustomerCardId { get; set; }    
        public Guid? DistrictId { get; set; }    
        public Guid? CityId { get; set; }    
        public Guid? CountryId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public CustomerAddress()
        {

        }

        
        public CustomerAddress
        (
            Guid id
          ,string addressCode 
          ,string road 
          ,string street 
          ,string buildingName 
          ,int? buildingNo

          ,int? postCode

          ,Guid? customerCardId
          ,Guid? districtId
          ,Guid? cityId
          ,Guid? countryId
            

        )


        {
               Id = id;
                AddressCode=addressCode;
                Road=road;
                Street=street;
                BuildingName=buildingName;
                BuildingNo=buildingNo;
                PostCode=postCode;
                CustomerCardId=customerCardId;
                DistrictId=districtId;
                CityId=cityId;
                CountryId=countryId;

        }


        
    }
}
