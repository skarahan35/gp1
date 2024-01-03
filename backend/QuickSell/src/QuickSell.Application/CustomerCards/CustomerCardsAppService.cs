
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using QuickSell.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.ObjectMapping;

namespace QuickSell.CustomerCards
{
    public class CustomerCardsAppService :ApplicationService, ICustomerCardsAppService
    {
        private readonly ICustomerCardRepository _customerCardRepository;
        private readonly CustomerCardManager _customerCardManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;
    
        public CustomerCardsAppService(ICustomerCardRepository customerCardRepository,
                                       CustomerCardManager customerCardManager,
                                       IDataFilter dataFilter,
                                       IStringLocalizer<QuickSellResource> localizer)
        {
            _customerCardRepository = customerCardRepository;
            _customerCardManager= customerCardManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
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
                                    PhoneNumber = cstmrcrd.PhoneNumber,
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
                                     PhoneNumber = cstmrcrd.PhoneNumber,
                                     AuthorizedPerson = cstmrcrd.AuthorizedPerson,
                                     EMail = cstmrcrd.EMail,
                                     RiskLimit = cstmrcrd.RiskLimit
                                 }).FirstOrDefault();
                return customerCard;
            }
        }
        public async Task CustomerCardValidation(CustomerCardDto input)
        {
            var qry = await _customerCardRepository.GetQueryableAsync();
            await Validation<CustomerCard, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
        }
        public async Task<CustomerCardDto> AddCustomerCard(CustomerCardDto input)
        {
            await CustomerCardValidation(input);
            var customerCard = await _customerCardManager.CreateAsync(
              input.Code,
              input.Name,
              input.CustomerTypeID,
              input.CustomerGroupID,
              input.TaxOffice,
              input.PhoneNumber,
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
            var customerCardDto = ObjectMapper.Map<CustomerCard, CustomerCardDto>(customerCard);
            await DevExtremeUpdate.Update(customerCardDto, input);

            return await UpdateCustomerCard(customerCardDto.Id, customerCardDto);
        }
        public async Task<CustomerCardDto> UpdateCustomerCard(Guid id, CustomerCardDto input)
        {
            await CustomerCardValidation(input);
            var customerCard = await _customerCardManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.CustomerTypeID,
                input.CustomerGroupID,
                input.TaxOffice,
                input.PhoneNumber,
                input.AuthorizedPerson,
                input.EMail,
                input.TaxNo,
                input.RiskLimit
            );
            await _customerCardRepository.UpdateAsync(customerCard);

            return ObjectMapper.Map<CustomerCard, CustomerCardDto>(customerCard);
        }
        public async Task DeleteCustomerCard(Guid id)
        {
            await _customerCardRepository.DeleteAsync(id);
        }
    }
}