
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
using QuickSell.Tools;
using Volo.Abp.Data;

namespace QuickSell.MovementDetails
{
    public class MovementDetailsAppService :ApplicationService, IMovementDetailsAppService
    {
        private readonly IMovementDetailsRepository _movementDetailsRepository;
        private readonly MovementDetailsManager _movementDetailsManager;
        private readonly IDataFilter _dataFilter;
    
        public MovementDetailsAppService(IMovementDetailsRepository movementDetailsRepository,
                                         MovementDetailsManager movementDetailsManager,
                                         IDataFilter dataFilter)
        {
            _movementDetailsRepository = movementDetailsRepository;
            _movementDetailsManager= movementDetailsManager;
            _dataFilter = dataFilter;
        }
        public async Task<LoadResult> GetListMovementDetail(DataSourceLoadOptions loadOptions)
        {
            var getMovementDetail = await _movementDetailsRepository.GetQueryableAsync();

            var getJoinedData = from mvmnt in getMovementDetail
                                select new DxMovementDetailLookupDto
                                {
                                    Id = mvmnt.Id,
                                    TypeCode = mvmnt.TypeCode,
                                    ReceiptNo = mvmnt.ReceiptNo,
                                    StockCardID = mvmnt.StockCardID,
                                    Quantity = mvmnt.Quantity,
                                    Price = mvmnt.Price,
                                    DiscountRate = mvmnt.DiscountRate,
                                    DiscountAmount = mvmnt.DiscountAmount,
                                    VATRate = mvmnt.VATRate,
                                    VATAmount = mvmnt.VATAmount,
                                    HeaderId = mvmnt.HeaderId
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxMovementDetailLookupDto?> GetMovementDetailByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getMovementDetail = (await _movementDetailsRepository.GetQueryableAsync());
                var movementDetail = (from mvmnt in getMovementDetail
                                      where mvmnt.Id == id
                                  select new DxMovementDetailLookupDto
                                  {
                                      Id = mvmnt.Id,
                                      TypeCode = mvmnt.TypeCode,
                                      ReceiptNo = mvmnt.ReceiptNo,
                                      StockCardID = mvmnt.StockCardID,
                                      Quantity = mvmnt.Quantity,
                                      Price = mvmnt.Price,
                                      DiscountRate = mvmnt.DiscountRate,
                                      DiscountAmount = mvmnt.DiscountAmount,
                                      VATRate = mvmnt.VATRate,
                                      VATAmount = mvmnt.VATAmount,
                                      HeaderId = mvmnt.HeaderId
                                  }).FirstOrDefault();
                return movementDetail;
            }
        }
        public async Task<MovementDetailDto> AddMovementDetail(MovementDetailDto input)
        {
            var movementDetail = await _movementDetailsManager.CreateAsync(
              input.TypeCode,
              input.ReceiptNo,
              input.StockCardID,
              input.Quantity,
              input.Price,
              input.DiscountRate,
              input.DiscountAmount,
              input.VATRate,
              input.VATAmount,
              input.HeaderId
          );
            return ObjectMapper.Map<MovementDetail, MovementDetailDto>(movementDetail);
        }
        public async Task<MovementDetailDto> UpdateMovementDetail(Guid id, IDictionary<string, object> input)
        {
            var movementDetail = await _movementDetailsRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(movementDetail, input);
            await _movementDetailsRepository.UpdateAsync(updated);
            return ObjectMapper.Map<MovementDetail, MovementDetailDto>(updated);
        }
        public async Task<MovementDetailDto> UpdateMovementDetails(Guid id, MovementDetailDto input)
        {
            var movementDetail = await _movementDetailsManager.UpdateAsync(
                id,
                input.TypeCode,
                input.ReceiptNo,
                input.StockCardID,
                input.Quantity,
                input.Price,
                input.DiscountRate,
                input.DiscountAmount,
                input.VATRate,
                input.VATAmount,
                input.HeaderId
            );
            await _movementDetailsRepository.UpdateAsync(movementDetail);

            return ObjectMapper.Map<MovementDetail, MovementDetailDto>(movementDetail);
        }
        public async Task DeleteMovementDetail(Guid id)
        {
            await _movementDetailsRepository.DeleteAsync(id);
        }
        public async Task<List<MovementDetail>> GetHeaderId(Guid id)
        {
            var qry = await _movementDetailsRepository.GetQueryableAsync();
            var result = qry.Where(x => x.HeaderId == id).ToList();

            return result;
        }
    }
}