using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using QuickSell.Tools;

namespace QuickSell.Prefixes
{

    public  class Prefix : FullAuditedAggregateRoot<Guid>, IMultiTenant, ICodeControlFields
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        [StringLength(10,MinimumLength=0)]
        public string? Parameter { get; set; }
        public bool? BeUsed { get; set; }
        public Guid? TenantId { get; set; }


        public Prefix()
        {

        }

        
        public Prefix
        (
            Guid id
          ,string? code 
          ,string? name 
          ,string? parameter 
          ,bool? beUsed
            

        )


        {
               Id = id;
                Code=code;
                Name=name;
                Parameter=parameter;
                 BeUsed=beUsed; 

        }


        
    }
}
