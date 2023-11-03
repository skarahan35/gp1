using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.MovementDetails
{
    public class MovementDetailsManager : DomainService
    {
        private readonly IMovementDetailsRepository _movementDetailsRepository;

        public MovementDetailsManager(IMovementDetailsRepository movementDetailsRepository)
        {
            _movementDetailsRepository = movementDetailsRepository;
        }

        public async Task<MovementDetail> CreateAsync(
              string? typeCode, 
              int? receiptNo,
              Guid? stockCardID,
              decimal? quantity,
              decimal? price,
              decimal? discountRate,
              decimal? discountAmount,
              decimal? vAtRate,
              decimal? vAtAmount 
              
        )
        {

            var movementDetail = new MovementDetail(
             GuidGenerator.Create(),
               typeCode, 
               receiptNo,
               stockCardID,
               quantity, 
               price, 
               discountRate, 
               discountAmount, 
               vAtRate, 
               vAtAmount
             );

            return await _movementDetailsRepository.InsertAsync(movementDetail);
        }

        public async Task<MovementDetail> UpdateAsync(
           Guid id,
          string? typeCode, 
          int? receiptNo,
          Guid? stockCardID,
          decimal? quantity,
          decimal? price,
          decimal? discountRate,
          decimal? discountAmount,
          decimal? vAtRate,
          decimal? vAtAmount, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _movementDetailsRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var movementDetails = await AsyncExecuter.FirstOrDefaultAsync(query);

                movementDetails.TypeCode=typeCode;
                 movementDetails.ReceiptNo=receiptNo;
                movementDetails.StockCardID = stockCardID;
                movementDetails.Quantity=quantity;
                 movementDetails.Price=price;
                 movementDetails.DiscountRate=discountRate;
                 movementDetails.DiscountAmount=discountAmount;
                 movementDetails.VATRate=vAtRate;
                 movementDetails.VATAmount=vAtAmount;

         movementDetails.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _movementDetailsRepository.UpdateAsync(movementDetails);
        }

    }
}