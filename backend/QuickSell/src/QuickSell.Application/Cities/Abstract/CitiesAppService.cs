
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
using QuickSell.Cities;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.Cities
{
public abstract class CitiesAppService :ApplicationService, ICitiesAppService
{
    private readonly ICityRepository _cityRepository;
    private readonly CityManager _cityManager;

    public CitiesAppService(ICityRepository cityRepository,CityManager cityManager)
    {
        _cityRepository = cityRepository;
        _cityManager= cityManager;
    }

    
        [Authorize(QuickSellPermissions.Cities.Create)]
    public virtual async Task<CityDto> CreateAsync(CityCreateDto input)
        {

            var city = await _cityManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<City, CityDto>(city);
        }

        [Authorize(QuickSellPermissions.Cities.Create)]
    public virtual async Task<PagedResultDto<CityDto>> GetListAsync(GetCitiesInput input)
        {
            var totalCount = await _cityRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _cityRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< City>, List<CityDto>>(items)
            };
        }


   

    public virtual async Task< CityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<City, CityDto>(await _cityRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.Cities.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.Cities.Edit)]
     public virtual async Task<CityDto> UpdateAsync(Guid id, CityUpdateDto input)
         {
    
            var city = await _cityManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<City, CityDto>(city);
         }
    



         

        
         

}
}