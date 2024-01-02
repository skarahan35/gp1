
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using Volo.Abp.Data;
using QuickSell.Tools;
using Volo.Abp.ObjectMapping;
using QuickSell.Localization;
using Microsoft.Extensions.Localization;

namespace QuickSell.StockCards
{
    public class StockCardsAppService :ApplicationService, IStockCardsAppService
    {
        private readonly IStockCardRepository _stockCardRepository;
        private readonly StockCardManager _stockCardManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public StockCardsAppService(IStockCardRepository stockCardRepository,
                                    StockCardManager stockCardManager,
                                    IDataFilter dataFilter,
                                    IStringLocalizer<QuickSellResource> localizer)
        {
            _stockCardRepository = stockCardRepository;
            _stockCardManager= stockCardManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }

        public async Task<LoadResult> GetListStockCard(DataSourceLoadOptions loadOptions)
        {
            var getStockCard = await _stockCardRepository.GetQueryableAsync();

            var getJoinedData = from stkcrd in getStockCard
                                select new DxStockCardLookupDto
                                {
                                    Id = stkcrd.Id,
                                    Code = stkcrd.Code,
                                    Name = stkcrd.Name,
                                    StockTypeID= stkcrd.StockTypeID,
                                    StockUnitID= stkcrd.StockUnitID,
                                    StockGroupID= stkcrd.StockGroupID,
                                    TransferredQuantity= stkcrd.TransferredQuantity,
                                    AvailableQuantity= stkcrd.AvailableQuantity,
                                    TotalEntryQuantity= stkcrd.TotalEntryQuantity,
                                    TotalOutputQuantity= stkcrd.TotalOutputQuantity,
                                    VATRate= stkcrd.VATRate,
                                    DiscountRate= stkcrd.DiscountRate,
                                    CurrencyType= stkcrd.CurrencyType,
                                    Price1= stkcrd.Price1,
                                    Price2= stkcrd.Price2,
                                    Price3= stkcrd.Price3,
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxStockCardLookupDto?> GetStockCardByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getStockCard = (await _stockCardRepository.GetQueryableAsync());
                var stockCard = (from stkcrd in getStockCard
                                 where stkcrd.Id == id
                                  select new DxStockCardLookupDto
                                  {
                                      Id = stkcrd.Id,
                                      Code = stkcrd.Code,
                                      Name = stkcrd.Name,
                                      StockTypeID = stkcrd.StockTypeID,
                                      StockUnitID = stkcrd.StockUnitID,
                                      StockGroupID = stkcrd.StockGroupID,
                                      TransferredQuantity = stkcrd.TransferredQuantity,
                                      AvailableQuantity = stkcrd.AvailableQuantity,
                                      TotalEntryQuantity = stkcrd.TotalEntryQuantity,
                                      TotalOutputQuantity = stkcrd.TotalOutputQuantity,
                                      VATRate = stkcrd.VATRate,
                                      DiscountRate = stkcrd.DiscountRate,
                                      CurrencyType = stkcrd.CurrencyType,
                                      Price1 = stkcrd.Price1,
                                      Price2 = stkcrd.Price2,
                                      Price3 = stkcrd.Price3,
                                  }).FirstOrDefault();
                return stockCard;
            }
        }
        public async Task StockCardValidation(StockCardDto input)
        {
            var qry = await _stockCardRepository.GetQueryableAsync();
            await Validation<StockCard, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<StockCard, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<StockCardDto> AddStockCard(StockCardDto input)
        {
            await StockCardValidation(input);
            var stockCard = await _stockCardManager.CreateAsync(
              input.Code,
              input.Name,
              input.StockTypeID,
              input.StockUnitID,
              input.StockGroupID,
              input.CurrencyType,
              input.TransferredQuantity,
              input.AvailableQuantity,
              input.TotalEntryQuantity,
              input.TotalOutputQuantity,
              input.VATRate,
              input.DiscountRate,
              input.Price1,
              input.Price2,
              input.Price3
          );
            return ObjectMapper.Map<StockCard, StockCardDto>(stockCard);
        }
        public async Task<StockCardDto> UpdateStockCard(Guid id, IDictionary<string, object> input)
        {
            var stockCard = await _stockCardRepository.GetAsync(id);
            var stockCardDto = ObjectMapper.Map<StockCard, StockCardDto>(stockCard);
            await DevExtremeUpdate.Update(stockCardDto, input);

            return await BPUpdateStockCards(stockCardDto.Id, stockCardDto);
        }
        public async Task<StockCardDto> BPUpdateStockCards(Guid? id, StockCardDto input)
        {
            //await StockCardValidation(input);
            var stockCard = await _stockCardManager.UpdateAsync(
              id,
              input.Code,
              input.Name,
              input.StockTypeID,
              input.StockUnitID,
              input.StockGroupID,
              input.CurrencyType,
              input.TransferredQuantity,
              input.AvailableQuantity,
              input.TotalEntryQuantity,
              input.TotalOutputQuantity,
              input.VATRate,
              input.DiscountRate,
              input.Price1,
              input.Price2,
              input.Price3
            );
            await _stockCardRepository.UpdateAsync(stockCard);

            return ObjectMapper.Map<StockCard, StockCardDto>(stockCard);
        }
        public async Task DeleteStockCard(Guid id)
        {
            await _stockCardRepository.DeleteAsync(id);
        }
        public async Task<List<LookupDto<int>>> CurrencyTypeLookup()
        {
            var operationType = typeof(CurrencyTypeEnum).GetEnumValues().Cast<object>().ToDictionary(o => (int)o, v => v.ToString());
            var lookupdata = new List<LookupDto<int>>();

            foreach (var item in operationType)
            {
                var displayName = Enum.GetName(typeof(CurrencyTypeEnum), item.Key);
                lookupdata.Add(new LookupDto<int> { Id = item.Key, DisplayName = displayName });
            }

            return lookupdata;
        }
    }
}