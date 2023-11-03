
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
    public class StockTypesControllerIntTest
    {
        public StockTypesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _stockTypeRepository = _factory.GetRequiredService<IStockTypeRepository>();

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

        private static readonly bool? DefaultCondition = false;
        private static readonly bool? UpdatedCondition = true;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IStockTypeRepository _stockTypeRepository;

        private StockType _stockType;

        private readonly IMapper _mapper;

        private StockType CreateEntity()
        {
            return new StockType
            {
                Code = DefaultCode,
                Name = DefaultName,
                Condition = DefaultCondition,
            };
        }

        private void InitTest()
        {
            _stockType = CreateEntity();
        }

        [Fact]
        public async Task CreateStockType()
        {
            var databaseSizeBeforeCreate = await _stockTypeRepository.CountAsync();

            // Create the StockType
            StockTypeDto _stockTypeDto = _mapper.Map<StockTypeDto>(_stockType);
            var response = await _client.PostAsync("/api/stock-types", TestUtil.ToJsonContent(_stockTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the StockType in the database
            var stockTypeList = await _stockTypeRepository.GetAllAsync();
            stockTypeList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testStockType = stockTypeList.Last();
            testStockType.Code.Should().Be(DefaultCode);
            testStockType.Name.Should().Be(DefaultName);
            testStockType.Condition.Should().Be(DefaultCondition);
        }

        [Fact]
        public async Task CreateStockTypeWithExistingId()
        {
            var databaseSizeBeforeCreate = await _stockTypeRepository.CountAsync();
            // Create the StockType with an existing ID
            _stockType.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            StockTypeDto _stockTypeDto = _mapper.Map<StockTypeDto>(_stockType);
            var response = await _client.PostAsync("/api/stock-types", TestUtil.ToJsonContent(_stockTypeDto));

            // Validate the StockType in the database
            var stockTypeList = await _stockTypeRepository.GetAllAsync();
            stockTypeList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllStockTypes()
        {
            // Initialize the database
            await _stockTypeRepository.CreateOrUpdateAsync(_stockType);
            await _stockTypeRepository.SaveChangesAsync();

            // Get all the stockTypeList
            var response = await _client.GetAsync("/api/stock-types?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_stockType.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
            json.SelectTokens("$.[*].condition").Should().Contain(DefaultCondition);
        }

        [Fact]
        public async Task GetStockType()
        {
            // Initialize the database
            await _stockTypeRepository.CreateOrUpdateAsync(_stockType);
            await _stockTypeRepository.SaveChangesAsync();

            // Get the stockType
            var response = await _client.GetAsync($"/api/stock-types/{_stockType.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_stockType.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
            json.SelectTokens("$.condition").Should().Contain(DefaultCondition);
        }

        [Fact]
        public async Task GetNonExistingStockType()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/stock-types/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateStockType()
        {
            // Initialize the database
            await _stockTypeRepository.CreateOrUpdateAsync(_stockType);
            await _stockTypeRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _stockTypeRepository.CountAsync();

            // Update the stockType
            var updatedStockType = await _stockTypeRepository.QueryHelper().GetOneAsync(it => it.Id == _stockType.Id);
            // Disconnect from session so that the updates on updatedStockType are not directly saved in db
            //TODO detach
            updatedStockType.Code = UpdatedCode;
            updatedStockType.Name = UpdatedName;
            updatedStockType.Condition = UpdatedCondition;

            StockTypeDto updatedStockTypeDto = _mapper.Map<StockTypeDto>(updatedStockType);
            var response = await _client.PutAsync($"/api/stock-types/{_stockType.Id}", TestUtil.ToJsonContent(updatedStockTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the StockType in the database
            var stockTypeList = await _stockTypeRepository.GetAllAsync();
            stockTypeList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testStockType = stockTypeList.Last();
            testStockType.Code.Should().Be(UpdatedCode);
            testStockType.Name.Should().Be(UpdatedName);
            testStockType.Condition.Should().Be(UpdatedCondition);
        }

        [Fact]
        public async Task UpdateNonExistingStockType()
        {
            var databaseSizeBeforeUpdate = await _stockTypeRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            StockTypeDto _stockTypeDto = _mapper.Map<StockTypeDto>(_stockType);
            var response = await _client.PutAsync("/api/stock-types/1", TestUtil.ToJsonContent(_stockTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the StockType in the database
            var stockTypeList = await _stockTypeRepository.GetAllAsync();
            stockTypeList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteStockType()
        {
            // Initialize the database
            await _stockTypeRepository.CreateOrUpdateAsync(_stockType);
            await _stockTypeRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _stockTypeRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/stock-types/{_stockType.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var stockTypeList = await _stockTypeRepository.GetAllAsync();
            stockTypeList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(StockType));
            var stockType1 = new StockType
            {
                Id = 1L
            };
            var stockType2 = new StockType
            {
                Id = stockType1.Id
            };
            stockType1.Should().Be(stockType2);
            stockType2.Id = 2L;
            stockType1.Should().NotBe(stockType2);
            stockType1.Id = 0;
            stockType1.Should().NotBe(stockType2);
        }
    }
}
