
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

namespace QuickSell.CustomerCards
{
    public class CustomerCardsAppService :ApplicationService, ICustomerCardsAppService
    {
        private readonly ICustomerCardRepository _customerCardRepository;
        private readonly CustomerCardManager _customerCardManager;
        private readonly IDataFilter _dataFilter;
    
        public CustomerCardsAppService(ICustomerCardRepository customerCardRepository,
                                       CustomerCardManager customerCardManager,
                                       IDataFilter dataFilter)
        {
            _customerCardRepository = customerCardRepository;
            _customerCardManager= customerCardManager;
            _dataFilter = dataFilter;
        }

        public async Task<LoadResult> GetListCustomerCard(DataSourceLoadOptions loadOptions)
        {
            var getCustomerCard = await _customerCardRepository.GetQueryableAsync();

            var getJoinedData = from cstmrcrd in getCustomerCard
                                select new DxCustomerCardLookupDto
                                {
                                    Id = cstmrcrd.Id,
                                    Code = cstmrcrd.Code,
                                    Name = cstmrcrd.Name,
                                    CustomerTypeID = cstmrcrd.CustomerTypeID,
                                    CustomerGroupID = cstmrcrd.CustomerGroupID,
                                    TaxOffice = cstmrcrd.TaxOffice,
                                    TaxNo = cstmrcrd.TaxNo,
                                    TCNumber = cstmrcrd.TCNumber,
                                    AuthorizedPerson = cstmrcrd.AuthorizedPerson,
                                    EMail = cstmrcrd.EMail,
                                    RiskLimit = cstmrcrd.RiskLimit
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCustomerCardLookupDto?> GetCustomerCardByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCustomerCard = (await _customerCardRepository.GetQueryableAsync());
                var customerCard = (from cstmrcrd in getCustomerCard
                                    where cstmrcrd.Id == id
                                 select new DxCustomerCardLookupDto
                                 {
                                     Id = cstmrcrd.Id,
                                     Code = cstmrcrd.Code,
                                     Name = cstmrcrd.Name,
                                     CustomerTypeID = cstmrcrd.CustomerTypeID,
                                     CustomerGroupID = cstmrcrd.CustomerGroupID,
                                     TaxOffice = cstmrcrd.TaxOffice,
                                     TaxNo = cstmrcrd.TaxNo,
                                     TCNumber = cstmrcrd.TCNumber,
                                     AuthorizedPerson = cstmrcrd.AuthorizedPerson,
                                     EMail = cstmrcrd.EMail,
                                     RiskLimit = cstmrcrd.RiskLimit
                                 }).FirstOrDefault();
                return customerCard;
            }
        }
        public async Task<CustomerCardDto> AddCustomerCard(CustomerCardDto input)
        {
            var customerCard = await _customerCardManager.CreateAsync(
              input.Code,
              input.Name,
              input.CustomerTypeID,
              input.CustomerGroupID,
              input.TaxOffice,
              input.TCNumber,
              input.AuthorizedPerson,
              input.EMail,
              input.TaxNo,
              input.RiskLimit
          );
            return ObjectMapper.Map<CustomerCard, CustomerCardDto>(customerCard);
        }
        public async Task<CustomerCardDto> UpdateCustomerCard(Guid id, IDictionary<string, object> input)
        {
            var customerCard = await _customerCardRepository.GetAsync(id);
            var updated = await DevExtremeUpdate.Update(customerCard, input);
            await _customerCardRepository.UpdateAsync(updated);
            return ObjectMapper.Map<CustomerCard, CustomerCardDto>(updated);
        }
        public async Task DeleteCustomerCard(Guid id)
        {
            await _customerCardRepository.DeleteAsync(id);
        }
    }
}