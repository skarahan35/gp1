
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
    public class CustomerAddressesControllerIntTest
    {
        public CustomerAddressesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _customerAddressRepository = _factory.GetRequiredService<ICustomerAddressRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly UNKNOWN_TYPE DefaultCustomerCardID = ;
        private static readonly UNKNOWN_TYPE UpdatedCustomerCardID = ;

        private const string DefaultAddressCode = "AAAAAAAAAA";
        private const string UpdatedAddressCode = "BBBBBBBBBB";

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

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly ICustomerAddressRepository _customerAddressRepository;

        private CustomerAddress _customerAddress;

        private readonly IMapper _mapper;

        private CustomerAddress CreateEntity()
        {
            return new CustomerAddress
            {
                CustomerCardID = DefaultCustomerCardID,
                AddressCode = DefaultAddressCode,
                Road = DefaultRoad,
                Street = DefaultStreet,
                BuildingName = DefaultBuildingName,
                BuildingNo = DefaultBuildingNo,
                PostCode = DefaultPostCode,
                DistrictID = DefaultDistrictID,
                CityID = DefaultCityID,
                CountryID = DefaultCountryID,
            };
        }

        private void InitTest()
        {
            _customerAddress = CreateEntity();
        }

        [Fact]
        public async Task CreateCustomerAddress()
        {
            var databaseSizeBeforeCreate = await _customerAddressRepository.CountAsync();

            // Create the CustomerAddress
            CustomerAddressDto _customerAddressDto = _mapper.Map<CustomerAddressDto>(_customerAddress);
            var response = await _client.PostAsync("/api/customer-addresses", TestUtil.ToJsonContent(_customerAddressDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the CustomerAddress in the database
            var customerAddressList = await _customerAddressRepository.GetAllAsync();
            customerAddressList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCustomerAddress = customerAddressList.Last();
            testCustomerAddress.CustomerCardID.Should().Be(DefaultCustomerCardID);
            testCustomerAddress.AddressCode.Should().Be(DefaultAddressCode);
            testCustomerAddress.Road.Should().Be(DefaultRoad);
            testCustomerAddress.Street.Should().Be(DefaultStreet);
            testCustomerAddress.BuildingName.Should().Be(DefaultBuildingName);
            testCustomerAddress.BuildingNo.Should().Be(DefaultBuildingNo);
            testCustomerAddress.PostCode.Should().Be(DefaultPostCode);
            testCustomerAddress.DistrictID.Should().Be(DefaultDistrictID);
            testCustomerAddress.CityID.Should().Be(DefaultCityID);
            testCustomerAddress.CountryID.Should().Be(DefaultCountryID);
        }

        [Fact]
        public async Task CreateCustomerAddressWithExistingId()
        {
            var databaseSizeBeforeCreate = await _customerAddressRepository.CountAsync();
            // Create the CustomerAddress with an existing ID
            _customerAddress.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CustomerAddressDto _customerAddressDto = _mapper.Map<CustomerAddressDto>(_customerAddress);
            var response = await _client.PostAsync("/api/customer-addresses", TestUtil.ToJsonContent(_customerAddressDto));

            // Validate the CustomerAddress in the database
            var customerAddressList = await _customerAddressRepository.GetAllAsync();
            customerAddressList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCustomerAddresses()
        {
            // Initialize the database
            await _customerAddressRepository.CreateOrUpdateAsync(_customerAddress);
            await _customerAddressRepository.SaveChangesAsync();

            // Get all the customerAddressList
            var response = await _client.GetAsync("/api/customer-addresses?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_customerAddress.Id);
            json.SelectTokens("$.[*].customerCardId").Should().Contain(DefaultCustomerCardID);
            json.SelectTokens("$.[*].addressCode").Should().Contain(DefaultAddressCode);
            json.SelectTokens("$.[*].road").Should().Contain(DefaultRoad);
            json.SelectTokens("$.[*].street").Should().Contain(DefaultStreet);
            json.SelectTokens("$.[*].buildingName").Should().Contain(DefaultBuildingName);
            json.SelectTokens("$.[*].buildingNo").Should().Contain(DefaultBuildingNo);
            json.SelectTokens("$.[*].postCode").Should().Contain(DefaultPostCode);
            json.SelectTokens("$.[*].districtId").Should().Contain(DefaultDistrictID);
            json.SelectTokens("$.[*].cityId").Should().Contain(DefaultCityID);
            json.SelectTokens("$.[*].countryId").Should().Contain(DefaultCountryID);
        }

        [Fact]
        public async Task GetCustomerAddress()
        {
            // Initialize the database
            await _customerAddressRepository.CreateOrUpdateAsync(_customerAddress);
            await _customerAddressRepository.SaveChangesAsync();

            // Get the customerAddress
            var response = await _client.GetAsync($"/api/customer-addresses/{_customerAddress.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_customerAddress.Id);
            json.SelectTokens("$.customerCardId").Should().Contain(DefaultCustomerCardID);
            json.SelectTokens("$.addressCode").Should().Contain(DefaultAddressCode);
            json.SelectTokens("$.road").Should().Contain(DefaultRoad);
            json.SelectTokens("$.street").Should().Contain(DefaultStreet);
            json.SelectTokens("$.buildingName").Should().Contain(DefaultBuildingName);
            json.SelectTokens("$.buildingNo").Should().Contain(DefaultBuildingNo);
            json.SelectTokens("$.postCode").Should().Contain(DefaultPostCode);
            json.SelectTokens("$.districtId").Should().Contain(DefaultDistrictID);
            json.SelectTokens("$.cityId").Should().Contain(DefaultCityID);
            json.SelectTokens("$.countryId").Should().Contain(DefaultCountryID);
        }

        [Fact]
        public async Task GetNonExistingCustomerAddress()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/customer-addresses/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCustomerAddress()
        {
            // Initialize the database
            await _customerAddressRepository.CreateOrUpdateAsync(_customerAddress);
            await _customerAddressRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _customerAddressRepository.CountAsync();

            // Update the customerAddress
            var updatedCustomerAddress = await _customerAddressRepository.QueryHelper().GetOneAsync(it => it.Id == _customerAddress.Id);
            // Disconnect from session so that the updates on updatedCustomerAddress are not directly saved in db
            //TODO detach
            updatedCustomerAddress.CustomerCardID = UpdatedCustomerCardID;
            updatedCustomerAddress.AddressCode = UpdatedAddressCode;
            updatedCustomerAddress.Road = UpdatedRoad;
            updatedCustomerAddress.Street = UpdatedStreet;
            updatedCustomerAddress.BuildingName = UpdatedBuildingName;
            updatedCustomerAddress.BuildingNo = UpdatedBuildingNo;
            updatedCustomerAddress.PostCode = UpdatedPostCode;
            updatedCustomerAddress.DistrictID = UpdatedDistrictID;
            updatedCustomerAddress.CityID = UpdatedCityID;
            updatedCustomerAddress.CountryID = UpdatedCountryID;

            CustomerAddressDto updatedCustomerAddressDto = _mapper.Map<CustomerAddressDto>(updatedCustomerAddress);
            var response = await _client.PutAsync($"/api/customer-addresses/{_customerAddress.Id}", TestUtil.ToJsonContent(updatedCustomerAddressDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the CustomerAddress in the database
            var customerAddressList = await _customerAddressRepository.GetAllAsync();
            customerAddressList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCustomerAddress = customerAddressList.Last();
            testCustomerAddress.CustomerCardID.Should().Be(UpdatedCustomerCardID);
            testCustomerAddress.AddressCode.Should().Be(UpdatedAddressCode);
            testCustomerAddress.Road.Should().Be(UpdatedRoad);
            testCustomerAddress.Street.Should().Be(UpdatedStreet);
            testCustomerAddress.BuildingName.Should().Be(UpdatedBuildingName);
            testCustomerAddress.BuildingNo.Should().Be(UpdatedBuildingNo);
            testCustomerAddress.PostCode.Should().Be(UpdatedPostCode);
            testCustomerAddress.DistrictID.Should().Be(UpdatedDistrictID);
            testCustomerAddress.CityID.Should().Be(UpdatedCityID);
            testCustomerAddress.CountryID.Should().Be(UpdatedCountryID);
        }

        [Fact]
        public async Task UpdateNonExistingCustomerAddress()
        {
            var databaseSizeBeforeUpdate = await _customerAddressRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CustomerAddressDto _customerAddressDto = _mapper.Map<CustomerAddressDto>(_customerAddress);
            var response = await _client.PutAsync("/api/customer-addresses/1", TestUtil.ToJsonContent(_customerAddressDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the CustomerAddress in the database
            var customerAddressList = await _customerAddressRepository.GetAllAsync();
            customerAddressList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCustomerAddress()
        {
            // Initialize the database
            await _customerAddressRepository.CreateOrUpdateAsync(_customerAddress);
            await _customerAddressRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _customerAddressRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/customer-addresses/{_customerAddress.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var customerAddressList = await _customerAddressRepository.GetAllAsync();
            customerAddressList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(CustomerAddress));
            var customerAddress1 = new CustomerAddress
            {
                Id = 1L
            };
            var customerAddress2 = new CustomerAddress
            {
                Id = customerAddress1.Id
            };
            customerAddress1.Should().Be(customerAddress2);
            customerAddress2.Id = 2L;
            customerAddress1.Should().NotBe(customerAddress2);
            customerAddress1.Id = 0;
            customerAddress1.Should().NotBe(customerAddress2);
        }
    }
}
