using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.Countries
{

    public class CountryCreateDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}


