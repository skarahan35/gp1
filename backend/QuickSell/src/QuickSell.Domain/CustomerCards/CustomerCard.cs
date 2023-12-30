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
using QuickSell.Tools;

namespace QuickSell.CustomerCards
{
    
    public  class CustomerCard : FullAuditedAggregateRoot<Guid>, IMultiTenant, ICodeControlFields, INameControlFields
    {
        
        [StringLength(128,MinimumLength=0)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        public Guid? CustomerTypeID { get; set; }
        public Guid? CustomerGroupID { get; set; }
        [StringLength(128,MinimumLength=0)]
        public string TaxOffice { get; set; }
        public int? TaxNo { get; set; }
        [StringLength(13,MinimumLength=0)]
        public string PhoneNumber { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string AuthorizedPerson { get; set; }
        [StringLength(64,MinimumLength=0)]
        public string EMail { get; set; }
        public decimal? RiskLimit { get; set; }
        public Guid? TenantId { get; set; }


        public CustomerCard()
        {

        }

        
        public CustomerCard
        (
            Guid id
          ,string code 
          ,string name
          , Guid? customerTypeID
          , Guid? customerGroupID
          , string taxOffice 
          ,string phoneNumber
          , string authorizedPerson 
          ,string eMail 
          ,int? taxNo

          ,decimal? riskLimit

          

        )


        {
               Id = id;
                Code=code;
                Name=name;
                CustomerTypeID = customerTypeID;
                CustomerGroupID = customerGroupID;
                TaxOffice=taxOffice;
                PhoneNumber = phoneNumber;
                AuthorizedPerson=authorizedPerson;
                EMail=eMail;
                TaxNo=taxNo;
                RiskLimit=riskLimit;
        }


        
    }
}
