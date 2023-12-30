using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using QuickSell.CustomerTypes;
using QuickSell.CustomerGroups;

namespace QuickSell.CustomerCards
{

    public class CustomerCardUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public Guid? CustomerTypeID { get; set; }
        public Guid? CustomerGroupID { get; set; }
        public string TaxOffice { get; set; }
        public int? TaxNo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AuthorizedPerson { get; set; }
        public string? EMail { get; set; }
        public decimal? RiskLimit { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}


