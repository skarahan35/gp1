
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

namespace QuickSell.StockCards
{
    public class StockCardsAppService :ApplicationService, IStockCardsAppService
    {
        private readonly IStockCardRepository _stockCardRepository;
        private readonly StockCardManager _stockCardManager;
        private readonly IDataFilter _dataFilter;

        public StockCardsAppService(IStockCardRepository stockCardRepository,
                                    StockCardManager stockCardManager,
                                    IDataFilter dataFilter)
        {
            _stockCardRepository = stockCardRepository;
            _stockCardManager= stockCardManager;
            _dataFilter = dataFilter;
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
        public async Task<StockCardDto> AddStockCard(StockCardDto input)
        {
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
            var updated = await DevExtremeUpdate.Update(stockCard, input);
            await _stockCardRepository.UpdateAsync(updated);
            return ObjectMapper.Map<StockCard, StockCardDto>(updated);
        }
        public async Task DeleteStockCard(Guid id)
        {
            await _stockCardRepository.DeleteAsync(id);
        }
    }
}