using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockUnits
{

    public class StockUnitCreateDto
    {
        public string? Code { get; set; }
        public string? InternationalCode { get; set; }
        public string? Name { get; set; }

    }
}


