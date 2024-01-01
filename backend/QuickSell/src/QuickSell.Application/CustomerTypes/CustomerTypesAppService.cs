using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using System.Linq;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using QuickSell.Shared;
using Microsoft.Extensions.Localization;
using QuickSell.Localization;

namespace QuickSell.CustomerTypes
{
    public class CustomerTypesAppService :ApplicationService, ICustomerTypesAppService
    {
        private readonly ICustomerTypeRepository _customerTypeRepository;
        private readonly CustomerTypeManager _customerTypeManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public CustomerTypesAppService(ICustomerTypeRepository customerTypeRepository,CustomerTypeManager customerTypeManager,IDataFilter dataFilter, IStringLocalizer<QuickSellResource> localizer )
        {
            _customerTypeRepository = customerTypeRepository;
            _customerTypeManager= customerTypeManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }

        public async Task<LoadResult> GetListCustomerType(DataSourceLoadOptions loadOptions)
        {
            var getCustomerType = await _customerTypeRepository.GetQueryableAsync();

            var getJoinedData = from cstmrtyp in getCustomerType
                                select new DxCustomerTypeLookupDto
                                {
                                    Id = cstmrtyp.Id,
                                    Code = cstmrtyp.Code,
                                    Name = cstmrtyp.Name
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCustomerTypeLookupDto?> GetCustomerTypeByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCustomerType = (await _customerTypeRepository.GetQueryableAsync());
                var customerTypes = (from cstmrtyp in getCustomerType
                                  where cstmrtyp.Id == id
                                  select new DxCustomerTypeLookupDto
                                  {
                                      Id = cstmrtyp.Id,
                                      Code = cstmrtyp.Code,
                                      Name = cstmrtyp.Name
                                  }).FirstOrDefault();
                return customerTypes;
            }
        }
        public async Task CustomertTypeValidation(CustomerTypeDto input)
        {
            var qry = await _customerTypeRepository.GetQueryableAsync();
            await Validation<CustomerType, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
            await Validation<CustomerType, QuickSellResource>.NameControl(input, qry.Where(x => x.Name == input.Name), _localizer);
        }
        public async Task<CustomerTypeDto> AddCustomerType(CustomerTypeDto input)
        {
            await CustomertTypeValidation(input);
            var customerType = await _customerTypeManager.CreateAsync(
              input.Code,
              input.Name
          );
            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(customerType);
        }
        public async Task<CustomerTypeDto> UpdateCustomerType(Guid id, IDictionary<string, object> input)
        {
            var customerType = await _customerTypeRepository.GetAsync(id);
            var customerTypeDto = ObjectMapper.Map<CustomerType, CustomerTypeDto>(customerType);
            await DevExtremeUpdate.Update(customerTypeDto, input);

            return await UpdateCustomerType(customerTypeDto.Id, customerTypeDto);
        }
        public async Task<CustomerTypeDto> UpdateCustomerType(Guid id, CustomerTypeDto input)
        {
            await CustomertTypeValidation(input);
            var customerType = await _customerTypeManager.UpdateAsync(
                id,
                input.Code,
                input.Name
            );
            await _customerTypeRepository.UpdateAsync(customerType);

            return ObjectMapper.Map<CustomerType, CustomerTypeDto>(customerType);
        }
        public async Task DeleteCustomerType(Guid id)
        {
            await _customerTypeRepository.DeleteAsync(id);
        }
    }
}