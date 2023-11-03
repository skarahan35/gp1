using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.CustomerAddresses;
using QuickSell.MovementHeaders;
using QuickSell.CustomerTypes;
using QuickSell.CustomerGroups;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace QuickSell.CustomerCards
{
    
    public  class CustomerCard : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(128,MinimumLength=0)]
        public string Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string Name { get; set; }
        public UNKNOWN_TYPE CustomerTypeID { get; set; }
        public UNKNOWN_TYPE AddressID { get; set; }
        public UNKNOWN_TYPE CustomerGroupID { get; set; }
        [StringLength(128,MinimumLength=0)]
        public string TaxOffice { get; set; }
        public int? TaxNo { get; set; }
        [StringLength(11,MinimumLength=0)]
        public string TCNumber { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string AuthorizedPerson { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string EMail { get; set; }
        public int? RiskLimit { get; set; }
        
        
        public Guid? CustomerTypeId { get; set; }    
        public Guid? CustomerGroupId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public CustomerCard()
        {

        }

        
        public CustomerCard
        (
            Guid id
          ,string code 
          ,string name 
          ,string taxOffice 
          ,string tCNumber 
          ,string authorizedPerson 
          ,string eMail 
          ,int? taxNo

          ,int? riskLimit

          ,Guid? customerTypeId
          ,Guid? customerGroupId
            

        )


        {
               Id = id;
                Code=code;
                Name=name;
                TaxOffice=taxOffice;
                TCNumber=tCNumber;
                AuthorizedPerson=authorizedPerson;
                EMail=eMail;
                TaxNo=taxNo;
                RiskLimit=riskLimit;
                CustomerTypeId=customerTypeId;
                CustomerGroupId=customerGroupId;

        }


        
    }
}
