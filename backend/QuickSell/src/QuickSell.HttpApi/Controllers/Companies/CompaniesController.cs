



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuickSell.Companies;



namespace  QuickSell.Controllers.Companies
{
    
    public class CompaniesController : AbpController,ICompaniesAppService
    {
        private readonly ICompaniesAppService _companiesAppService;

        

        public CompaniesController(ICompaniesAppService companiesAppService)
       {
        _companiesAppService = companiesAppService;
       }

    }
}
