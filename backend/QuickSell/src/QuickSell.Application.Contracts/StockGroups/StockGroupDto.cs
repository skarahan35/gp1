using QuickSell.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockGroups
{

    public class StockGroupDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp,ICodeControlFields,INameControlFields
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; }   
    }
}


