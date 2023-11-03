
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
    public class CustomerTypesControllerIntTest
    {
        public CustomerTypesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _customerTypeRepository = _factory.GetRequiredService<ICustomerTypeRepository>();

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
        private readonly ICustomerTypeRepository _customerTypeRepository;

        private CustomerType _customerType;

        private readonly IMapper _mapper;

        private CustomerType CreateEntity()
        {
            return new CustomerType
            {
                Code = DefaultCode,
                Name = DefaultName,
            };
        }

        private void InitTest()
        {
            _customerType = CreateEntity();
        }

        [Fact]
        public async Task CreateCustomerType()
        {
            var databaseSizeBeforeCreate = await _customerTypeRepository.CountAsync();

            // Create the CustomerType
            CustomerTypeDto _customerTypeDto = _mapper.Map<CustomerTypeDto>(_customerType);
            var response = await _client.PostAsync("/api/customer-types", TestUtil.ToJsonContent(_customerTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the CustomerType in the database
            var customerTypeList = await _customerTypeRepository.GetAllAsync();
            customerTypeList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCustomerType = customerTypeList.Last();
            testCustomerType.Code.Should().Be(DefaultCode);
            testCustomerType.Name.Should().Be(DefaultName);
        }

        [Fact]
        public async Task CreateCustomerTypeWithExistingId()
        {
            var databaseSizeBeforeCreate = await _customerTypeRepository.CountAsync();
            // Create the CustomerType with an existing ID
            _customerType.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CustomerTypeDto _customerTypeDto = _mapper.Map<CustomerTypeDto>(_customerType);
            var response = await _client.PostAsync("/api/customer-types", TestUtil.ToJsonContent(_customerTypeDto));

            // Validate the CustomerType in the database
            var customerTypeList = await _customerTypeRepository.GetAllAsync();
            customerTypeList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCustomerTypes()
        {
            // Initialize the database
            await _customerTypeRepository.CreateOrUpdateAsync(_customerType);
            await _customerTypeRepository.SaveChangesAsync();

            // Get all the customerTypeList
            var response = await _client.GetAsync("/api/customer-types?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_customerType.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetCustomerType()
        {
            // Initialize the database
            await _customerTypeRepository.CreateOrUpdateAsync(_customerType);
            await _customerTypeRepository.SaveChangesAsync();

            // Get the customerType
            var response = await _client.GetAsync($"/api/customer-types/{_customerType.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_customerType.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetNonExistingCustomerType()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/customer-types/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCustomerType()
        {
            // Initialize the database
            await _customerTypeRepository.CreateOrUpdateAsync(_customerType);
            await _customerTypeRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _customerTypeRepository.CountAsync();

            // Update the customerType
            var updatedCustomerType = await _customerTypeRepository.QueryHelper().GetOneAsync(it => it.Id == _customerType.Id);
            // Disconnect from session so that the updates on updatedCustomerType are not directly saved in db
            //TODO detach
            updatedCustomerType.Code = UpdatedCode;
            updatedCustomerType.Name = UpdatedName;

            CustomerTypeDto updatedCustomerTypeDto = _mapper.Map<CustomerTypeDto>(updatedCustomerType);
            var response = await _client.PutAsync($"/api/customer-types/{_customerType.Id}", TestUtil.ToJsonContent(updatedCustomerTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the CustomerType in the database
            var customerTypeList = await _customerTypeRepository.GetAllAsync();
            customerTypeList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCustomerType = customerTypeList.Last();
            testCustomerType.Code.Should().Be(UpdatedCode);
            testCustomerType.Name.Should().Be(UpdatedName);
        }

        [Fact]
        public async Task UpdateNonExistingCustomerType()
        {
            var databaseSizeBeforeUpdate = await _customerTypeRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CustomerTypeDto _customerTypeDto = _mapper.Map<CustomerTypeDto>(_customerType);
            var response = await _client.PutAsync("/api/customer-types/1", TestUtil.ToJsonContent(_customerTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the CustomerType in the database
            var customerTypeList = await _customerTypeRepository.GetAllAsync();
            customerTypeList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCustomerType()
        {
            // Initialize the database
            await _customerTypeRepository.CreateOrUpdateAsync(_customerType);
            await _customerTypeRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _customerTypeRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/customer-types/{_customerType.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var customerTypeList = await _customerTypeRepository.GetAllAsync();
            customerTypeList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(CustomerType));
            var customerType1 = new CustomerType
            {
                Id = 1L
            };
            var customerType2 = new CustomerType
            {
                Id = customerType1.Id
            };
            customerType1.Should().Be(customerType2);
            customerType2.Id = 2L;
            customerType1.Should().NotBe(customerType2);
            customerType1.Id = 0;
            customerType1.Should().NotBe(customerType2);
        }
    }
}
