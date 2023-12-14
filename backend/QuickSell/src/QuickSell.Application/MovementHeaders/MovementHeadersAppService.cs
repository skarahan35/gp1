
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickSell.Permissions;
using QuickSell.MovementHeaders;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;

namespace QuickSell.MovementHeaders
{
    public class MovementHeadersAppService :ApplicationService, IMovementHeadersAppService
    {
        private readonly IMovementHeaderRepository _movementHeaderRepository;
        private readonly MovementHeaderManager _movementHeaderManager;
        private readonly IDataFilter _dataFilter;
    
        public MovementHeadersAppService(IMovementHeaderRepository movementHeaderRepository,
                                         MovementHeaderManager movementHeaderManager,
                                         IDataFilter dataFilter)
        {
            _movementHeaderRepository = movementHeaderRepository;
            _movementHeaderManager= movementHeaderManager;
            _dataFilter= dataFilter;
        }

        public async Task<LoadResult> GetListMovementHeader(DataSourceLoadOptions loadOptions)
        {
            var getMovementHeader = await _movementHeaderRepository.GetQueryableAsync();

            var getJoinedData = from mvmnthdr in getMovementHeader
                                select new DxMovementHeaderLookupDto
                                {
                                    Id = mvmnthdr.Id,
                                    TypeCode = mvmnthdr.TypeCode,
                                    ReceiptNo = mvmnthdr.ReceiptNo,
                                    CustomerCardID = mvmnthdr.CustomerCardID,
                                    FirstAmount = mvmnthdr.FirstAmount,
                                    DiscountAmount = mvmnthdr.DiscountAmount,
                                    VATAmount = mvmnthdr.VATAmount,
                                    TotalAmount= mvmnthdr.TotalAmount,
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxMovementHeaderLookupDto?> GetMovementHeaderByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getMovementHeader = (await _movementHeaderRepository.GetQueryableAsync());
                var movementDetail = (from mvmnthdr in getMovementHeader
                                      where mvmnthdr.Id == id
                                      select new DxMovementHeaderLookupDto
                                      {
                                          Id = mvmnthdr.Id,
                                          TypeCode = mvmnthdr.TypeCode,
                                          ReceiptNo = mvmnthdr.ReceiptNo,
                                          CustomerCardID = mvmnthdr.CustomerCardID,
                                          FirstAmount = mvmnthdr.FirstAmount,
                                          DiscountAmount = mvmnthdr.DiscountAmount,
                                          VATAmount = mvmnthdr.VATAmount,
                                          TotalAmount = mvmnthdr.TotalAmount,
                                      }).FirstOrDefault();
                return movementDetail;
            }
        }
        public async Task<MovementHeaderDto> AddMovementHeader(MovementHeaderDto input)
        {
            var movementHeader = await _movementHeaderManager.CreateAsync(
              input.TypeCode,
              input.ReceiptNo,
              input.CustomerCardID,
              input.FirstAmount,
              input.DiscountAmount,
              input.VATAmount,
              input.TotalAmount
          );
            return ObjectMapper.Map<MovementHeader, MovementHeaderDto>(movementHeader);
        }
        public async Task<MovementHeaderDto> UpdateMovementHeader(Guid id, IDictionary<string, object> input)
        {
            var movementHeader = await _movementHeaderRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(movementHeader, input);
            await _movementHeaderRepository.UpdateAsync(updated);
            return ObjectMapper.Map<MovementHeader, MovementHeaderDto>(updated);
        }
        public async Task DeleteMovementHeader(Guid id)
        {
            await _movementHeaderRepository.DeleteAsync(id);
        }
    }
}