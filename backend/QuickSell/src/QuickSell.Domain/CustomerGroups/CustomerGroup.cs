using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.CustomerCards;
using QuickSell.Tools;

namespace QuickSell.CustomerGroups
{
    
    public  class CustomerGroup : FullAuditedAggregateRoot<Guid>, IMultiTenant, ICodeControlFields, INameControlFields
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        
        public Guid? TenantId { get; set; }


        public CustomerGroup()
        {

        }

        
        public CustomerGroup
        (
            Guid id
          ,string? code 
          ,string? name 
            

        )


        {
               Id = id;
                Code=code;
                Name=name;

        }


        
    }
}
