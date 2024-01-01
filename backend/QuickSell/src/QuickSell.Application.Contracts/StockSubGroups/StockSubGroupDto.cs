using QuickSell.Tools;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockSubGroups
{

    public class StockSubGroupDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp,ICodeControlFields,INameControlFields
    {
        
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; } 
    }
}


