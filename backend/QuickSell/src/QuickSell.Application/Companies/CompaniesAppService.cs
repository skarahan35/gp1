
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
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;
using QuickSell.Enums;

namespace QuickSell.Companies
{
    public class CompaniesAppService :ApplicationService, ICompaniesAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyManager _companyManager;
        private readonly IDataFilter _dataFilter;

        public CompaniesAppService(ICompanyRepository companyRepository,
                                   CompanyManager companyManager,
                                   IDataFilter dataFilter)
        {
            _companyRepository = companyRepository;
            _companyManager= companyManager;
            _dataFilter= dataFilter;
        }
        public async Task<LoadResult> GetListCompany(DataSourceLoadOptions loadOptions)
        {
            var getCompany = await _companyRepository.GetQueryableAsync();

            var getJoinedData = from cmpny in getCompany
                                select new DxCompanyLookupDto
                                {
                                    Id = cmpny.Id,
                                    CompanyName = cmpny.CompanyName,
                                    Road = cmpny.Road,
                                    Street = cmpny.Street,
                                    BuildingName= cmpny.BuildingName,
                                    BuildingNo= cmpny.BuildingNo,
                                    PostCode= cmpny.PostCode,
                                    DistrictID = cmpny.DistrictID,
                                    CityID= cmpny.CityID,
                                    CountryID= cmpny.CountryID,
                                    TaxNo= cmpny.TaxNo,
                                    TaxOffice = cmpny.TaxOffice,
                                    Currency= cmpny.Currency,
                                    DateFormat= cmpny.DateFormat,
                                    WebSite= cmpny.WebSite,
                                    IncomingMail= cmpny.IncomingMail,
                                    SendingMail= cmpny.SendingMail,
                                    WorkingYear= cmpny.WorkingYear,
                                    QuantityDecimal= cmpny.QuantityDecimal,
                                    PriceDecimal= cmpny.PriceDecimal,
                                    AmountDecimal= cmpny.AmountDecimal,
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCompanyLookupDto?> GetCompanyByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCompany = (await _companyRepository.GetQueryableAsync());
                var company = (from cmpny in getCompany
                               where cmpny.Id == id
                                 select new DxCompanyLookupDto
                                 {
                                     Id = cmpny.Id,
                                     CompanyName = cmpny.CompanyName,
                                     Road = cmpny.Road,
                                     Street = cmpny.Street,
                                     BuildingName = cmpny.BuildingName,
                                     BuildingNo = cmpny.BuildingNo,
                                     PostCode = cmpny.PostCode,
                                     DistrictID = cmpny.DistrictID,
                                     CityID = cmpny.CityID,
                                     CountryID = cmpny.CountryID,
                                     TaxNo = cmpny.TaxNo,
                                     TaxOffice = cmpny.TaxOffice,
                                     Currency = cmpny.Currency,
                                     DateFormat = cmpny.DateFormat,
                                     WebSite = cmpny.WebSite,
                                     IncomingMail = cmpny.IncomingMail,
                                     SendingMail = cmpny.SendingMail,
                                     WorkingYear = cmpny.WorkingYear,
                                     QuantityDecimal = cmpny.QuantityDecimal,
                                     PriceDecimal = cmpny.PriceDecimal,
                                     AmountDecimal = cmpny.AmountDecimal,
                                 }).FirstOrDefault();
                return company;
            }
        }
        public async Task<CompanyDto> AddCompany(CompanyDto input)
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
              input.DistrictID,
              input.CityID,
              input.CountryID
          );
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }
        public async Task<CompanyDto> UpdateCompany(Guid id, IDictionary<string, object> input)
        {
            var company = await _companyRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(company, input);
            await _companyRepository.UpdateAsync(updated);
            return ObjectMapper.Map<Company, CompanyDto>(updated);
        }
        public async Task DeleteCompany(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

    }
}