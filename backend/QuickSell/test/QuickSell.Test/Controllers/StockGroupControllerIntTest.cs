
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
    public class StockGroupsControllerIntTest
    {
        public StockGroupsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _stockGroupRepository = _factory.GetRequiredService<IStockGroupRepository>();

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
        private readonly IStockGroupRepository _stockGroupRepository;

        private StockGroup _stockGroup;

        private readonly IMapper _mapper;

        private StockGroup CreateEntity()
        {
            return new StockGroup
            {
                Code = DefaultCode,
                Name = DefaultName,
            };
        }

        private void InitTest()
        {
            _stockGroup = CreateEntity();
        }

        [Fact]
        public async Task CreateStockGroup()
        {
            var databaseSizeBeforeCreate = await _stockGroupRepository.CountAsync();

            // Create the StockGroup
            StockGroupDto _stockGroupDto = _mapper.Map<StockGroupDto>(_stockGroup);
            var response = await _client.PostAsync("/api/stock-groups", TestUtil.ToJsonContent(_stockGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the StockGroup in the database
            var stockGroupList = await _stockGroupRepository.GetAllAsync();
            stockGroupList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testStockGroup = stockGroupList.Last();
            testStockGroup.Code.Should().Be(DefaultCode);
            testStockGroup.Name.Should().Be(DefaultName);
        }

        [Fact]
        public async Task CreateStockGroupWithExistingId()
        {
            var databaseSizeBeforeCreate = await _stockGroupRepository.CountAsync();
            // Create the StockGroup with an existing ID
            _stockGroup.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            StockGroupDto _stockGroupDto = _mapper.Map<StockGroupDto>(_stockGroup);
            var response = await _client.PostAsync("/api/stock-groups", TestUtil.ToJsonContent(_stockGroupDto));

            // Validate the StockGroup in the database
            var stockGroupList = await _stockGroupRepository.GetAllAsync();
            stockGroupList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllStockGroups()
        {
            // Initialize the database
            await _stockGroupRepository.CreateOrUpdateAsync(_stockGroup);
            await _stockGroupRepository.SaveChangesAsync();

            // Get all the stockGroupList
            var response = await _client.GetAsync("/api/stock-groups?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_stockGroup.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetStockGroup()
        {
            // Initialize the database
            await _stockGroupRepository.CreateOrUpdateAsync(_stockGroup);
            await _stockGroupRepository.SaveChangesAsync();

            // Get the stockGroup
            var response = await _client.GetAsync($"/api/stock-groups/{_stockGroup.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_stockGroup.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.name").Should().Contain(DefaultName);
        }

        [Fact]
        public async Task GetNonExistingStockGroup()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/stock-groups/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateStockGroup()
        {
            // Initialize the database
            await _stockGroupRepository.CreateOrUpdateAsync(_stockGroup);
            await _stockGroupRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _stockGroupRepository.CountAsync();

            // Update the stockGroup
            var updatedStockGroup = await _stockGroupRepository.QueryHelper().GetOneAsync(it => it.Id == _stockGroup.Id);
            // Disconnect from session so that the updates on updatedStockGroup are not directly saved in db
            //TODO detach
            updatedStockGroup.Code = UpdatedCode;
            updatedStockGroup.Name = UpdatedName;

            StockGroupDto updatedStockGroupDto = _mapper.Map<StockGroupDto>(updatedStockGroup);
            var response = await _client.PutAsync($"/api/stock-groups/{_stockGroup.Id}", TestUtil.ToJsonContent(updatedStockGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the StockGroup in the database
            var stockGroupList = await _stockGroupRepository.GetAllAsync();
            stockGroupList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testStockGroup = stockGroupList.Last();
            testStockGroup.Code.Should().Be(UpdatedCode);
            testStockGroup.Name.Should().Be(UpdatedName);
        }

        [Fact]
        public async Task UpdateNonExistingStockGroup()
        {
            var databaseSizeBeforeUpdate = await _stockGroupRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            StockGroupDto _stockGroupDto = _mapper.Map<StockGroupDto>(_stockGroup);
            var response = await _client.PutAsync("/api/stock-groups/1", TestUtil.ToJsonContent(_stockGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the StockGroup in the database
            var stockGroupList = await _stockGroupRepository.GetAllAsync();
            stockGroupList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteStockGroup()
        {
            // Initialize the database
            await _stockGroupRepository.CreateOrUpdateAsync(_stockGroup);
            await _stockGroupRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _stockGroupRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/stock-groups/{_stockGroup.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var stockGroupList = await _stockGroupRepository.GetAllAsync();
            stockGroupList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(StockGroup));
            var stockGroup1 = new StockGroup
            {
                Id = 1L
            };
            var stockGroup2 = new StockGroup
            {
                Id = stockGroup1.Id
            };
            stockGroup1.Should().Be(stockGroup2);
            stockGroup2.Id = 2L;
            stockGroup1.Should().NotBe(stockGroup2);
            stockGroup1.Id = 0;
            stockGroup1.Should().NotBe(stockGroup2);
        }
    }
}
