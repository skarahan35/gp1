
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickSell.Permissions;
using QuickSell.Companies;
using QuickSell.Shared;

namespace QuickSell.Companies
{
    public class CompaniesAppService :ApplicationService, ICompaniesAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyManager _companyManager;
    
        public CompaniesAppService(ICompanyRepository companyRepository,CompanyManager companyManager)
        {
            _companyRepository = companyRepository;
            _companyManager= companyManager;
        }
    
    }
}