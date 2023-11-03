using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.StockTypes
{

    public class StockTypeDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Condition { get; set; }
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}


