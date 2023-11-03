
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
    public class StockUnitsControllerIntTest
    {
        public StockUnitsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _stockUnitRepository = _factory.GetRequiredService<IStockUnitRepository>();

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
        private readonly IStockUnitRepository _stockUnitRepository;

        private StockUnit _stockUnit;

        private readonly IMapper _mapper;

        private StockUnit CreateEntity()
        {
            return new StockUnit
            {
                Code = DefaultCode,
                Name = DefaultName,
            };
        }

        private void InitTest()
        {
            _stockUnit = CreateEntity();
        }

        [Fact]
        public async Task CreateStockUnit()
        {
            var databaseSizeBeforeCreate = await _stockUnitRepository.CountAsync();

            // Create the StockUnit
            StockUnitDto _stockUnitDto = _mapper.Map<StockUnitDto>(_stockUnit);
            var response = await _client.PostAsync("/api/stock-units", TestUtil.ToJsonContent(_stockUnitDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the StockUnit in the database
            var stockUnitList = await _stockUnitRepository.GetAllAsync();
            stockUnitList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testStockUnit = stockUnitList.Last();
            testStockUnit.Code.Should().Be(DefaultCode);
            testStockUnit.Name.Should().Be(DefaultName);
        }

        [Fact]
        public async Task CreateStockUnitWithExistingId()
        {
            var databaseSizeBeforeCreate = await _stockUnitRepository.CountAsync();
            // Create the StockUnit with an existing ID
            _stockUnit.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            StockUnitDto _stockUnitDto = _mapper.Map<StockUnitDto>(_stockUnit);
            var response = await _client.PostAsync("/api/stock-units", TestUtil.ToJsonContent(_stockUnitDto));

            // Validate the StockUnit in the database
            var stockUnitList = await _stockUnitRepository.GetAllAsync();
            stockUnitList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllStockUnits()
        {
            // Initialize the database
            await _stockUnitRepository.CreateOrUpdateAsync(_stockUnit);
            await _stockUnitRepository.SaveChangesAsync();

            // Get all the stockUnitList
            var response = await _client.GetAsync("/api/stock-units?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_stockUnit.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetStockUnit()
        {
            // Initialize the database
            await _stockUnitRepository.CreateOrUpdateAsync(_stockUnit);
            await _stockUnitRepository.SaveChangesAsync();

            // Get the stockUnit
            var response = await _client.GetAsync($"/api/stock-units/{_stockUnit.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_stockUnit.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetNonExistingStockUnit()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/stock-units/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateStockUnit()
        {
            // Initialize the database
            await _stockUnitRepository.CreateOrUpdateAsync(_stockUnit);
            await _stockUnitRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _stockUnitRepository.CountAsync();

            // Update the stockUnit
            var updatedStockUnit = await _stockUnitRepository.QueryHelper().GetOneAsync(it => it.Id == _stockUnit.Id);
            // Disconnect from session so that the updates on updatedStockUnit are not directly saved in db
            //TODO detach
            updatedStockUnit.Code = UpdatedCode;
            updatedStockUnit.Name = UpdatedName;

            StockUnitDto updatedStockUnitDto = _mapper.Map<StockUnitDto>(updatedStockUnit);
            var response = await _client.PutAsync($"/api/stock-units/{_stockUnit.Id}", TestUtil.ToJsonContent(updatedStockUnitDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the StockUnit in the database
            var stockUnitList = await _stockUnitRepository.GetAllAsync();
            stockUnitList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testStockUnit = stockUnitList.Last();
            testStockUnit.Code.Should().Be(UpdatedCode);
            testStockUnit.Name.Should().Be(UpdatedName);
        }

        [Fact]
        public async Task UpdateNonExistingStockUnit()
        {
            var databaseSizeBeforeUpdate = await _stockUnitRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            StockUnitDto _stockUnitDto = _mapper.Map<StockUnitDto>(_stockUnit);
            var response = await _client.PutAsync("/api/stock-units/1", TestUtil.ToJsonContent(_stockUnitDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the StockUnit in the database
            var stockUnitList = await _stockUnitRepository.GetAllAsync();
            stockUnitList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteStockUnit()
        {
            // Initialize the database
            await _stockUnitRepository.CreateOrUpdateAsync(_stockUnit);
            await _stockUnitRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _stockUnitRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/stock-units/{_stockUnit.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var stockUnitList = await _stockUnitRepository.GetAllAsync();
            stockUnitList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(StockUnit));
            var stockUnit1 = new StockUnit
            {
                Id = 1L
            };
            var stockUnit2 = new StockUnit
            {
                Id = stockUnit1.Id
            };
            stockUnit1.Should().Be(stockUnit2);
            stockUnit2.Id = 2L;
            stockUnit1.Should().NotBe(stockUnit2);
            stockUnit1.Id = 0;
            stockUnit1.Should().NotBe(stockUnit2);
        }
    }
}
