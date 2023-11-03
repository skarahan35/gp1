
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
    public class CustomerCardsControllerIntTest
    {
        public CustomerCardsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _customerCardRepository = _factory.GetRequiredService<ICustomerCardRepository>();

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

        private static readonly UNKNOWN_TYPE DefaultCustomerTypeID = ;
        private static readonly UNKNOWN_TYPE UpdatedCustomerTypeID = ;

        private static readonly UNKNOWN_TYPE DefaultAddressID = ;
        private static readonly UNKNOWN_TYPE UpdatedAddressID = ;

        private static readonly UNKNOWN_TYPE DefaultCustomerGroupID = ;
        private static readonly UNKNOWN_TYPE UpdatedCustomerGroupID = ;

        private const string DefaultTaxOffice = "AAAAAAAAAA";
        private const string UpdatedTaxOffice = "BBBBBBBBBB";

        private static readonly int? DefaultTaxNo = 1;
        private static readonly int? UpdatedTaxNo = 2;

        private const string DefaultTCNumber = "AAAAAAAAAA";
        private const string UpdatedTCNumber = "BBBBBBBBBB";

        private const string DefaultAuthorizedPerson = "AAAAAAAAAA";
        private const string UpdatedAuthorizedPerson = "BBBBBBBBBB";

        private const string DefaultEMail = "AAAAAAAAAA";
        private const string UpdatedEMail = "BBBBBBBBBB";

        private static readonly int? DefaultRiskLimit = 1;
        private static readonly int? UpdatedRiskLimit = 2;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly ICustomerCardRepository _customerCardRepository;

        private CustomerCard _customerCard;

        private readonly IMapper _mapper;

        private CustomerCard CreateEntity()
        {
            return new CustomerCard
            {
                Code = DefaultCode,
                Name = DefaultName,
                CustomerTypeID = DefaultCustomerTypeID,
                AddressID = DefaultAddressID,
                CustomerGroupID = DefaultCustomerGroupID,
                TaxOffice = DefaultTaxOffice,
                TaxNo = DefaultTaxNo,
                TCNumber = DefaultTCNumber,
                AuthorizedPerson = DefaultAuthorizedPerson,
                EMail = DefaultEMail,
                RiskLimit = DefaultRiskLimit,
            };
        }

        private void InitTest()
        {
            _customerCard = CreateEntity();
        }

        [Fact]
        public async Task CreateCustomerCard()
        {
            var databaseSizeBeforeCreate = await _customerCardRepository.CountAsync();

            // Create the CustomerCard
            CustomerCardDto _customerCardDto = _mapper.Map<CustomerCardDto>(_customerCard);
            var response = await _client.PostAsync("/api/customer-cards", TestUtil.ToJsonContent(_customerCardDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the CustomerCard in the database
            var customerCardList = await _customerCardRepository.GetAllAsync();
            customerCardList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCustomerCard = customerCardList.Last();
            testCustomerCard.Code.Should().Be(DefaultCode);
            testCustomerCard.Name.Should().Be(DefaultName);
            testCustomerCard.CustomerTypeID.Should().Be(DefaultCustomerTypeID);
            testCustomerCard.AddressID.Should().Be(DefaultAddressID);
            testCustomerCard.CustomerGroupID.Should().Be(DefaultCustomerGroupID);
            testCustomerCard.TaxOffice.Should().Be(DefaultTaxOffice);
            testCustomerCard.TaxNo.Should().Be(DefaultTaxNo);
            testCustomerCard.TCNumber.Should().Be(DefaultTCNumber);
            testCustomerCard.AuthorizedPerson.Should().Be(DefaultAuthorizedPerson);
            testCustomerCard.EMail.Should().Be(DefaultEMail);
            testCustomerCard.RiskLimit.Should().Be(DefaultRiskLimit);
        }

        [Fact]
        public async Task CreateCustomerCardWithExistingId()
        {
            var databaseSizeBeforeCreate = await _customerCardRepository.CountAsync();
            // Create the CustomerCard with an existing ID
            _customerCard.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CustomerCardDto _customerCardDto = _mapper.Map<CustomerCardDto>(_customerCard);
            var response = await _client.PostAsync("/api/customer-cards", TestUtil.ToJsonContent(_customerCardDto));

            // Validate the CustomerCard in the database
            var customerCardList = await _customerCardRepository.GetAllAsync();
            customerCardList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCustomerCards()
        {
            // Initialize the database
            await _customerCardRepository.CreateOrUpdateAsync(_customerCard);
            await _customerCardRepository.SaveChangesAsync();

            // Get all the customerCardList
            var response = await _client.GetAsync("/api/customer-cards?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_customerCard.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
            json.SelectTokens("$.[*].customerTypeId").Should().Contain(DefaultCustomerTypeID);
            json.SelectTokens("$.[*].addressId").Should().Contain(DefaultAddressID);
            json.SelectTokens("$.[*].customerGroupId").Should().Contain(DefaultCustomerGroupID);
            json.SelectTokens("$.[*].taxOffice").Should().Contain(DefaultTaxOffice);
            json.SelectTokens("$.[*].taxNo").Should().Contain(DefaultTaxNo);
            json.SelectTokens("$.[*].tCNumber").Should().Contain(DefaultTCNumber);
            json.SelectTokens("$.[*].authorizedPerson").Should().Contain(DefaultAuthorizedPerson);
            json.SelectTokens("$.[*].eMail").Should().Contain(DefaultEMail);
            json.SelectTokens("$.[*].riskLimit").Should().Contain(DefaultRiskLimit);
        }

        [Fact]
        public async Task GetCustomerCard()
        {
            // Initialize the database
            await _customerCardRepository.CreateOrUpdateAsync(_customerCard);
            await _customerCardRepository.SaveChangesAsync();

            // Get the customerCard
            var response = await _client.GetAsync($"/api/customer-cards/{_customerCard.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_customerCard.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
            json.SelectTokens("$.customerTypeId").Should().Contain(DefaultCustomerTypeID);
            json.SelectTokens("$.addressId").Should().Contain(DefaultAddressID);
            json.SelectTokens("$.customerGroupId").Should().Contain(DefaultCustomerGroupID);
            json.SelectTokens("$.taxOffice").Should().Contain(DefaultTaxOffice);
            json.SelectTokens("$.taxNo").Should().Contain(DefaultTaxNo);
            json.SelectTokens("$.tCNumber").Should().Contain(DefaultTCNumber);
            json.SelectTokens("$.authorizedPerson").Should().Contain(DefaultAuthorizedPerson);
            json.SelectTokens("$.eMail").Should().Contain(DefaultEMail);
            json.SelectTokens("$.riskLimit").Should().Contain(DefaultRiskLimit);
        }

        [Fact]
        public async Task GetNonExistingCustomerCard()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/customer-cards/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCustomerCard()
        {
            // Initialize the database
            await _customerCardRepository.CreateOrUpdateAsync(_customerCard);
            await _customerCardRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _customerCardRepository.CountAsync();

            // Update the customerCard
            var updatedCustomerCard = await _customerCardRepository.QueryHelper().GetOneAsync(it => it.Id == _customerCard.Id);
            // Disconnect from session so that the updates on updatedCustomerCard are not directly saved in db
            //TODO detach
            updatedCustomerCard.Code = UpdatedCode;
            updatedCustomerCard.Name = UpdatedName;
            updatedCustomerCard.CustomerTypeID = UpdatedCustomerTypeID;
            updatedCustomerCard.AddressID = UpdatedAddressID;
            updatedCustomerCard.CustomerGroupID = UpdatedCustomerGroupID;
            updatedCustomerCard.TaxOffice = UpdatedTaxOffice;
            updatedCustomerCard.TaxNo = UpdatedTaxNo;
            updatedCustomerCard.TCNumber = UpdatedTCNumber;
            updatedCustomerCard.AuthorizedPerson = UpdatedAuthorizedPerson;
            updatedCustomerCard.EMail = UpdatedEMail;
            updatedCustomerCard.RiskLimit = UpdatedRiskLimit;

            CustomerCardDto updatedCustomerCardDto = _mapper.Map<CustomerCardDto>(updatedCustomerCard);
            var response = await _client.PutAsync($"/api/customer-cards/{_customerCard.Id}", TestUtil.ToJsonContent(updatedCustomerCardDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the CustomerCard in the database
            var customerCardList = await _customerCardRepository.GetAllAsync();
            customerCardList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCustomerCard = customerCardList.Last();
            testCustomerCard.Code.Should().Be(UpdatedCode);
            testCustomerCard.Name.Should().Be(UpdatedName);
            testCustomerCard.CustomerTypeID.Should().Be(UpdatedCustomerTypeID);
            testCustomerCard.AddressID.Should().Be(UpdatedAddressID);
            testCustomerCard.CustomerGroupID.Should().Be(UpdatedCustomerGroupID);
            testCustomerCard.TaxOffice.Should().Be(UpdatedTaxOffice);
            testCustomerCard.TaxNo.Should().Be(UpdatedTaxNo);
            testCustomerCard.TCNumber.Should().Be(UpdatedTCNumber);
            testCustomerCard.AuthorizedPerson.Should().Be(UpdatedAuthorizedPerson);
            testCustomerCard.EMail.Should().Be(UpdatedEMail);
            testCustomerCard.RiskLimit.Should().Be(UpdatedRiskLimit);
        }

        [Fact]
        public async Task UpdateNonExistingCustomerCard()
        {
            var databaseSizeBeforeUpdate = await _customerCardRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CustomerCardDto _customerCardDto = _mapper.Map<CustomerCardDto>(_customerCard);
            var response = await _client.PutAsync("/api/customer-cards/1", TestUtil.ToJsonContent(_customerCardDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the CustomerCard in the database
            var customerCardList = await _customerCardRepository.GetAllAsync();
            customerCardList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCustomerCard()
        {
            // Initialize the database
            await _customerCardRepository.CreateOrUpdateAsync(_customerCard);
            await _customerCardRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _customerCardRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/customer-cards/{_customerCard.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var customerCardList = await _customerCardRepository.GetAllAsync();
            customerCardList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(CustomerCard));
            var customerCard1 = new CustomerCard
            {
                Id = 1L
            };
            var customerCard2 = new CustomerCard
            {
                Id = customerCard1.Id
            };
            customerCard1.Should().Be(customerCard2);
            customerCard2.Id = 2L;
            customerCard1.Should().NotBe(customerCard2);
            customerCard1.Id = 0;
            customerCard1.Should().NotBe(customerCard2);
        }
    }
}
