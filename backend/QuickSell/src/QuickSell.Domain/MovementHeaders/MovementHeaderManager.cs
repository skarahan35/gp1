using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

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
              string typeCode, 
              int? receiptNo,
              Guid? customerCardID,
              int? firstAmount, 
              int? discountAmount, 
              int? vAtAmount, 
              int? totalAmount
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
               totalAmount
             );

            return await _movementHeaderRepository.InsertAsync(movementHeader);
        }

        public async Task<MovementHeader> UpdateAsync(
           Guid id,
          string typeCode, 
          int? receiptNo,
          Guid? customerCardID,
          int? firstAmount, 
          int? discountAmount, 
          int? vAtAmount, 
          int? totalAmount, 
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

         movementHeader.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _movementHeaderRepository.UpdateAsync(movementHeader);
        }

    }
}