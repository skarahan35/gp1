using QuickSell.Tools;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.CustomerCards
{

    public class CustomerCardDto: FullAuditedEntityDto<Guid>, IHasConcurrencyStamp, ICodeControlFields, INameControlFields
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public Guid? CustomerTypeID { get; set; }
        public Guid? CustomerGroupID { get; set; }
        public string TaxOffice { get; set; }
        public string? TaxNo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AuthorizedPerson { get; set; }
        public string? EMail { get; set; }
        public decimal? RiskLimit { get; set; }
        public string? ConcurrencyStamp { get; set; }     
    }
}


