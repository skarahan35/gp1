
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
    public class CountriesControllerIntTest
    {
        public CountriesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _countryRepository = _factory.GetRequiredService<ICountryRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private const string DefaultCode = "AAAAAAAAAA";
        private const string UpdatedCode = "BBBBBBBBBB";

        private const string DefaultName = "AAAAAAAAAA";
        private const string UpdatedName = "BBBBBBBBBB";

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly ICountryRepository _countryRepository;

        private Country _country;

        private readonly IMapper _mapper;

        private Country CreateEntity()
        {
            return new Country
            {
                Code = DefaultCode,
                Name = DefaultName,
            };
        }

        private void InitTest()
        {
            _country = CreateEntity();
        }

        [Fact]
        public async Task CreateCountry()
        {
            var databaseSizeBeforeCreate = await _countryRepository.CountAsync();

            // Create the Country
            CountryDto _countryDto = _mapper.Map<CountryDto>(_country);
            var response = await _client.PostAsync("/api/countries", TestUtil.ToJsonContent(_countryDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the Country in the database
            var countryList = await _countryRepository.GetAllAsync();
            countryList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCountry = countryList.Last();
            testCountry.Code.Should().Be(DefaultCode);
            testCountry.Name.Should().Be(DefaultName);
        }

        [Fact]
        public async Task CreateCountryWithExistingId()
        {
            var databaseSizeBeforeCreate = await _countryRepository.CountAsync();
            // Create the Country with an existing ID
            _country.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CountryDto _countryDto = _mapper.Map<CountryDto>(_country);
            var response = await _client.PostAsync("/api/countries", TestUtil.ToJsonContent(_countryDto));

            // Validate the Country in the database
            var countryList = await _countryRepository.GetAllAsync();
            countryList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCountries()
        {
            // Initialize the database
            await _countryRepository.CreateOrUpdateAsync(_country);
            await _countryRepository.SaveChangesAsync();

            // Get all the countryList
            var response = await _client.GetAsync("/api/countries?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_country.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetCountry()
        {
            // Initialize the database
            await _countryRepository.CreateOrUpdateAsync(_country);
            await _countryRepository.SaveChangesAsync();

            // Get the country
            var response = await _client.GetAsync($"/api/countries/{_country.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_country.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetNonExistingCountry()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/countries/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCountry()
        {
            // Initialize the database
            await _countryRepository.CreateOrUpdateAsync(_country);
            await _countryRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _countryRepository.CountAsync();

            // Update the country
            var updatedCountry = await _countryRepository.QueryHelper().GetOneAsync(it => it.Id == _country.Id);
            // Disconnect from session so that the updates on updatedCountry are not directly saved in db
            //TODO detach
            updatedCountry.Code = UpdatedCode;
            updatedCountry.Name = UpdatedName;

            CountryDto updatedCountryDto = _mapper.Map<CountryDto>(updatedCountry);
            var response = await _client.PutAsync($"/api/countries/{_country.Id}", TestUtil.ToJsonContent(updatedCountryDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the Country in the database
            var countryList = await _countryRepository.GetAllAsync();
            countryList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCountry = countryList.Last();
            testCountry.Code.Should().Be(UpdatedCode);
            testCountry.Name.Should().Be(UpdatedName);
        }

        [Fact]
        public async Task UpdateNonExistingCountry()
        {
            var databaseSizeBeforeUpdate = await _countryRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CountryDto _countryDto = _mapper.Map<CountryDto>(_country);
            var response = await _client.PutAsync("/api/countries/1", TestUtil.ToJsonContent(_countryDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the Country in the database
            var countryList = await _countryRepository.GetAllAsync();
            countryList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCountry()
        {
            // Initialize the database
            await _countryRepository.CreateOrUpdateAsync(_country);
            await _countryRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _countryRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/countries/{_country.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var countryList = await _countryRepository.GetAllAsync();
            countryList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(Country));
            var country1 = new Country
            {
                Id = 1L
            };
            var country2 = new Country
            {
                Id = country1.Id
            };
            country1.Should().Be(country2);
            country2.Id = 2L;
            country1.Should().NotBe(country2);
            country1.Id = 0;
            country1.Should().NotBe(country2);
        }
    }
}
