using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
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

        public async Task<MovementDetails> CreateAsync(
              string typeCode, 
              int? receiptNo, 
    
              int? quantity, 
    
              int? price, 
    
              int? discountRate, 
    
              int? discountAmount, 
    
              int? vAtRate, 
    
              int? vAtAmount, 
    
              Guid? stockCardId,
        )
        {

            var movementDetails = new MovementDetails(
             GuidGenerator.Create(),
               typeCode, 
               receiptNo, 
    
               quantity, 
    
               price, 
    
               discountRate, 
    
               discountAmount, 
    
               vAtRate, 
    
               vAtAmount, 
    
               stockCardId,
             );

            return await _movementDetailsRepository.InsertAsync(movementDetails);
        }

        public async Task<MovementDetails> UpdateAsync(
           Guid id,
          string typeCode, 
          int? receiptNo, 

          int? quantity, 

          int? price, 

          int? discountRate, 

          int? discountAmount, 

          int? vAtRate, 

          int? vAtAmount, 

          Guid? stockCardId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _movementDetailsRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var movementDetails = await AsyncExecuter.FirstOrDefaultAsync(query);

                movementDetails.TypeCode=typeCode;
                 movementDetails.ReceiptNo=receiptNo;
                 movementDetails.Quantity=quantity;
                 movementDetails.Price=price;
                 movementDetails.DiscountRate=discountRate;
                 movementDetails.DiscountAmount=discountAmount;
                 movementDetails.VATRate=vAtRate;
                 movementDetails.VATAmount=vAtAmount;
                movementDetails.StockCardId=stockCardId;

         movementDetails.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _movementDetailsRepository.UpdateAsync(movementDetails);
        }

    }
}