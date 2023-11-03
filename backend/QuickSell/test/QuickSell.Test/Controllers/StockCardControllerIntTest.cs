
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
    public class StockCardsControllerIntTest
    {
        public StockCardsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _stockCardRepository = _factory.GetRequiredService<IStockCardRepository>();

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

        private static readonly UNKNOWN_TYPE DefaultStockTypeID = ;
        private static readonly UNKNOWN_TYPE UpdatedStockTypeID = ;

        private static readonly UNKNOWN_TYPE DefaultStockUnitID = ;
        private static readonly UNKNOWN_TYPE UpdatedStockUnitID = ;

        private static readonly UNKNOWN_TYPE DefaultStockGroupID = ;
        private static readonly UNKNOWN_TYPE UpdatedStockGroupID = ;

        private static readonly int? DefaultTransferredQuantity = 1;
        private static readonly int? UpdatedTransferredQuantity = 2;

        private static readonly int? DefaultAvailableQuantity = 1;
        private static readonly int? UpdatedAvailableQuantity = 2;

        private static readonly int? DefaultTotalEntryQuantity = 1;
        private static readonly int? UpdatedTotalEntryQuantity = 2;

        private static readonly int? DefaultTotalOutputQuantity = 1;
        private static readonly int? UpdatedTotalOutputQuantity = 2;

        private static readonly int? DefaultVATRate = 1;
        private static readonly int? UpdatedVATRate = 2;

        private static readonly int? DefaultDiscountRate = 1;
        private static readonly int? UpdatedDiscountRate = 2;

        private const string DefaultCurrencyType = "AAAAAAAAAA";
        private const string UpdatedCurrencyType = "BBBBBBBBBB";

        private static readonly int? DefaultPrice1 = 1;
        private static readonly int? UpdatedPrice1 = 2;

        private static readonly int? DefaultPrice2 = 1;
        private static readonly int? UpdatedPrice2 = 2;

        private static readonly int? DefaultPrice3 = 1;
        private static readonly int? UpdatedPrice3 = 2;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IStockCardRepository _stockCardRepository;

        private StockCard _stockCard;

        private readonly IMapper _mapper;

        private StockCard CreateEntity()
        {
            return new StockCard
            {
                Code = DefaultCode,
                Name = DefaultName,
                StockTypeID = DefaultStockTypeID,
                StockUnitID = DefaultStockUnitID,
                StockGroupID = DefaultStockGroupID,
                TransferredQuantity = DefaultTransferredQuantity,
                AvailableQuantity = DefaultAvailableQuantity,
                TotalEntryQuantity = DefaultTotalEntryQuantity,
                TotalOutputQuantity = DefaultTotalOutputQuantity,
                VATRate = DefaultVATRate,
                DiscountRate = DefaultDiscountRate,
                CurrencyType = DefaultCurrencyType,
                Price1 = DefaultPrice1,
                Price2 = DefaultPrice2,
                Price3 = DefaultPrice3,
            };
        }

        private void InitTest()
        {
            _stockCard = CreateEntity();
        }

        [Fact]
        public async Task CreateStockCard()
        {
            var databaseSizeBeforeCreate = await _stockCardRepository.CountAsync();

            // Create the StockCard
            StockCardDto _stockCardDto = _mapper.Map<StockCardDto>(_stockCard);
            var response = await _client.PostAsync("/api/stock-cards", TestUtil.ToJsonContent(_stockCardDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the StockCard in the database
            var stockCardList = await _stockCardRepository.GetAllAsync();
            stockCardList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testStockCard = stockCardList.Last();
            testStockCard.Code.Should().Be(DefaultCode);
            testStockCard.Name.Should().Be(DefaultName);
            testStockCard.StockTypeID.Should().Be(DefaultStockTypeID);
            testStockCard.StockUnitID.Should().Be(DefaultStockUnitID);
            testStockCard.StockGroupID.Should().Be(DefaultStockGroupID);
            testStockCard.TransferredQuantity.Should().Be(DefaultTransferredQuantity);
            testStockCard.AvailableQuantity.Should().Be(DefaultAvailableQuantity);
            testStockCard.TotalEntryQuantity.Should().Be(DefaultTotalEntryQuantity);
            testStockCard.TotalOutputQuantity.Should().Be(DefaultTotalOutputQuantity);
            testStockCard.VATRate.Should().Be(DefaultVATRate);
            testStockCard.DiscountRate.Should().Be(DefaultDiscountRate);
            testStockCard.CurrencyType.Should().Be(DefaultCurrencyType);
            testStockCard.Price1.Should().Be(DefaultPrice1);
            testStockCard.Price2.Should().Be(DefaultPrice2);
            testStockCard.Price3.Should().Be(DefaultPrice3);
        }

        [Fact]
        public async Task CreateStockCardWithExistingId()
        {
            var databaseSizeBeforeCreate = await _stockCardRepository.CountAsync();
            // Create the StockCard with an existing ID
            _stockCard.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            StockCardDto _stockCardDto = _mapper.Map<StockCardDto>(_stockCard);
            var response = await _client.PostAsync("/api/stock-cards", TestUtil.ToJsonContent(_stockCardDto));

            // Validate the StockCard in the database
            var stockCardList = await _stockCardRepository.GetAllAsync();
            stockCardList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllStockCards()
        {
            // Initialize the database
            await _stockCardRepository.CreateOrUpdateAsync(_stockCard);
            await _stockCardRepository.SaveChangesAsync();

            // Get all the stockCardList
            var response = await _client.GetAsync("/api/stock-cards?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_stockCard.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
            json.SelectTokens("$.[*].stockTypeId").Should().Contain(DefaultStockTypeID);
            json.SelectTokens("$.[*].stockUnitId").Should().Contain(DefaultStockUnitID);
            json.SelectTokens("$.[*].stockGroupId").Should().Contain(DefaultStockGroupID);
            json.SelectTokens("$.[*].transferredQuantity").Should().Contain(DefaultTransferredQuantity);
            json.SelectTokens("$.[*].availableQuantity").Should().Contain(DefaultAvailableQuantity);
            json.SelectTokens("$.[*].totalEntryQuantity").Should().Contain(DefaultTotalEntryQuantity);
            json.SelectTokens("$.[*].totalOutputQuantity").Should().Contain(DefaultTotalOutputQuantity);
            json.SelectTokens("$.[*].vAtRate").Should().Contain(DefaultVATRate);
            json.SelectTokens("$.[*].discountRate").Should().Contain(DefaultDiscountRate);
            json.SelectTokens("$.[*].currencyType").Should().Contain(DefaultCurrencyType);
            json.SelectTokens("$.[*].price1").Should().Contain(DefaultPrice1);
            json.SelectTokens("$.[*].price2").Should().Contain(DefaultPrice2);
            json.SelectTokens("$.[*].price3").Should().Contain(DefaultPrice3);
        }

        [Fact]
        public async Task GetStockCard()
        {
            // Initialize the database
            await _stockCardRepository.CreateOrUpdateAsync(_stockCard);
            await _stockCardRepository.SaveChangesAsync();

            // Get the stockCard
            var response = await _client.GetAsync($"/api/stock-cards/{_stockCard.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_stockCard.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
            json.SelectTokens("$.stockTypeId").Should().Contain(DefaultStockTypeID);
            json.SelectTokens("$.stockUnitId").Should().Contain(DefaultStockUnitID);
            json.SelectTokens("$.stockGroupId").Should().Contain(DefaultStockGroupID);
            json.SelectTokens("$.transferredQuantity").Should().Contain(DefaultTransferredQuantity);
            json.SelectTokens("$.availableQuantity").Should().Contain(DefaultAvailableQuantity);
            json.SelectTokens("$.totalEntryQuantity").Should().Contain(DefaultTotalEntryQuantity);
            json.SelectTokens("$.totalOutputQuantity").Should().Contain(DefaultTotalOutputQuantity);
            json.SelectTokens("$.vAtRate").Should().Contain(DefaultVATRate);
            json.SelectTokens("$.discountRate").Should().Contain(DefaultDiscountRate);
            json.SelectTokens("$.currencyType").Should().Contain(DefaultCurrencyType);
            json.SelectTokens("$.price1").Should().Contain(DefaultPrice1);
            json.SelectTokens("$.price2").Should().Contain(DefaultPrice2);
            json.SelectTokens("$.price3").Should().Contain(DefaultPrice3);
        }

        [Fact]
        public async Task GetNonExistingStockCard()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/stock-cards/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateStockCard()
        {
            // Initialize the database
            await _stockCardRepository.CreateOrUpdateAsync(_stockCard);
            await _stockCardRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _stockCardRepository.CountAsync();

            // Update the stockCard
            var updatedStockCard = await _stockCardRepository.QueryHelper().GetOneAsync(it => it.Id == _stockCard.Id);
            // Disconnect from session so that the updates on updatedStockCard are not directly saved in db
            //TODO detach
            updatedStockCard.Code = UpdatedCode;
            updatedStockCard.Name = UpdatedName;
            updatedStockCard.StockTypeID = UpdatedStockTypeID;
            updatedStockCard.StockUnitID = UpdatedStockUnitID;
            updatedStockCard.StockGroupID = UpdatedStockGroupID;
            updatedStockCard.TransferredQuantity = UpdatedTransferredQuantity;
            updatedStockCard.AvailableQuantity = UpdatedAvailableQuantity;
            updatedStockCard.TotalEntryQuantity = UpdatedTotalEntryQuantity;
            updatedStockCard.TotalOutputQuantity = UpdatedTotalOutputQuantity;
            updatedStockCard.VATRate = UpdatedVATRate;
            updatedStockCard.DiscountRate = UpdatedDiscountRate;
            updatedStockCard.CurrencyType = UpdatedCurrencyType;
            updatedStockCard.Price1 = UpdatedPrice1;
            updatedStockCard.Price2 = UpdatedPrice2;
            updatedStockCard.Price3 = UpdatedPrice3;

            StockCardDto updatedStockCardDto = _mapper.Map<StockCardDto>(updatedStockCard);
            var response = await _client.PutAsync($"/api/stock-cards/{_stockCard.Id}", TestUtil.ToJsonContent(updatedStockCardDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the StockCard in the database
            var stockCardList = await _stockCardRepository.GetAllAsync();
            stockCardList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testStockCard = stockCardList.Last();
            testStockCard.Code.Should().Be(UpdatedCode);
            testStockCard.Name.Should().Be(UpdatedName);
            testStockCard.StockTypeID.Should().Be(UpdatedStockTypeID);
            testStockCard.StockUnitID.Should().Be(UpdatedStockUnitID);
            testStockCard.StockGroupID.Should().Be(UpdatedStockGroupID);
            testStockCard.TransferredQuantity.Should().Be(UpdatedTransferredQuantity);
            testStockCard.AvailableQuantity.Should().Be(UpdatedAvailableQuantity);
            testStockCard.TotalEntryQuantity.Should().Be(UpdatedTotalEntryQuantity);
            testStockCard.TotalOutputQuantity.Should().Be(UpdatedTotalOutputQuantity);
            testStockCard.VATRate.Should().Be(UpdatedVATRate);
            testStockCard.DiscountRate.Should().Be(UpdatedDiscountRate);
            testStockCard.CurrencyType.Should().Be(UpdatedCurrencyType);
            testStockCard.Price1.Should().Be(UpdatedPrice1);
            testStockCard.Price2.Should().Be(UpdatedPrice2);
            testStockCard.Price3.Should().Be(UpdatedPrice3);
        }

        [Fact]
        public async Task UpdateNonExistingStockCard()
        {
            var databaseSizeBeforeUpdate = await _stockCardRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            StockCardDto _stockCardDto = _mapper.Map<StockCardDto>(_stockCard);
            var response = await _client.PutAsync("/api/stock-cards/1", TestUtil.ToJsonContent(_stockCardDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the StockCard in the database
            var stockCardList = await _stockCardRepository.GetAllAsync();
            stockCardList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteStockCard()
        {
            // Initialize the database
            await _stockCardRepository.CreateOrUpdateAsync(_stockCard);
            await _stockCardRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _stockCardRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/stock-cards/{_stockCard.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var stockCardList = await _stockCardRepository.GetAllAsync();
            stockCardList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(StockCard));
            var stockCard1 = new StockCard
            {
                Id = 1L
            };
            var stockCard2 = new StockCard
            {
                Id = stockCard1.Id
            };
            stockCard1.Should().Be(stockCard2);
            stockCard2.Id = 2L;
            stockCard1.Should().NotBe(stockCard2);
            stockCard1.Id = 0;
            stockCard1.Should().NotBe(stockCard2);
        }
    }
}
