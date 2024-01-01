
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp;
using Volo.Abp.Application.Services;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using Volo.Abp.Data;
using QuickSell.MovementDetails;
using Newtonsoft.Json;
using Volo.Abp.ObjectMapping;
using QuickSell.Shared;

namespace QuickSell.MovementHeaders
{
    public class MovementHeadersAppService :ApplicationService, IMovementHeadersAppService
    {
        private readonly IMovementHeaderRepository _movementHeaderRepository;
        private readonly MovementHeaderManager _movementHeaderManager;
        private readonly IMovementDetailsRepository _movementDetailRepository;
        private readonly MovementDetailsManager _movementDetailsManager;
        private readonly MovementDetailsAppService _movementDetailsAppService;
        private readonly IDataFilter _dataFilter;
    
        public MovementHeadersAppService(IMovementHeaderRepository movementHeaderRepository,
                                         MovementHeaderManager movementHeaderManager,
                                         IDataFilter dataFilter,
                                         IMovementDetailsRepository movementDetailRepository,
                                         MovementDetailsManager movementDetailsManager,
                                         MovementDetailsAppService movementDetailsAppService)
        {
            _movementHeaderRepository = movementHeaderRepository;
            _movementHeaderManager= movementHeaderManager;
            _dataFilter= dataFilter;
            _movementDetailRepository= movementDetailRepository;
            _movementDetailsManager = movementDetailsManager;
            _movementDetailsAppService = movementDetailsAppService;
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
                                    AddressID= mvmnthdr.AddressID,
                                    PaymentType= mvmnthdr.PaymentType,
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
                                          AddressID = mvmnthdr.AddressID,
                                          PaymentType = mvmnthdr.PaymentType,
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
              input.TotalAmount,
              input.AddressID,
              input.PaymentType
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
        public async Task<MovementHeaderDto> UpdateMovementHeaders(Guid id, MovementHeaderDto input)
        {
            var movementHeader = await _movementHeaderManager.UpdateAsync(
                id,
                input.TypeCode,
                input.ReceiptNo,
                input.CustomerCardID,
                input.FirstAmount,
                input.DiscountAmount,
                input.VATAmount,
                input.TotalAmount,
                input.AddressID,
                input.PaymentType
            );
            await _movementHeaderRepository.UpdateAsync(movementHeader);

            return ObjectMapper.Map<MovementHeader, MovementHeaderDto>(movementHeader);
        }
        public async Task DeleteMovementHeader(Guid id)
        {
            await _movementHeaderRepository.DeleteAsync(id);
        }
        public static MovementHeader MapToEntityHeader(MovementHeaderDto headerDto)
        {

            var headerEntity = new MovementHeader
            {
                // Özellikleri kopyalama
                TypeCode = headerDto.TypeCode,
                ReceiptNo = headerDto.ReceiptNo,
                CustomerCardID = headerDto.CustomerCardID,
                FirstAmount = headerDto.FirstAmount,
                DiscountAmount = headerDto.DiscountAmount,
                VATAmount = headerDto.VATAmount,
                TotalAmount = headerDto.TotalAmount,
                AddressID = headerDto.AddressID,
                PaymentType = headerDto.PaymentType,
            };

            return headerEntity;
        }
        //public static MovementDetail MapToEntityDetail(MovementDetailDto detailDto)
        //{

        //    var detailEntity = new MovementDetail
        //    {
        //        // Özellikleri kopyalama
        //        TypeCode = detailDto.TypeCode,
        //        ReceiptNo = detailDto.ReceiptNo,
        //        StockCardID = detailDto.StockCardID,
        //        Quantity = detailDto.Quantity,
        //        Price = detailDto.Price,
        //        DiscountRate = detailDto.DiscountRate,
        //        DiscountAmount = detailDto.DiscountAmount,
        //        VATRate = detailDto.VATRate,
        //        VATAmount = detailDto.VATAmount,
        //        HeaderId = detailDto.HeaderId
        //    };

        //    return detailEntity;
        //}
        public async Task SaveMovement(MovementDTO input)
        {
            var headerId = Guid.Empty;
            if (input.Header.Id == Guid.Empty)
            {
                var savedHeader = await AddMovementHeader(input.Header);
                headerId = savedHeader.Id;
                //var headerEntity = MapToEntityHeader(input.Header);
                //var savedHeader = await _movementHeaderRepository.InsertAsync(headerEntity);
            }
            else
            {
                var savedHeader = await UpdateMovementHeaders(input.Header.Id,input.Header);
                headerId = savedHeader.Id;
            }
            
            //unitOfWork.SaveChanges();

            // Kaydedilen MovementHeader'ýn ID'sini al
            

            // MovementDetails'ý alýnan MovementHeaderId ile kaydet
            foreach (var detail in input.Details)
            {
                  MovementDetailDto movementDetail = new MovementDetailDto();
                  JsonConvert.PopulateObject(detail.Data.ToString() ?? string.Empty, movementDetail);
                  movementDetail.HeaderId = headerId;
                  if (detail.Type == "insert")
                  {
                      //MovementDetailDto movementDetail = new MovementDetailDto();
                      //JsonConvert.PopulateObject(detail.Data.ToString() ?? string.Empty, movementDetail);
                      //movementDetail.HeaderId = headerId;
                      await _movementDetailsAppService.AddMovementDetail(movementDetail);
                      //var detailEntity = MapToEntityDetail(movementDetail);
                      //await _movementDetailRepository.InsertAsync(detailEntity);
                  }
                  else if (detail.Type == "remove")
                  {
                      var qry = await _movementDetailRepository.GetQueryableAsync();
                      qry = qry.Where(x=> x.HeaderId == headerId);
                      await _movementDetailsAppService.DeleteMovementDetail(movementDetail.Id); 
                      //var detailEntity = MapToEntityDetail(movementDetail);
                      //await _movementDetailRepository.DeleteAsync(detailEntity);
                  }
                  else if (detail.Type == "update")
                  {
                      await _movementDetailsAppService.UpdateMovementDetails(movementDetail.Id, movementDetail);

                      
                      //await _movementDetailsAppService.DeleteMovementDetail(headerId);
                      //await _movementDetailsAppService.AddMovementDetail(movementDetail);
                  }
            }
  
        }
        public async Task<List<LookupDto<int>>> PaymentTypeLookup()
        {
            var operationType = typeof(PaymentType).GetEnumValues().Cast<object>().ToDictionary(o => (int)o, v => v.ToString());
            var lookupdata = new List<LookupDto<int>>();

            foreach (var item in operationType)
            {
                var displayName = Enum.GetName(typeof(PaymentType), item.Key);
                lookupdata.Add(new LookupDto<int> { Id = item.Key, DisplayName = displayName });
            }

            return lookupdata;
        }
    }
}