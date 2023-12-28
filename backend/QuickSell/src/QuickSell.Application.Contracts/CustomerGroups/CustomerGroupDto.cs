using QuickSell.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.CustomerGroups
{

    public class CustomerGroupDto: FullAuditedEntityDto<Guid>, IHasConcurrencyStamp, ICodeControlFields, INameControlFields
    {
        public string? Code { get; set; }
        [StringLength(256, MinimumLength = 0)]
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; } 
    }
}


