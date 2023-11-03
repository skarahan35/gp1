
using AutoMapper;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using QuickSell.Infrastructure.Data;
using QuickSell.Domain.Entities;
using QuickSell.Domain.Repositories.Interfaces;
using QuickSell.Dto;
using QuickSell.Configuration.AutoMapper;
using QuickSell.Test.Setup;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Xunit;

namespace QuickSell.Test.Controllers
{
    public class CompaniesControllerIntTest
    {
        public CompaniesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _companyRepository = _factory.GetRequiredService<ICompanyRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private const string DefaultCompanyName = "AAAAAAAAAA";
        private const string UpdatedCompanyName = "BBBBBBBBBB";

        private const string DefaultRoad = "AAAAAAAAAA";
        private const string UpdatedRoad = "BBBBBBBBBB";

        private const string DefaultStreet = "AAAAAAAAAA";
        private const string UpdatedStreet = "BBBBBBBBBB";

        private const string DefaultBuildingName = "AAAAAAAAAA";
        private const string UpdatedBuildingName = "BBBBBBBBBB";

        private static readonly int? DefaultBuildingNo = 1;
        private static readonly int? UpdatedBuildingNo = 2;

        private static readonly int? DefaultPostCode = 1;
        private static readonly int? UpdatedPostCode = 2;

        private static readonly UNKNOWN_TYPE DefaultDistrictID = ;
        private static readonly UNKNOWN_TYPE UpdatedDistrictID = ;

        private static readonly UNKNOWN_TYPE DefaultCityID = ;
        private static readonly UNKNOWN_TYPE UpdatedCityID = ;

        private static readonly UNKNOWN_TYPE DefaultCountryID = ;
        private static readonly UNKNOWN_TYPE UpdatedCountryID = ;

        private static readonly int? DefaultTaxNo = 1;
        private static readonly int? UpdatedTaxNo = 2;

        private const string DefaultTaxOffice = "AAAAAAAAAA";
        private const string UpdatedTaxOffice = "BBBBBBBBBB";

        private const string DefaultCurrency = "AAAAAAAAAA";
        private const string UpdatedCurrency = "BBBBBBBBBB";

        private static readonly bool? DefaultDateFormat = false;
        private static readonly bool? UpdatedDateFormat = true;

        private const string DefaultWebSite = "AAAAAAAAAA";
        private const string UpdatedWebSite = "BBBBBBBBBB";

        private const string DefaultIncomingMail = "AAAAAAAAAA";
        private const string UpdatedIncomingMail = "BBBBBBBBBB";

        private const string DefaultSendingMail = "AAAAAAAAAA";
        private const string UpdatedSendingMail = "BBBBBBBBBB";

        private const string DefaultWorkingYear = "AAAAAAAAAA";
        private const string UpdatedWorkingYear = "BBBBBBBBBB";

        private static readonly int? DefaultQuantityDecimal = 1;
        private static readonly int? UpdatedQuantityDecimal = 2;

        private static readonly int? DefaultPriceDecimal = 1;
        private static readonly int? UpdatedPriceDecimal = 2;

        private static readonly int? DefaultAmountDecimal = 1;
        private static readonly int? UpdatedAmountDecimal = 2;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly ICompanyRepository _companyRepository;

        private Company _company;

        private readonly IMapper _mapper;

        private Company CreateEntity()
        {
            return new Company
            {
                CompanyName = DefaultCompanyName,
                Road = DefaultRoad,
                Street = DefaultStreet,
                BuildingName = DefaultBuildingName,
                BuildingNo = DefaultBuildingNo,
                PostCode = DefaultPostCode,
                DistrictID = DefaultDistrictID,
                CityID = DefaultCityID,
                CountryID = DefaultCountryID,
                TaxNo = DefaultTaxNo,
                TaxOffice = DefaultTaxOffice,
                Currency = DefaultCurrency,
                DateFormat = DefaultDateFormat,
                WebSite = DefaultWebSite,
                IncomingMail = DefaultIncomingMail,
                SendingMail = DefaultSendingMail,
                WorkingYear = DefaultWorkingYear,
                QuantityDecimal = DefaultQuantityDecimal,
                PriceDecimal = DefaultPriceDecimal,
                AmountDecimal = DefaultAmountDecimal,
            };
        }

