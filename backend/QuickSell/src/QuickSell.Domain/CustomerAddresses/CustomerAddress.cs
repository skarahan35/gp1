using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace QuickSell.CustomerAddresses
{

    public  class CustomerAddress : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
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
