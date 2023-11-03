
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
    public class CustomerGroupsControllerIntTest
    {
        public CustomerGroupsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _customerGroupRepository = _factory.GetRequiredService<ICustomerGroupRepository>();

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
        private readonly ICustomerGroupRepository _customerGroupRepository;

        private CustomerGroup _customerGroup;

        private readonly IMapper _mapper;

        private CustomerGroup CreateEntity()
        {
            return new CustomerGroup
            {
                Code = DefaultCode,
                Name = DefaultName,
            };
        }

        private void InitTest()
        {
            _customerGroup = CreateEntity();
        }

        [Fact]
        public async Task CreateCustomerGroup()
        {
            var databaseSizeBeforeCreate = await _customerGroupRepository.CountAsync();

            // Create the CustomerGroup
            CustomerGroupDto _customerGroupDto = _mapper.Map<CustomerGroupDto>(_customerGroup);
            var response = await _client.PostAsync("/api/customer-groups", TestUtil.ToJsonContent(_customerGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the CustomerGroup in the database
            var customerGroupList = await _customerGroupRepository.GetAllAsync();
            customerGroupList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCustomerGroup = customerGroupList.Last();
            testCustomerGroup.Code.Should().Be(DefaultCode);
            testCustomerGroup.Name.Should().Be(DefaultName);
        }

        [Fact]
        public async Task CreateCustomerGroupWithExistingId()
        {
            var databaseSizeBeforeCreate = await _customerGroupRepository.CountAsync();
            // Create the CustomerGroup with an existing ID
            _customerGroup.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CustomerGroupDto _customerGroupDto = _mapper.Map<CustomerGroupDto>(_customerGroup);
            var response = await _client.PostAsync("/api/customer-groups", TestUtil.ToJsonContent(_customerGroupDto));

            // Validate the CustomerGroup in the database
            var customerGroupList = await _customerGroupRepository.GetAllAsync();
            customerGroupList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCustomerGroups()
        {
            // Initialize the database
            await _customerGroupRepository.CreateOrUpdateAsync(_customerGroup);
            await _customerGroupRepository.SaveChangesAsync();

            // Get all the customerGroupList
            var response = await _client.GetAsync("/api/customer-groups?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_customerGroup.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetCustomerGroup()
        {
            // Initialize the database
            await _customerGroupRepository.CreateOrUpdateAsync(_customerGroup);
            await _customerGroupRepository.SaveChangesAsync();

            // Get the customerGroup
            var response = await _client.GetAsync($"/api/customer-groups/{_customerGroup.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_customerGroup.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetNonExistingCustomerGroup()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/customer-groups/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCustomerGroup()
        {
            // Initialize the database
            await _customerGroupRepository.CreateOrUpdateAsync(_customerGroup);
            await _customerGroupRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _customerGroupRepository.CountAsync();

            // Update the customerGroup
            var updatedCustomerGroup = await _customerGroupRepository.QueryHelper().GetOneAsync(it => it.Id == _customerGroup.Id);
            // Disconnect from session so that the updates on updatedCustomerGroup are not directly saved in db
            //TODO detach
            updatedCustomerGroup.Code = UpdatedCode;
            updatedCustomerGroup.Name = UpdatedName;

            CustomerGroupDto updatedCustomerGroupDto = _mapper.Map<CustomerGroupDto>(updatedCustomerGroup);
            var response = await _client.PutAsync($"/api/customer-groups/{_customerGroup.Id}", TestUtil.ToJsonContent(updatedCustomerGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the CustomerGroup in the database
            var customerGroupList = await _customerGroupRepository.GetAllAsync();
            customerGroupList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCustomerGroup = customerGroupList.Last();
            testCustomerGroup.Code.Should().Be(UpdatedCode);
            testCustomerGroup.Name.Should().Be(UpdatedName);
        }

        [Fact]
        public async Task UpdateNonExistingCustomerGroup()
        {
            var databaseSizeBeforeUpdate = await _customerGroupRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CustomerGroupDto _customerGroupDto = _mapper.Map<CustomerGroupDto>(_customerGroup);
            var response = await _client.PutAsync("/api/customer-groups/1", TestUtil.ToJsonContent(_customerGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the CustomerGroup in the database
            var customerGroupList = await _customerGroupRepository.GetAllAsync();
            customerGroupList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCustomerGroup()
        {
            // Initialize the database
            await _customerGroupRepository.CreateOrUpdateAsync(_customerGroup);
            await _customerGroupRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _customerGroupRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/customer-groups/{_customerGroup.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var customerGroupList = await _customerGroupRepository.GetAllAsync();
            customerGroupList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(CustomerGroup));
            var customerGroup1 = new CustomerGroup
            {
                Id = 1L
            };
            var customerGroup2 = new CustomerGroup
            {
                Id = customerGroup1.Id
            };
            customerGroup1.Should().Be(customerGroup2);
            customerGroup2.Id = 2L;
            customerGroup1.Should().NotBe(customerGroup2);
            customerGroup1.Id = 0;
            customerGroup1.Should().NotBe(customerGroup2);
        }
    }
}
