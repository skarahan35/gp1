using System;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockSubGroups
{

    public class StockSubGroupUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; }

    }
}