        private void InitTest()
        {
            _company = CreateEntity();
        }

        [Fact]
        public async Task CreateCompany()
        {
            var databaseSizeBeforeCreate = await _companyRepository.CountAsync();

            // Create the Company
            CompanyDto _companyDto = _mapper.Map<CompanyDto>(_company);
            var response = await _client.PostAsync("/api/companies", TestUtil.ToJsonContent(_companyDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the Company in the database
            var companyList = await _companyRepository.GetAllAsync();
            companyList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCompany = companyList.Last();
            testCompany.CompanyName.Should().Be(DefaultCompanyName);
            testCompany.Road.Should().Be(DefaultRoad);
            testCompany.Street.Should().Be(DefaultStreet);
            testCompany.BuildingName.Should().Be(DefaultBuildingName);
            testCompany.BuildingNo.Should().Be(DefaultBuildingNo);
            testCompany.PostCode.Should().Be(DefaultPostCode);
            testCompany.DistrictID.Should().Be(DefaultDistrictID);
            testCompany.CityID.Should().Be(DefaultCityID);
            testCompany.CountryID.Should().Be(DefaultCountryID);
            testCompany.TaxNo.Should().Be(DefaultTaxNo);
            testCompany.TaxOffice.Should().Be(DefaultTaxOffice);
            testCompany.Currency.Should().Be(DefaultCurrency);
            testCompany.DateFormat.Should().Be(DefaultDateFormat);
            testCompany.WebSite.Should().Be(DefaultWebSite);
            testCompany.IncomingMail.Should().Be(DefaultIncomingMail);
            testCompany.SendingMail.Should().Be(DefaultSendingMail);
            testCompany.WorkingYear.Should().Be(DefaultWorkingYear);
            testCompany.QuantityDecimal.Should().Be(DefaultQuantityDecimal);
            testCompany.PriceDecimal.Should().Be(DefaultPriceDecimal);
            testCompany.AmountDecimal.Should().Be(DefaultAmountDecimal);
        }

        [Fact]
        public async Task CreateCompanyWithExistingId()
        {
            var databaseSizeBeforeCreate = await _companyRepository.CountAsync();
            // Create the Company with an existing ID
            _company.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CompanyDto _companyDto = _mapper.Map<CompanyDto>(_company);
            var response = await _client.PostAsync("/api/companies", TestUtil.ToJsonContent(_companyDto));

            // Validate the Company in the database
            var companyList = await _companyRepository.GetAllAsync();
            companyList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCompanies()
        {
            // Initialize the database
            await _companyRepository.CreateOrUpdateAsync(_company);
            await _companyRepository.SaveChangesAsync();

            // Get all the companyList
            var response = await _client.GetAsync("/api/companies?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_company.Id);
            json.SelectTokens("$.[*].companyName").Should().Contain(DefaultCompanyName);
            json.SelectTokens("$.[*].road").Should().Contain(DefaultRoad);
            json.SelectTokens("$.[*].street").Should().Contain(DefaultStreet);
            json.SelectTokens("$.[*].buildingName").Should().Contain(DefaultBuildingName);
            json.SelectTokens("$.[*].buildingNo").Should().Contain(DefaultBuildingNo);
            json.SelectTokens("$.[*].postCode").Should().Contain(DefaultPostCode);
            json.SelectTokens("$.[*].districtId").Should().Contain(DefaultDistrictID);
            json.SelectTokens("$.[*].cityId").Should().Contain(DefaultCityID);
            json.SelectTokens("$.[*].countryId").Should().Contain(DefaultCountryID);
            json.SelectTokens("$.[*].taxNo").Should().Contain(DefaultTaxNo);
            json.SelectTokens("$.[*].taxOffice").Should().Contain(DefaultTaxOffice);
            json.SelectTokens("$.[*].currency").Should().Contain(DefaultCurrency);
            json.SelectTokens("$.[*].dateFormat").Should().Contain(DefaultDateFormat);
            json.SelectTokens("$.[*].webSite").Should().Contain(DefaultWebSite);
            json.SelectTokens("$.[*].incomingMail").Should().Contain(DefaultIncomingMail);
            json.SelectTokens("$.[*].sendingMail").Should().Contain(DefaultSendingMail);
            json.SelectTokens("$.[*].workingYear").Should().Contain(DefaultWorkingYear);
            json.SelectTokens("$.[*].quantityDecimal").Should().Contain(DefaultQuantityDecimal);
            json.SelectTokens("$.[*].priceDecimal").Should().Contain(DefaultPriceDecimal);
            json.SelectTokens("$.[*].amountDecimal").Should().Contain(DefaultAmountDecimal);
        }

        [Fact]
        public async Task GetCompany()
        {
            // Initialize the database
            await _companyRepository.CreateOrUpdateAsync(_company);
            await _companyRepository.SaveChangesAsync();

            // Get the company
            var response = await _client.GetAsync($"/api/companies/{_company.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_company.Id);
            json.SelectTokens("$.companyName").Should().Contain(DefaultCompanyName);
            json.SelectTokens("$.road").Should().Contain(DefaultRoad);
            json.SelectTokens("$.street").Should().Contain(DefaultStreet);
            json.SelectTokens("$.buildingName").Should().Contain(DefaultBuildingName);
            json.SelectTokens("$.buildingNo").Should().Contain(DefaultBuildingNo);
            json.SelectTokens("$.postCode").Should().Contain(DefaultPostCode);
            json.SelectTokens("$.districtId").Should().Contain(DefaultDistrictID);
            json.SelectTokens("$.cityId").Should().Contain(DefaultCityID);
            json.SelectTokens("$.countryId").Should().Contain(DefaultCountryID);
            json.SelectTokens("$.taxNo").Should().Contain(DefaultTaxNo);
            json.SelectTokens("$.taxOffice").Should().Contain(DefaultTaxOffice);
            json.SelectTokens("$.currency").Should().Contain(DefaultCurrency);
            json.SelectTokens("$.dateFormat").Should().Contain(DefaultDateFormat);
            json.SelectTokens("$.webSite").Should().Contain(DefaultWebSite);
            json.SelectTokens("$.incomingMail").Should().Contain(DefaultIncomingMail);
            json.SelectTokens("$.sendingMail").Should().Contain(DefaultSendingMail);
            json.SelectTokens("$.workingYear").Should().Contain(DefaultWorkingYear);
            json.SelectTokens("$.quantityDecimal").Should().Contain(DefaultQuantityDecimal);
            json.SelectTokens("$.priceDecimal").Should().Contain(DefaultPriceDecimal);
            json.SelectTokens("$.amountDecimal").Should().Contain(DefaultAmountDecimal);
        }

        [Fact]
        public async Task GetNonExistingCompany()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/companies/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCompany()
        {
            // Initialize the database
            await _companyRepository.CreateOrUpdateAsync(_company);
            await _companyRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _companyRepository.CountAsync();

            // Update the company
            var updatedCompany = await _companyRepository.QueryHelper().GetOneAsync(it => it.Id == _company.Id);
            // Disconnect from session so that the updates on updatedCompany are not directly saved in db
            //TODO detach
            updatedCompany.CompanyName = UpdatedCompanyName;
            updatedCompany.Road = UpdatedRoad;
            updatedCompany.Street = UpdatedStreet;
            updatedCompany.BuildingName = UpdatedBuildingName;
            updatedCompany.BuildingNo = UpdatedBuildingNo;
            updatedCompany.PostCode = UpdatedPostCode;
            updatedCompany.DistrictID = UpdatedDistrictID;
            updatedCompany.CityID = UpdatedCityID;
            updatedCompany.CountryID = UpdatedCountryID;
            updatedCompany.TaxNo = UpdatedTaxNo;
            updatedCompany.TaxOffice = UpdatedTaxOffice;
            updatedCompany.Currency = UpdatedCurrency;
            updatedCompany.DateFormat = UpdatedDateFormat;
            updatedCompany.WebSite = UpdatedWebSite;
            updatedCompany.IncomingMail = UpdatedIncomingMail;
            updatedCompany.SendingMail = UpdatedSendingMail;
            updatedCompany.WorkingYear = UpdatedWorkingYear;
            updatedCompany.QuantityDecimal = UpdatedQuantityDecimal;
            updatedCompany.PriceDecimal = UpdatedPriceDecimal;
            updatedCompany.AmountDecimal = UpdatedAmountDecimal;

            CompanyDto updatedCompanyDto = _mapper.Map<CompanyDto>(updatedCompany);
            var response = await _client.PutAsync($"/api/companies/{_company.Id}", TestUtil.ToJsonContent(updatedCompanyDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the Company in the database
            var companyList = await _companyRepository.GetAllAsync();
            companyList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCompany = companyList.Last();
            testCompany.CompanyName.Should().Be(UpdatedCompanyName);
            testCompany.Road.Should().Be(UpdatedRoad);
            testCompany.Street.Should().Be(UpdatedStreet);
            testCompany.BuildingName.Should().Be(UpdatedBuildingName);
            testCompany.BuildingNo.Should().Be(UpdatedBuildingNo);
            testCompany.PostCode.Should().Be(UpdatedPostCode);
            testCompany.DistrictID.Should().Be(UpdatedDistrictID);
            testCompany.CityID.Should().Be(UpdatedCityID);
            testCompany.CountryID.Should().Be(UpdatedCountryID);
            testCompany.TaxNo.Should().Be(UpdatedTaxNo);
            testCompany.TaxOffice.Should().Be(UpdatedTaxOffice);
            testCompany.Currency.Should().Be(UpdatedCurrency);
            testCompany.DateFormat.Should().Be(UpdatedDateFormat);
            testCompany.WebSite.Should().Be(UpdatedWebSite);
            testCompany.IncomingMail.Should().Be(UpdatedIncomingMail);
            testCompany.SendingMail.Should().Be(UpdatedSendingMail);
            testCompany.WorkingYear.Should().Be(UpdatedWorkingYear);
            testCompany.QuantityDecimal.Should().Be(UpdatedQuantityDecimal);
            testCompany.PriceDecimal.Should().Be(UpdatedPriceDecimal);
            testCompany.AmountDecimal.Should().Be(UpdatedAmountDecimal);
        }

        [Fact]
        public async Task UpdateNonExistingCompany()
        {
            var databaseSizeBeforeUpdate = await _companyRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CompanyDto _companyDto = _mapper.Map<CompanyDto>(_company);
            var response = await _client.PutAsync("/api/companies/1", TestUtil.ToJsonContent(_companyDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the Company in the database
            var companyList = await _companyRepository.GetAllAsync();
            companyList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCompany()
        {
            // Initialize the database
            await _companyRepository.CreateOrUpdateAsync(_company);
            await _companyRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _companyRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/companies/{_company.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var companyList = await _companyRepository.GetAllAsync();
            companyList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(Company));
            var company1 = new Company
            {
                Id = 1L
            };
            var company2 = new Company
            {
                Id = company1.Id
            };
            company1.Should().Be(company2);
            company2.Id = 2L;
            company1.Should().NotBe(company2);
            company1.Id = 0;
            company1.Should().NotBe(company2);
        }
    }
}
