
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
    public class MovementDetailsControllerIntTest
    {
        public MovementDetailsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _movementDetailsRepository = _factory.GetRequiredService<IMovementDetailsRepository>();

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

        private static readonly UNKNOWN_TYPE DefaultStockCardID = ;
        private static readonly UNKNOWN_TYPE UpdatedStockCardID = ;

        private static readonly int? DefaultQuantity = 1;
        private static readonly int? UpdatedQuantity = 2;

        private static readonly int? DefaultPrice = 1;
        private static readonly int? UpdatedPrice = 2;

        private static readonly int? DefaultDiscountRate = 1;
        private static readonly int? UpdatedDiscountRate = 2;

        private static readonly int? DefaultDiscountAmount = 1;
        private static readonly int? UpdatedDiscountAmount = 2;

        private static readonly int? DefaultVATRate = 1;
        private static readonly int? UpdatedVATRate = 2;

        private static readonly int? DefaultVATAmount = 1;
        private static readonly int? UpdatedVATAmount = 2;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IMovementDetailsRepository _movementDetailsRepository;

        private MovementDetails _movementDetails;

        private readonly IMapper _mapper;

        private MovementDetails CreateEntity()
        {
            return new MovementDetails
            {
                TypeCode = DefaultTypeCode,
                ReceiptNo = DefaultReceiptNo,
                StockCardID = DefaultStockCardID,
                Quantity = DefaultQuantity,
                Price = DefaultPrice,
                DiscountRate = DefaultDiscountRate,
                DiscountAmount = DefaultDiscountAmount,
                VATRate = DefaultVATRate,
                VATAmount = DefaultVATAmount,
            };
        }

        private void InitTest()
        {
            _movementDetails = CreateEntity();
        }

        [Fact]
        public async Task CreateMovementDetails()
        {
            var databaseSizeBeforeCreate = await _movementDetailsRepository.CountAsync();

            // Create the MovementDetails
            MovementDetailsDto _movementDetailsDto = _mapper.Map<MovementDetailsDto>(_movementDetails);
            var response = await _client.PostAsync("/api/movement-details", TestUtil.ToJsonContent(_movementDetailsDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the MovementDetails in the database
            var movementDetailsList = await _movementDetailsRepository.GetAllAsync();
            movementDetailsList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testMovementDetails = movementDetailsList.Last();
            testMovementDetails.TypeCode.Should().Be(DefaultTypeCode);
            testMovementDetails.ReceiptNo.Should().Be(DefaultReceiptNo);
            testMovementDetails.StockCardID.Should().Be(DefaultStockCardID);
            testMovementDetails.Quantity.Should().Be(DefaultQuantity);
            testMovementDetails.Price.Should().Be(DefaultPrice);
            testMovementDetails.DiscountRate.Should().Be(DefaultDiscountRate);
            testMovementDetails.DiscountAmount.Should().Be(DefaultDiscountAmount);
            testMovementDetails.VATRate.Should().Be(DefaultVATRate);
            testMovementDetails.VATAmount.Should().Be(DefaultVATAmount);
        }

        [Fact]
        public async Task CreateMovementDetailsWithExistingId()
        {
            var databaseSizeBeforeCreate = await _movementDetailsRepository.CountAsync();
            // Create the MovementDetails with an existing ID
            _movementDetails.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            MovementDetailsDto _movementDetailsDto = _mapper.Map<MovementDetailsDto>(_movementDetails);
            var response = await _client.PostAsync("/api/movement-details", TestUtil.ToJsonContent(_movementDetailsDto));

            // Validate the MovementDetails in the database
            var movementDetailsList = await _movementDetailsRepository.GetAllAsync();
            movementDetailsList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllMovementDetails()
        {
            // Initialize the database
            await _movementDetailsRepository.CreateOrUpdateAsync(_movementDetails);
            await _movementDetailsRepository.SaveChangesAsync();

            // Get all the movementDetailsList
            var response = await _client.GetAsync("/api/movement-details?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_movementDetails.Id);
            json.SelectTokens("$.[*].typeCode").Should().Contain(DefaultTypeCode);
            json.SelectTokens("$.[*].receiptNo").Should().Contain(DefaultReceiptNo);
            json.SelectTokens("$.[*].stockCardId").Should().Contain(DefaultStockCardID);
            json.SelectTokens("$.[*].quantity").Should().Contain(DefaultQuantity);
            json.SelectTokens("$.[*].price").Should().Contain(DefaultPrice);
            json.SelectTokens("$.[*].discountRate").Should().Contain(DefaultDiscountRate);
            json.SelectTokens("$.[*].discountAmount").Should().Contain(DefaultDiscountAmount);
            json.SelectTokens("$.[*].vAtRate").Should().Contain(DefaultVATRate);
            json.SelectTokens("$.[*].vAtAmount").Should().Contain(DefaultVATAmount);
        }

        [Fact]
        public async Task GetMovementDetails()
        {
            // Initialize the database
            await _movementDetailsRepository.CreateOrUpdateAsync(_movementDetails);
            await _movementDetailsRepository.SaveChangesAsync();

            // Get the movementDetails
            var response = await _client.GetAsync($"/api/movement-details/{_movementDetails.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_movementDetails.Id);
            json.SelectTokens("$.typeCode").Should().Contain(DefaultTypeCode);
            json.SelectTokens("$.receiptNo").Should().Contain(DefaultReceiptNo);
            json.SelectTokens("$.stockCardId").Should().Contain(DefaultStockCardID);
            json.SelectTokens("$.quantity").Should().Contain(DefaultQuantity);
            json.SelectTokens("$.price").Should().Contain(DefaultPrice);
            json.SelectTokens("$.discountRate").Should().Contain(DefaultDiscountRate);
            json.SelectTokens("$.discountAmount").Should().Contain(DefaultDiscountAmount);
            json.SelectTokens("$.vAtRate").Should().Contain(DefaultVATRate);
            json.SelectTokens("$.vAtAmount").Should().Contain(DefaultVATAmount);
        }

        [Fact]
        public async Task GetNonExistingMovementDetails()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/movement-details/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateMovementDetails()
        {
            // Initialize the database
            await _movementDetailsRepository.CreateOrUpdateAsync(_movementDetails);
            await _movementDetailsRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _movementDetailsRepository.CountAsync();

            // Update the movementDetails
            var updatedMovementDetails = await _movementDetailsRepository.QueryHelper().GetOneAsync(it => it.Id == _movementDetails.Id);
            // Disconnect from session so that the updates on updatedMovementDetails are not directly saved in db
            //TODO detach
            updatedMovementDetails.TypeCode = UpdatedTypeCode;
            updatedMovementDetails.ReceiptNo = UpdatedReceiptNo;
            updatedMovementDetails.StockCardID = UpdatedStockCardID;
            updatedMovementDetails.Quantity = UpdatedQuantity;
            updatedMovementDetails.Price = UpdatedPrice;
            updatedMovementDetails.DiscountRate = UpdatedDiscountRate;
            updatedMovementDetails.DiscountAmount = UpdatedDiscountAmount;
            updatedMovementDetails.VATRate = UpdatedVATRate;
            updatedMovementDetails.VATAmount = UpdatedVATAmount;

            MovementDetailsDto updatedMovementDetailsDto = _mapper.Map<MovementDetailsDto>(updatedMovementDetails);
            var response = await _client.PutAsync($"/api/movement-details/{_movementDetails.Id}", TestUtil.ToJsonContent(updatedMovementDetailsDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the MovementDetails in the database
            var movementDetailsList = await _movementDetailsRepository.GetAllAsync();
            movementDetailsList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testMovementDetails = movementDetailsList.Last();
            testMovementDetails.TypeCode.Should().Be(UpdatedTypeCode);
            testMovementDetails.ReceiptNo.Should().Be(UpdatedReceiptNo);
            testMovementDetails.StockCardID.Should().Be(UpdatedStockCardID);
            testMovementDetails.Quantity.Should().Be(UpdatedQuantity);
            testMovementDetails.Price.Should().Be(UpdatedPrice);
            testMovementDetails.DiscountRate.Should().Be(UpdatedDiscountRate);
            testMovementDetails.DiscountAmount.Should().Be(UpdatedDiscountAmount);
            testMovementDetails.VATRate.Should().Be(UpdatedVATRate);
            testMovementDetails.VATAmount.Should().Be(UpdatedVATAmount);
        }

        [Fact]
        public async Task UpdateNonExistingMovementDetails()
        {
            var databaseSizeBeforeUpdate = await _movementDetailsRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            MovementDetailsDto _movementDetailsDto = _mapper.Map<MovementDetailsDto>(_movementDetails);
            var response = await _client.PutAsync("/api/movement-details/1", TestUtil.ToJsonContent(_movementDetailsDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the MovementDetails in the database
            var movementDetailsList = await _movementDetailsRepository.GetAllAsync();
            movementDetailsList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteMovementDetails()
        {
            // Initialize the database
            await _movementDetailsRepository.CreateOrUpdateAsync(_movementDetails);
            await _movementDetailsRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _movementDetailsRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/movement-details/{_movementDetails.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var movementDetailsList = await _movementDetailsRepository.GetAllAsync();
            movementDetailsList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(MovementDetails));
            var movementDetails1 = new MovementDetails
            {
                Id = 1L
            };
            var movementDetails2 = new MovementDetails
            {
                Id = movementDetails1.Id
            };
            movementDetails1.Should().Be(movementDetails2);
            movementDetails2.Id = 2L;
            movementDetails1.Should().NotBe(movementDetails2);
            movementDetails1.Id = 0;
            movementDetails1.Should().NotBe(movementDetails2);
        }
    }
}
