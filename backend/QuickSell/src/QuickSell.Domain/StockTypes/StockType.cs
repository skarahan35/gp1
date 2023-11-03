using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using QuickSell.StockCards;


namespace QuickSell.StockTypes
{
    
    public  class StockType : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=1)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        public bool? Condition { get; set; }
        
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public StockType()
        {

        }

        
        public StockType
        (
            Guid id
          ,string? code 
          ,string? name 
          ,bool? condition
            

        )


        {
               Id = id;
                Code=code;
                Name=name;
                 Condition=condition; 

        }


        
    }
}
