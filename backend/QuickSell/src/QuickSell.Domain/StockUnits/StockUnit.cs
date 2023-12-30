using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using QuickSell.Tools;
namespace QuickSell.StockUnits
{

    public  class StockUnit : FullAuditedAggregateRoot<Guid>, IMultiTenant, ICodeControlFields, INameControlFields
    {
        
        [StringLength(64,MinimumLength=1)]
        public string? Code { get; set; }

        [StringLength(5, MinimumLength = 1)]
        public string? InternationalCode { get; set; }

        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        public Guid? TenantId { get; set; }

        public StockUnit()
        {

        }

        
        public StockUnit
        (
            Guid id
          ,string? code 
          ,string? internationalCode
          , string? name 
            

        )


        {
               Id = id;
                Code=code;
            InternationalCode = internationalCode;
                Name=name;

        }


        
    }
}
