using QuickSell.Tools;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.Prefixes
{

    public class PrefixDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp, ICodeControlFields
    {
        
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Parameter { get; set; }
        public bool? BeUsed { get; set; }
        public string? ConcurrencyStamp { get; set; }   
    }
}


