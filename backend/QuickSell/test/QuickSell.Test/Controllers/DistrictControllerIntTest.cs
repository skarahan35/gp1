
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
    public class DistrictsControllerIntTest
    {
        public DistrictsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _districtRepository = _factory.GetRequiredService<IDistrictRepository>();

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
        private readonly IDistrictRepository _districtRepository;

        private District _district;

        private readonly IMapper _mapper;

        private District CreateEntity()
        {
            return new District
            {
                Code = DefaultCode,
                Name = DefaultName,
            };
        }

        private void InitTest()
        {
            _district = CreateEntity();
        }

        [Fact]
        public async Task CreateDistrict()
        {
            var databaseSizeBeforeCreate = await _districtRepository.CountAsync();

            // Create the District
            DistrictDto _districtDto = _mapper.Map<DistrictDto>(_district);
            var response = await _client.PostAsync("/api/districts", TestUtil.ToJsonContent(_districtDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the District in the database
            var districtList = await _districtRepository.GetAllAsync();
            districtList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testDistrict = districtList.Last();
            testDistrict.Code.Should().Be(DefaultCode);
            testDistrict.Name.Should().Be(DefaultName);
        }

        [Fact]
        public async Task CreateDistrictWithExistingId()
        {
            var databaseSizeBeforeCreate = await _districtRepository.CountAsync();
            // Create the District with an existing ID
            _district.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            DistrictDto _districtDto = _mapper.Map<DistrictDto>(_district);
            var response = await _client.PostAsync("/api/districts", TestUtil.ToJsonContent(_districtDto));

            // Validate the District in the database
            var districtList = await _districtRepository.GetAllAsync();
            districtList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllDistricts()
        {
            // Initialize the database
            await _districtRepository.CreateOrUpdateAsync(_district);
            await _districtRepository.SaveChangesAsync();

            // Get all the districtList
            var response = await _client.GetAsync("/api/districts?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_district.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetDistrict()
        {
            // Initialize the database
            await _districtRepository.CreateOrUpdateAsync(_district);
            await _districtRepository.SaveChangesAsync();

            // Get the district
            var response = await _client.GetAsync($"/api/districts/{_district.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_district.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetNonExistingDistrict()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/districts/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateDistrict()
        {
            // Initialize the database
            await _districtRepository.CreateOrUpdateAsync(_district);
            await _districtRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _districtRepository.CountAsync();

            // Update the district
            var updatedDistrict = await _districtRepository.QueryHelper().GetOneAsync(it => it.Id == _district.Id);
            // Disconnect from session so that the updates on updatedDistrict are not directly saved in db
            //TODO detach
            updatedDistrict.Code = UpdatedCode;
            updatedDistrict.Name = UpdatedName;

            DistrictDto updatedDistrictDto = _mapper.Map<DistrictDto>(updatedDistrict);
            var response = await _client.PutAsync($"/api/districts/{_district.Id}", TestUtil.ToJsonContent(updatedDistrictDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the District in the database
            var districtList = await _districtRepository.GetAllAsync();
            districtList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testDistrict = districtList.Last();
            testDistrict.Code.Should().Be(UpdatedCode);
            testDistrict.Name.Should().Be(UpdatedName);
        }

        [Fact]
        public async Task UpdateNonExistingDistrict()
        {
            var databaseSizeBeforeUpdate = await _districtRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            DistrictDto _districtDto = _mapper.Map<DistrictDto>(_district);
            var response = await _client.PutAsync("/api/districts/1", TestUtil.ToJsonContent(_districtDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the District in the database
            var districtList = await _districtRepository.GetAllAsync();
            districtList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteDistrict()
        {
            // Initialize the database
            await _districtRepository.CreateOrUpdateAsync(_district);
            await _districtRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _districtRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/districts/{_district.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var districtList = await _districtRepository.GetAllAsync();
            districtList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(District));
            var district1 = new District
            {
                Id = 1L
            };
            var district2 = new District
            {
                Id = district1.Id
            };
            district1.Should().Be(district2);
            district2.Id = 2L;
            district1.Should().NotBe(district2);
            district1.Id = 0;
            district1.Should().NotBe(district2);
        }
    }
}
