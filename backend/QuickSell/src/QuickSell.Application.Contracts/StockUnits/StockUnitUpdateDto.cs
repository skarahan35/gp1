using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockUnits
{

    public class StockUnitUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? InternationalCode { get; set; }
        public string? Name { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}


