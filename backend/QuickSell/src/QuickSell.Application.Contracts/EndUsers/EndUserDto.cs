using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.EndUsers
{

    public class EndUserDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {

        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? EMail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? ConcurrencyStamp { get; set; } 

    }
}


