using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;
using QuickSell.Enums;

namespace QuickSell.Companies
{
    public class CompanyManager : DomainService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> CreateAsync(
              string? companyName, 
              string? road, 
              string? street, 
              string? buildingName, 
              string? taxOffice, 
              string? currency, 
              string? webSite, 
              string? incomingMail, 
              string? sendingMail, 
              string? workingYear, 
              int? buildingNo, 
              int? postCode, 
              int? taxNo, 
              int? quantityDecimal, 
              int? priceDecimal, 
              int? amountDecimal,
              DateEnum? dateFormat, 
              Guid? districtID,
              Guid? cityID,
              Guid? countryID
        )
        {

            var company = new Company(
             GuidGenerator.Create(),
               companyName, 
               road, 
               street, 
               buildingName, 
               taxOffice, 
               currency, 
               webSite, 
               incomingMail, 
               sendingMail, 
               workingYear, 
               buildingNo, 
               postCode, 
               taxNo, 
               quantityDecimal, 
               priceDecimal, 
               amountDecimal, 
                dateFormat, 
               districtID,
               cityID,
               countryID
             );

            return await _companyRepository.InsertAsync(company);
        }

        public async Task<Company> UpdateAsync(
           Guid id,
          string? companyName, 
          string? road, 
          string? street, 
          string? buildingName, 
          string? taxOffice, 
          string? currency, 
          string? webSite, 
          string? incomingMail, 
          string? sendingMail, 
          string? workingYear, 
          int? buildingNo, 
          int? postCode, 
          int? taxNo, 
          int? quantityDecimal, 
          int? priceDecimal, 
          int? amountDecimal,
          DateEnum? dateFormat, 
          Guid? districtID,
          Guid? cityID,
          Guid? countryID,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _companyRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var company = await AsyncExecuter.FirstOrDefaultAsync(query);

                company.CompanyName=companyName;
                company.Road=road;
                company.Street=street;
                company.BuildingName=buildingName;
                company.TaxOffice=taxOffice;
                company.Currency=currency;
                company.WebSite=webSite;
                company.IncomingMail=incomingMail;
                company.SendingMail=sendingMail;
                company.WorkingYear=workingYear;
                 company.BuildingNo=buildingNo;
                 company.PostCode=postCode;
                 company.TaxNo=taxNo;
                 company.QuantityDecimal=quantityDecimal;
                 company.PriceDecimal=priceDecimal;
                 company.AmountDecimal=amountDecimal;
                company.DateFormat=dateFormat;  
                company.DistrictID=districtID;
                company.CityID=cityID;
                company.CountryID=countryID;

         company.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyRepository.UpdateAsync(company);
        }

    }
}