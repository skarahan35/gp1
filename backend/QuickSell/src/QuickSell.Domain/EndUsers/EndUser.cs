using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using QuickSell.Tools;

namespace QuickSell.EndUsers
{

    public  class EndUser : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [StringLength(64,MinimumLength=1)]
        public string? UserName { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Name { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? SurName { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? EMail { get; set; }
        [StringLength(13,MinimumLength=0)]
        public string? PhoneNumber { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Address { get; set; }
        [StringLength(256,MinimumLength=0)]
        public string? Password { get; set; }
        public Guid? TenantId { get; set; }


        public EndUser()
        {

        }

        
        public EndUser
        (
            Guid id
          ,string? userName 
          ,string? name 
          ,string? surName 
          ,string? eMail 
          ,string? phoneNumber 
          ,string? address 
          ,string? password 
            

        )


        {
               Id = id;
                UserName=userName;
                Name=name;
                SurName=surName;
                EMail=eMail;
                PhoneNumber=phoneNumber;
                Address=address;
                Password=password;

        }


        
    }
}
