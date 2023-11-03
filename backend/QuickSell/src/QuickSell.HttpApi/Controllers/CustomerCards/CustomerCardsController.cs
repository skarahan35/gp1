



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.CustomerCards;



namespace  QuickSell.Controllers.CustomerCards
{
    
    public class CustomerCardsController : AbpController,ICustomerCardsAppService
    {
        private readonly ICustomerCardsAppService _customerCardsAppService;

        

        public CustomerCardsController(ICustomerCardsAppService customerCardsAppService)
       {
        _customerCardsAppService = customerCardsAppService;
       }

        
    }
}
