
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

namespace QuickSell.CustomerAddresses
{
    public class CustomerAddressesAppService :ApplicationService, ICustomerAddressesAppService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressManager _customerAddressManager;
        private readonly IDataFilter _dataFilter;
    
        public CustomerAddressesAppService(ICustomerAddressRepository customerAddressRepository,
                                           CustomerAddressManager customerAddressManager,
                                           IDataFilter dataFilter)
        {
            _customerAddressRepository = customerAddressRepository;
            _customerAddressManager= customerAddressManager;
            _dataFilter = dataFilter;
        }

        public async Task<LoadResult> GetListCustomerAddress(DataSourceLoadOptions loadOptions)
        {
            var getCustomerAddress = await _customerAddressRepository.GetQueryableAsync();

            var getJoinedData = from cstmraddrss in getCustomerAddress
                                select new DxCustomerAddressLookupDto
                                {
                                    Id = cstmraddrss.Id,
                                    AddressCode = cstmraddrss.AddressCode,
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
                                         AddressCode = cstmraddrss.AddressCode,
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
        public async Task<CustomerAddressDto> AddCustomerAddress(CustomerAddressDto input)
        {
            var customerAddress = await _customerAddressManager.CreateAsync(
              input.AddressCode,
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
            var updated = await DevExtremeUpdate.Update(customerAddress, input);
            await _customerAddressRepository.UpdateAsync(updated);
            return ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(updated);
        }
        public async Task DeleteCustomerAddress(Guid id)
        {
            await _customerAddressRepository.DeleteAsync(id);
        }

    }
}