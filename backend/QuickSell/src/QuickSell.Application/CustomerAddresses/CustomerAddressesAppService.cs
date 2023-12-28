
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
using QuickSell.CustomerAddresses;
using QuickSell.Shared;
using Volo.Abp.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using QuickSell.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.ObjectMapping;

namespace QuickSell.CustomerAddresses
{
    public class CustomerAddressesAppService :ApplicationService, ICustomerAddressesAppService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressManager _customerAddressManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;
    
        public CustomerAddressesAppService(ICustomerAddressRepository customerAddressRepository,
                                           CustomerAddressManager customerAddressManager,
                                           IDataFilter dataFilter,
                                           IStringLocalizer<QuickSellResource> localizer)
        {
            _customerAddressRepository = customerAddressRepository;
            _customerAddressManager= customerAddressManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }

        public async Task<LoadResult> GetListCustomerAddress(DataSourceLoadOptions loadOptions)
        {
            var getCustomerAddress = await _customerAddressRepository.GetQueryableAsync();

            var getJoinedData = from cstmraddrss in getCustomerAddress
                                select new DxCustomerAddressLookupDto
                                {
                                    Id = cstmraddrss.Id,
                                    Code = cstmraddrss.Code,
                                    Road = cstmraddrss.Road,
                                    Street = cstmraddrss.Street,
                                    BuildingName = cstmraddrss.BuildingName,
                                    BuildingNo = cstmraddrss.BuildingNo,
                                    PostCode = cstmraddrss.PostCode,
                                    CustomerCardId = cstmraddrss.CustomerCardId,
                                    DistrictId = cstmraddrss.DistrictId,
                                    CityId = cstmraddrss.CityId,
                                    CountryId = cstmraddrss.CountryId
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxCustomerAddressLookupDto?> GetCustomerAddressByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getCustomerAddress = (await _customerAddressRepository.GetQueryableAsync());
                var customerAddress = (from cstmraddrss in getCustomerAddress
                                       where cstmraddrss.Id == id
                                     select new DxCustomerAddressLookupDto
                                     {
                                         Id = cstmraddrss.Id,
                                         Code = cstmraddrss.Code,
                                         Road = cstmraddrss.Road,
                                         Street = cstmraddrss.Street,
                                         BuildingName = cstmraddrss.BuildingName,
                                         BuildingNo = cstmraddrss.BuildingNo,
                                         PostCode = cstmraddrss.PostCode,
                                         CustomerCardId = cstmraddrss.CustomerCardId,
                                         DistrictId = cstmraddrss.DistrictId,
                                         CityId = cstmraddrss.CityId,
                                         CountryId = cstmraddrss.CountryId
                                     }).FirstOrDefault();
                return customerAddress;
            }
        }
        public async Task CustomerAddressValidation(CustomerAddressDto input)
        {
            var qry = await _customerAddressRepository.GetQueryableAsync();
            await Validation<CustomerAddress, QuickSellResource>.CodeControl(input, qry.Where(x => x.Code == input.Code), _localizer);
        }
        public async Task<CustomerAddressDto> AddCustomerAddress(CustomerAddressDto input)
        {
            await CustomerAddressValidation(input);
            var customerAddress = await _customerAddressManager.CreateAsync(
              input.Code,
              input.Road,
              input.Street,
              input.BuildingName,
              input.BuildingNo,
              input.PostCode,
              input.CustomerCardId,
              input.DistrictId,
              input.CityId,
              input.CountryId
          );
            return ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(customerAddress);
        }
        public async Task<CustomerAddressDto> UpdateCustomerAddress(Guid id, IDictionary<string, object> input)
        {
            var customerAddress = await _customerAddressRepository.GetAsync(id);
            var customerAddressDto = ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(customerAddress);
            await DevExtremeUpdate.Update(customerAddressDto, input);

            return await UpdateCustomerAddress(customerAddressDto.Id, customerAddressDto);
        }
        public async Task<CustomerAddressDto> UpdateCustomerAddress(Guid id, CustomerAddressDto input)
        {
            await CustomerAddressValidation(input);
            var customerAddress = await _customerAddressManager.UpdateAsync(
                id,
                input.Code,
                input.Road,
                input.Street,
                input.BuildingName,
                input.BuildingNo,
                input.PostCode,
                input.CustomerCardId,
                input.DistrictId,
                input.CityId,
                input.CountryId
            );
            await _customerAddressRepository.UpdateAsync(customerAddress);

            return ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(customerAddress);
        }
        public async Task DeleteCustomerAddress(Guid id)
        {
            await _customerAddressRepository.DeleteAsync(id);
        }

    }
}