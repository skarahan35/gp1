using QuickSell.Tools;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockUnits
{

    public class StockUnitDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp,IControlFields
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; }  
    }
}


