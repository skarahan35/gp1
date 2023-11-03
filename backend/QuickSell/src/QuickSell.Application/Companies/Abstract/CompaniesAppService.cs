
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


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.Companies
{
public abstract class CompaniesAppService :ApplicationService, ICompaniesAppService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly CompanyManager _companyManager;

    public CompaniesAppService(ICompanyRepository companyRepository,CompanyManager companyManager)
    {
        _companyRepository = companyRepository;
        _companyManager= companyManager;
    }

    
        [Authorize(QuickSellPermissions.Companies.Create)]
    public virtual async Task<CompanyDto> CreateAsync(CompanyCreateDto input)
        {

            var company = await _companyManager.CreateAsync(
                input.CompanyName,
                input.Road,
                input.Street,
                input.BuildingName,
                input.TaxOffice,
                input.Currency,
                input.WebSite,
                input.IncomingMail,
                input.SendingMail,
                input.WorkingYear,
                input.BuildingNo,
                input.PostCode,
                input.TaxNo,
                input.QuantityDecimal,
                input.PriceDecimal,
                input.AmountDecimal,
                input.DateFormat, 
                input.DistrictId,
                input.CityId,
                input.CountryId,
            );
           
            
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }

        [Authorize(QuickSellPermissions.Companies.Create)]
    public virtual async Task<PagedResultDto<CompanyDto>> GetListAsync(GetCompaniesInput input)
        {
            var totalCount = await _companyRepository.GetCountAsync(input.FilterText, input.CompanyName, input.Road, input.Street, input.BuildingName, input.TaxOffice, input.Currency, input.WebSite, input.IncomingMail, input.SendingMail, input.WorkingYear);
            var items = await _companyRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.CompanyName
            ,input.Road
            ,input.Street
            ,input.BuildingName
            ,input.TaxOffice
            ,input.Currency
            ,input.WebSite
            ,input.IncomingMail
            ,input.SendingMail
            ,input.WorkingYear
            ,input.BuildingNoMin
            ,input.BuildingNoMax 
            ,input.PostCodeMin
            ,input.PostCodeMax 
            ,input.TaxNoMin
            ,input.TaxNoMax 
            ,input.QuantityDecimalMin
            ,input.QuantityDecimalMax 
            ,input.PriceDecimalMin
            ,input.PriceDecimalMax 
            ,input.AmountDecimalMin
            ,input.AmountDecimalMax 
            ,input.DateFormatMin
            ,input.DateFormatMax 
          
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CompanyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< Company>, List<CompanyDto>>(items)
            };
        }


   

    public virtual async Task< CompanyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Company, CompanyDto>(await _companyRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.Companies.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.Companies.Edit)]
     public virtual async Task<CompanyDto> UpdateAsync(Guid id, CompanyUpdateDto input)
         {
    
            var company = await _companyManager.UpdateAsync(
                id,
                input.CompanyName,
                input.Road,
                input.Street,
                input.BuildingName,
                input.TaxOffice,
                input.Currency,
                input.WebSite,
                input.IncomingMail,
                input.SendingMail,
                input.WorkingYear,
                input.BuildingNo,
                input.PostCode,
                input.TaxNo,
                input.QuantityDecimal,
                input.PriceDecimal,
                input.AmountDecimal,
                input.DateFormat, 
                input.DistrictId,
                input.CityId,
                input.CountryId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<Company, CompanyDto>(company);
         }
    



         

        
         

}
}