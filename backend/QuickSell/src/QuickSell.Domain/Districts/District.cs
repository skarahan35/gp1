using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace QuickSell.Districts
{

    public  class District : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        
        
        public Guid? TenantId { get; set; }


        public District()
        {

        }

        
        public District
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
