using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;
using QuickSell.Shared;

namespace QuickSell.MovementHeaders
{
    public class MovementHeaderManager : DomainService
    {
        private readonly IMovementHeaderRepository _movementHeaderRepository;

        public MovementHeaderManager(IMovementHeaderRepository movementHeaderRepository)
        {
            _movementHeaderRepository = movementHeaderRepository;
        }

        public async Task<MovementHeader> CreateAsync(
              TypeEnum? typeCode, 
              int? receiptNo,
              Guid? customerCardID,
              decimal? firstAmount,
              decimal? discountAmount,
              decimal? vAtAmount,
              decimal? totalAmount,
              PaymentType? paymentType

        )
        {

            var movementHeader = new MovementHeader(
             GuidGenerator.Create(),
               typeCode, 
               receiptNo,
               customerCardID,
               firstAmount, 
               discountAmount, 
               vAtAmount, 
               totalAmount,
               paymentType
             );

            return await _movementHeaderRepository.InsertAsync(movementHeader);
        }

        public async Task<MovementHeader> UpdateAsync(
           Guid id,
          TypeEnum? typeCode, 
          int? receiptNo,
          Guid? customerCardID,
          decimal? firstAmount,
          decimal? discountAmount,
          decimal? vAtAmount,
          decimal? totalAmount, 
          PaymentType? paymentType, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _movementHeaderRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var movementHeader = await AsyncExecuter.FirstOrDefaultAsync(query);

                movementHeader.TypeCode=typeCode;
                 movementHeader.ReceiptNo=receiptNo;
                 movementHeader.CustomerCardID = customerCardID;
                 movementHeader.FirstAmount=firstAmount;
                 movementHeader.DiscountAmount=discountAmount;
                 movementHeader.VATAmount=vAtAmount;
                 movementHeader.TotalAmount=totalAmount;
                 movementHeader.PaymentType=paymentType;

         movementHeader.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _movementHeaderRepository.UpdateAsync(movementHeader);
        }

    }
}