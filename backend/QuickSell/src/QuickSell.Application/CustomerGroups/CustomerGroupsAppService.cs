
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
using QuickSell.CustomerGroups;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.CustomerGroups
{
    public class CustomerGroupsAppService :ApplicationService, ICustomerGroupsAppService
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly CustomerGroupManager _customerGroupManager;
    
        public CustomerGroupsAppService(ICustomerGroupRepository customerGroupRepository,CustomerGroupManager customerGroupManager)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupManager= customerGroupManager;
        }
    
        
    }
}