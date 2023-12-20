using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.CustomerSubGroups
{

    public class CustomerSubGroupDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}


