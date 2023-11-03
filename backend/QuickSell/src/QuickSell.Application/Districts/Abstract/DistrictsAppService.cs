
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
using QuickSell.Districts;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.Districts
{
public abstract class DistrictsAppService :ApplicationService, IDistrictsAppService
{
    private readonly IDistrictRepository _districtRepository;
    private readonly DistrictManager _districtManager;

    public DistrictsAppService(IDistrictRepository districtRepository,DistrictManager districtManager)
    {
        _districtRepository = districtRepository;
        _districtManager= districtManager;
    }

    
        [Authorize(QuickSellPermissions.Districts.Create)]
    public virtual async Task<DistrictDto> CreateAsync(DistrictCreateDto input)
        {

            var district = await _districtManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<District, DistrictDto>(district);
        }

        [Authorize(QuickSellPermissions.Districts.Create)]
    public virtual async Task<PagedResultDto<DistrictDto>> GetListAsync(GetDistrictsInput input)
        {
            var totalCount = await _districtRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _districtRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<DistrictDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< District>, List<DistrictDto>>(items)
            };
        }


   

    public virtual async Task< DistrictDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<District, DistrictDto>(await _districtRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.Districts.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _districtRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.Districts.Edit)]
     public virtual async Task<DistrictDto> UpdateAsync(Guid id, DistrictUpdateDto input)
         {
    
            var district = await _districtManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<District, DistrictDto>(district);
         }
    



         

        
         

}
}