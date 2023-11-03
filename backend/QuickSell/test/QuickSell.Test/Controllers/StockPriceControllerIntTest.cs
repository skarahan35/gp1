
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
    public class StockPricesControllerIntTest
    {
        public StockPricesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _stockPriceRepository = _factory.GetRequiredService<IStockPriceRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly UNKNOWN_TYPE DefaultStockID = ;
        private static readonly UNKNOWN_TYPE UpdatedStockID = ;

        private static readonly int? DefaultStockPrice = 1;
        private static readonly int? UpdatedStockPrice = 2;

        private const string DefaultStockPriceType = "AAAAAAAAAA";
        private const string UpdatedStockPriceType = "BBBBBBBBBB";

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IStockPriceRepository _stockPriceRepository;

        private StockPrice _stockPrice;

        private readonly IMapper _mapper;

        private StockPrice CreateEntity()
        {
            return new StockPrice
            {
                StockID = DefaultStockID,
                StockPrice = DefaultStockPrice,
                StockPriceType = DefaultStockPriceType,
            };
        }

        private void InitTest()
        {
            _stockPrice = CreateEntity();
        }

        [Fact]
        public async Task CreateStockPrice()
        {
            var databaseSizeBeforeCreate = await _stockPriceRepository.CountAsync();

            // Create the StockPrice
            StockPriceDto _stockPriceDto = _mapper.Map<StockPriceDto>(_stockPrice);
            var response = await _client.PostAsync("/api/stock-prices", TestUtil.ToJsonContent(_stockPriceDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the StockPrice in the database
            var stockPriceList = await _stockPriceRepository.GetAllAsync();
            stockPriceList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testStockPrice = stockPriceList.Last();
            testStockPrice.StockID.Should().Be(DefaultStockID);
            testStockPrice.StockPrice.Should().Be(DefaultStockPrice);
            testStockPrice.StockPriceType.Should().Be(DefaultStockPriceType);
        }

        [Fact]
        public async Task CreateStockPriceWithExistingId()
        {
            var databaseSizeBeforeCreate = await _stockPriceRepository.CountAsync();
            // Create the StockPrice with an existing ID
            _stockPrice.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            StockPriceDto _stockPriceDto = _mapper.Map<StockPriceDto>(_stockPrice);
            var response = await _client.PostAsync("/api/stock-prices", TestUtil.ToJsonContent(_stockPriceDto));

            // Validate the StockPrice in the database
            var stockPriceList = await _stockPriceRepository.GetAllAsync();
            stockPriceList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllStockPrices()
        {
            // Initialize the database
            await _stockPriceRepository.CreateOrUpdateAsync(_stockPrice);
            await _stockPriceRepository.SaveChangesAsync();

            // Get all the stockPriceList
            var response = await _client.GetAsync("/api/stock-prices?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_stockPrice.Id);
            json.SelectTokens("$.[*].stockId").Should().Contain(DefaultStockID);
            json.SelectTokens("$.[*].stockPrice").Should().Contain(DefaultStockPrice);
            json.SelectTokens("$.[*].stockPriceType").Should().Contain(DefaultStockPriceType);
        }

        [Fact]
        public async Task GetStockPrice()
        {
            // Initialize the database
            await _stockPriceRepository.CreateOrUpdateAsync(_stockPrice);
            await _stockPriceRepository.SaveChangesAsync();

            // Get the stockPrice
            var response = await _client.GetAsync($"/api/stock-prices/{_stockPrice.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_stockPrice.Id);
            json.SelectTokens("$.stockId").Should().Contain(DefaultStockID);
            json.SelectTokens("$.stockPrice").Should().Contain(DefaultStockPrice);
            json.SelectTokens("$.stockPriceType").Should().Contain(DefaultStockPriceType);
        }

        [Fact]
        public async Task GetNonExistingStockPrice()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/stock-prices/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateStockPrice()
        {
            // Initialize the database
            await _stockPriceRepository.CreateOrUpdateAsync(_stockPrice);
            await _stockPriceRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _stockPriceRepository.CountAsync();

            // Update the stockPrice
            var updatedStockPrice = await _stockPriceRepository.QueryHelper().GetOneAsync(it => it.Id == _stockPrice.Id);
            // Disconnect from session so that the updates on updatedStockPrice are not directly saved in db
            //TODO detach
            updatedStockPrice.StockID = UpdatedStockID;
            updatedStockPrice.StockPrice = UpdatedStockPrice;
            updatedStockPrice.StockPriceType = UpdatedStockPriceType;

            StockPriceDto updatedStockPriceDto = _mapper.Map<StockPriceDto>(updatedStockPrice);
            var response = await _client.PutAsync($"/api/stock-prices/{_stockPrice.Id}", TestUtil.ToJsonContent(updatedStockPriceDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the StockPrice in the database
            var stockPriceList = await _stockPriceRepository.GetAllAsync();
            stockPriceList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testStockPrice = stockPriceList.Last();
            testStockPrice.StockID.Should().Be(UpdatedStockID);
            testStockPrice.StockPrice.Should().Be(UpdatedStockPrice);
            testStockPrice.StockPriceType.Should().Be(UpdatedStockPriceType);
        }

        [Fact]
        public async Task UpdateNonExistingStockPrice()
        {
            var databaseSizeBeforeUpdate = await _stockPriceRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            StockPriceDto _stockPriceDto = _mapper.Map<StockPriceDto>(_stockPrice);
            var response = await _client.PutAsync("/api/stock-prices/1", TestUtil.ToJsonContent(_stockPriceDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the StockPrice in the database
            var stockPriceList = await _stockPriceRepository.GetAllAsync();
            stockPriceList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteStockPrice()
        {
            // Initialize the database
            await _stockPriceRepository.CreateOrUpdateAsync(_stockPrice);
            await _stockPriceRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _stockPriceRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/stock-prices/{_stockPrice.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var stockPriceList = await _stockPriceRepository.GetAllAsync();
            stockPriceList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(StockPrice));
            var stockPrice1 = new StockPrice
            {
                Id = 1L
            };
            var stockPrice2 = new StockPrice
            {
                Id = stockPrice1.Id
            };
            stockPrice1.Should().Be(stockPrice2);
            stockPrice2.Id = 2L;
            stockPrice1.Should().NotBe(stockPrice2);
            stockPrice1.Id = 0;
            stockPrice1.Should().NotBe(stockPrice2);
        }
    }
}
