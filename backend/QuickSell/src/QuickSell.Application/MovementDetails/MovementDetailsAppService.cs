
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
using QuickSell.MovementDetails;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.MovementDetails
{
    public class MovementDetailsAppService :ApplicationService, IMovementDetailsAppService
    {
        private readonly IMovementDetailsRepository _movementDetailsRepository;
        private readonly MovementDetailsManager _movementDetailsManager;
    
        public MovementDetailsAppService(IMovementDetailsRepository movementDetailsRepository,MovementDetailsManager movementDetailsManager)
        {
            _movementDetailsRepository = movementDetailsRepository;
            _movementDetailsManager= movementDetailsManager;
        }
    
    }
}