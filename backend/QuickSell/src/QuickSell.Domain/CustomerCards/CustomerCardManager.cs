using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.CustomerCards
{
    public class CustomerCardManager : DomainService
    {
        private readonly ICustomerCardRepository _customerCardRepository;

        public CustomerCardManager(ICustomerCardRepository customerCardRepository)
        {
            _customerCardRepository = customerCardRepository;
        }

        public async Task<CustomerCard> CreateAsync(
              string code, 
              string name, 
              Guid? customerTypeID,
              Guid? customerGroupID,
              string taxOffice, 
              string phoneNumber, 
              string authorizedPerson, 
              string eMail, 
              string? taxNo, 
              decimal? riskLimit
        )
        {

            var customerCard = new CustomerCard(
             GuidGenerator.Create(),
               code, 
               name, 
               customerTypeID,
               customerGroupID,
               taxOffice, 
               phoneNumber, 
               authorizedPerson, 
               eMail, 
               taxNo, 
               riskLimit
             );

            return await _customerCardRepository.InsertAsync(customerCard);
        }

        public async Task<CustomerCard> UpdateAsync(
           Guid id,
          string code, 
          string name,
          Guid? customerTypeID,
          Guid? customerGroupID,
          string taxOffice, 
          string phoneNumber, 
          string authorizedPerson, 
          string eMail,
          string? taxNo, 

          decimal? riskLimit,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _customerCardRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var customerCard = await AsyncExecuter.FirstOrDefaultAsync(query);

                customerCard.Code=code;
                customerCard.Name=name;
                customerCard.CustomerTypeID=customerTypeID;
                customerCard.CustomerGroupID=customerGroupID;
                customerCard.TaxOffice=taxOffice;
                customerCard.PhoneNumber =phoneNumber;
                customerCard.AuthorizedPerson=authorizedPerson;
                customerCard.EMail=eMail;
                 customerCard.TaxNo=taxNo;
                 customerCard.RiskLimit=riskLimit;

         customerCard.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _customerCardRepository.UpdateAsync(customerCard);
        }

    }
}