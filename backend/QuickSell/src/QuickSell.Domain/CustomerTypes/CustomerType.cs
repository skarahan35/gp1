using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using QuickSell.Tools;

namespace QuickSell.CustomerTypes
{

    public  class CustomerType : FullAuditedAggregateRoot<Guid>, IMultiTenant,ICodeControlFields,INameControlFields
    {
        
        [StringLength(64,MinimumLength=0)]
        public string? Code { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        
        public Guid? TenantId { get; set; }


        public CustomerType()
        {

        }

        
        public CustomerType
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
