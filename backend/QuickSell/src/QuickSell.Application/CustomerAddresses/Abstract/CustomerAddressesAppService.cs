
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


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.CustomerAddresses
{
public abstract class CustomerAddressesAppService :ApplicationService, ICustomerAddressesAppService
{
    private readonly ICustomerAddressRepository _customerAddressRepository;
    private readonly CustomerAddressManager _customerAddressManager;

    public CustomerAddressesAppService(ICustomerAddressRepository customerAddressRepository,CustomerAddressManager customerAddressManager)
    {
        _customerAddressRepository = customerAddressRepository;
        _customerAddressManager= customerAddressManager;
    }

    
        [Authorize(QuickSellPermissions.CustomerAddresses.Create)]
    public virtual async Task<CustomerAddressDto> CreateAsync(CustomerAddressCreateDto input)
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
                input.CountryId,
            );
           
            
            return ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(customerAddress);
        }

        [Authorize(QuickSellPermissions.CustomerAddresses.Create)]
    public virtual async Task<PagedResultDto<CustomerAddressDto>> GetListAsync(GetCustomerAddressesInput input)
        {
            var totalCount = await _customerAddressRepository.GetCountAsync(input.FilterText, input.AddressCode, input.Road, input.Street, input.BuildingName);
            var items = await _customerAddressRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.AddressCode
            ,input.Road
            ,input.Street
            ,input.BuildingName
            ,input.BuildingNoMin
            ,input.BuildingNoMax 
            ,input.PostCodeMin
            ,input.PostCodeMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CustomerAddressDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< CustomerAddress>, List<CustomerAddressDto>>(items)
            };
        }


   

    public virtual async Task< CustomerAddressDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(await _customerAddressRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.CustomerAddresses.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _customerAddressRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.CustomerAddresses.Edit)]
     public virtual async Task<CustomerAddressDto> UpdateAsync(Guid id, CustomerAddressUpdateDto input)
         {
    
            var customerAddress = await _customerAddressManager.UpdateAsync(
                id,
                input.AddressCode,
                input.Road,
                input.Street,
                input.BuildingName,
                input.BuildingNo,
                input.PostCode,
                input.CustomerCardId,
                input.DistrictId,
                input.CityId,
                input.CountryId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(customerAddress);
         }
    



         

        
         

}
}