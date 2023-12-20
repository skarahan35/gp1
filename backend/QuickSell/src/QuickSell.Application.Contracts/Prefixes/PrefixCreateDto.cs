using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace QuickSell.Prefixes
{

    public class PrefixCreateDto
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Parameter { get; set; }
        public bool? BeUsed { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}


