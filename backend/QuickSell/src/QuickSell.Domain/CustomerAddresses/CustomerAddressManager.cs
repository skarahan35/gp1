using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace QuickSell.CustomerAddresses
{
    public class CustomerAddressManager : DomainService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public CustomerAddressManager(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;
        }

        public async Task<CustomerAddress> CreateAsync(
              string code, 
              string road, 
              string street, 
              string buildingName, 
              int? buildingNo, 
              int? postCode, 
              Guid? customerCardId,
              Guid? districtId,
              Guid? cityId,
              Guid? countryId
        )
        {

            var customerAddress = new CustomerAddress(
             GuidGenerator.Create(),
               code, 
               road, 
               street, 
               buildingName, 
               buildingNo, 
               postCode, 
               customerCardId,
               districtId,
               cityId,
               countryId
             );

            return await _customerAddressRepository.InsertAsync(customerAddress);
        }

        public async Task<CustomerAddress> UpdateAsync(
           Guid id,
          string code, 
          string road, 
          string street, 
          string buildingName, 
          int? buildingNo, 

          int? postCode, 

          Guid? customerCardId,
          Guid? districtId,
          Guid? cityId,
          Guid? countryId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _customerAddressRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var customerAddress = await AsyncExecuter.FirstOrDefaultAsync(query);

                customerAddress.Code=code;
                customerAddress.Road=road;
                customerAddress.Street=street;
                customerAddress.BuildingName=buildingName;
                 customerAddress.BuildingNo=buildingNo;
                 customerAddress.PostCode=postCode;
                customerAddress.CustomerCardId=customerCardId;
                customerAddress.DistrictId=districtId;
                customerAddress.CityId=cityId;
                customerAddress.CountryId=countryId;

         customerAddress.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _customerAddressRepository.UpdateAsync(customerAddress);
        }

    }
}