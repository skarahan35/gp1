
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
    public class MovementHeadersControllerIntTest
    {
        public MovementHeadersControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _movementHeaderRepository = _factory.GetRequiredService<IMovementHeaderRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private const string DefaultTypeCode = "AAAAAAAAAA";
        private const string UpdatedTypeCode = "BBBBBBBBBB";

        private static readonly int? DefaultReceiptNo = 1;
        private static readonly int? UpdatedReceiptNo = 2;

        private static readonly UNKNOWN_TYPE DefaultCustomerCardID = ;
        private static readonly UNKNOWN_TYPE UpdatedCustomerCardID = ;

        private static readonly int? DefaultFirstAmount = 1;
        private static readonly int? UpdatedFirstAmount = 2;

        private static readonly int? DefaultDiscountAmount = 1;
        private static readonly int? UpdatedDiscountAmount = 2;

        private static readonly int? DefaultVATAmount = 1;
        private static readonly int? UpdatedVATAmount = 2;

        private static readonly int? DefaultTotalAmount = 1;
        private static readonly int? UpdatedTotalAmount = 2;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IMovementHeaderRepository _movementHeaderRepository;

        private MovementHeader _movementHeader;

        private readonly IMapper _mapper;

        private MovementHeader CreateEntity()
        {
            return new MovementHeader
            {
                TypeCode = DefaultTypeCode,
                ReceiptNo = DefaultReceiptNo,
                CustomerCardID = DefaultCustomerCardID,
                FirstAmount = DefaultFirstAmount,
                DiscountAmount = DefaultDiscountAmount,
                VATAmount = DefaultVATAmount,
                TotalAmount = DefaultTotalAmount,
            };
        }

        private void InitTest()
        {
            _movementHeader = CreateEntity();
        }

        [Fact]
        public async Task CreateMovementHeader()
        {
            var databaseSizeBeforeCreate = await _movementHeaderRepository.CountAsync();

            // Create the MovementHeader
            MovementHeaderDto _movementHeaderDto = _mapper.Map<MovementHeaderDto>(_movementHeader);
            var response = await _client.PostAsync("/api/movement-headers", TestUtil.ToJsonContent(_movementHeaderDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the MovementHeader in the database
            var movementHeaderList = await _movementHeaderRepository.GetAllAsync();
            movementHeaderList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testMovementHeader = movementHeaderList.Last();
            testMovementHeader.TypeCode.Should().Be(DefaultTypeCode);
            testMovementHeader.ReceiptNo.Should().Be(DefaultReceiptNo);
            testMovementHeader.CustomerCardID.Should().Be(DefaultCustomerCardID);
            testMovementHeader.FirstAmount.Should().Be(DefaultFirstAmount);
            testMovementHeader.DiscountAmount.Should().Be(DefaultDiscountAmount);
            testMovementHeader.VATAmount.Should().Be(DefaultVATAmount);
            testMovementHeader.TotalAmount.Should().Be(DefaultTotalAmount);
        }

        [Fact]
        public async Task CreateMovementHeaderWithExistingId()
        {
            var databaseSizeBeforeCreate = await _movementHeaderRepository.CountAsync();
            // Create the MovementHeader with an existing ID
            _movementHeader.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            MovementHeaderDto _movementHeaderDto = _mapper.Map<MovementHeaderDto>(_movementHeader);
            var response = await _client.PostAsync("/api/movement-headers", TestUtil.ToJsonContent(_movementHeaderDto));

            // Validate the MovementHeader in the database
            var movementHeaderList = await _movementHeaderRepository.GetAllAsync();
            movementHeaderList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllMovementHeaders()
        {
            // Initialize the database
            await _movementHeaderRepository.CreateOrUpdateAsync(_movementHeader);
            await _movementHeaderRepository.SaveChangesAsync();

            // Get all the movementHeaderList
            var response = await _client.GetAsync("/api/movement-headers?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_movementHeader.Id);
            json.SelectTokens("$.[*].typeCode").Should().Contain(DefaultTypeCode);
            json.SelectTokens("$.[*].receiptNo").Should().Contain(DefaultReceiptNo);
            json.SelectTokens("$.[*].customerCardId").Should().Contain(DefaultCustomerCardID);
            json.SelectTokens("$.[*].firstAmount").Should().Contain(DefaultFirstAmount);
            json.SelectTokens("$.[*].discountAmount").Should().Contain(DefaultDiscountAmount);
            json.SelectTokens("$.[*].vAtAmount").Should().Contain(DefaultVATAmount);
            json.SelectTokens("$.[*].totalAmount").Should().Contain(DefaultTotalAmount);
        }

        [Fact]
        public async Task GetMovementHeader()
        {
            // Initialize the database
            await _movementHeaderRepository.CreateOrUpdateAsync(_movementHeader);
            await _movementHeaderRepository.SaveChangesAsync();

            // Get the movementHeader
            var response = await _client.GetAsync($"/api/movement-headers/{_movementHeader.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_movementHeader.Id);
            json.SelectTokens("$.typeCode").Should().Contain(DefaultTypeCode);
            json.SelectTokens("$.receiptNo").Should().Contain(DefaultReceiptNo);
            json.SelectTokens("$.customerCardId").Should().Contain(DefaultCustomerCardID);
            json.SelectTokens("$.firstAmount").Should().Contain(DefaultFirstAmount);
            json.SelectTokens("$.discountAmount").Should().Contain(DefaultDiscountAmount);
            json.SelectTokens("$.vAtAmount").Should().Contain(DefaultVATAmount);
            json.SelectTokens("$.totalAmount").Should().Contain(DefaultTotalAmount);
        }

        [Fact]
        public async Task GetNonExistingMovementHeader()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/movement-headers/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateMovementHeader()
        {
            // Initialize the database
            await _movementHeaderRepository.CreateOrUpdateAsync(_movementHeader);
            await _movementHeaderRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _movementHeaderRepository.CountAsync();

            // Update the movementHeader
            var updatedMovementHeader = await _movementHeaderRepository.QueryHelper().GetOneAsync(it => it.Id == _movementHeader.Id);
            // Disconnect from session so that the updates on updatedMovementHeader are not directly saved in db
            //TODO detach
            updatedMovementHeader.TypeCode = UpdatedTypeCode;
            updatedMovementHeader.ReceiptNo = UpdatedReceiptNo;
            updatedMovementHeader.CustomerCardID = UpdatedCustomerCardID;
            updatedMovementHeader.FirstAmount = UpdatedFirstAmount;
            updatedMovementHeader.DiscountAmount = UpdatedDiscountAmount;
            updatedMovementHeader.VATAmount = UpdatedVATAmount;
            updatedMovementHeader.TotalAmount = UpdatedTotalAmount;

            MovementHeaderDto updatedMovementHeaderDto = _mapper.Map<MovementHeaderDto>(updatedMovementHeader);
            var response = await _client.PutAsync($"/api/movement-headers/{_movementHeader.Id}", TestUtil.ToJsonContent(updatedMovementHeaderDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the MovementHeader in the database
            var movementHeaderList = await _movementHeaderRepository.GetAllAsync();
            movementHeaderList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testMovementHeader = movementHeaderList.Last();
            testMovementHeader.TypeCode.Should().Be(UpdatedTypeCode);
            testMovementHeader.ReceiptNo.Should().Be(UpdatedReceiptNo);
            testMovementHeader.CustomerCardID.Should().Be(UpdatedCustomerCardID);
            testMovementHeader.FirstAmount.Should().Be(UpdatedFirstAmount);
            testMovementHeader.DiscountAmount.Should().Be(UpdatedDiscountAmount);
            testMovementHeader.VATAmount.Should().Be(UpdatedVATAmount);
            testMovementHeader.TotalAmount.Should().Be(UpdatedTotalAmount);
        }

        [Fact]
        public async Task UpdateNonExistingMovementHeader()
        {
            var databaseSizeBeforeUpdate = await _movementHeaderRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            MovementHeaderDto _movementHeaderDto = _mapper.Map<MovementHeaderDto>(_movementHeader);
            var response = await _client.PutAsync("/api/movement-headers/1", TestUtil.ToJsonContent(_movementHeaderDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the MovementHeader in the database
            var movementHeaderList = await _movementHeaderRepository.GetAllAsync();
            movementHeaderList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteMovementHeader()
        {
            // Initialize the database
            await _movementHeaderRepository.CreateOrUpdateAsync(_movementHeader);
            await _movementHeaderRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _movementHeaderRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/movement-headers/{_movementHeader.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var movementHeaderList = await _movementHeaderRepository.GetAllAsync();
            movementHeaderList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(MovementHeader));
            var movementHeader1 = new MovementHeader
            {
                Id = 1L
            };
            var movementHeader2 = new MovementHeader
            {
                Id = movementHeader1.Id
            };
            movementHeader1.Should().Be(movementHeader2);
            movementHeader2.Id = 2L;
            movementHeader1.Should().NotBe(movementHeader2);
            movementHeader1.Id = 0;
            movementHeader1.Should().NotBe(movementHeader2);
        }
    }
}
