
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


namespace QuickSell.CustomerAddresses
{
    public class CustomerAddressesAppService :ApplicationService, ICustomerAddressesAppService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressManager _customerAddressManager;
    
        public CustomerAddressesAppService(ICustomerAddressRepository customerAddressRepository,CustomerAddressManager customerAddressManager)
        {
            _customerAddressRepository = customerAddressRepository;
            _customerAddressManager= customerAddressManager;
        }
    
        
    
    }
}