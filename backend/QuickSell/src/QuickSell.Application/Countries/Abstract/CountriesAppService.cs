
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
using QuickSell.Countries;
using QuickSell.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace QuickSell.Countries
{
public abstract class CountriesAppService :ApplicationService, ICountriesAppService
{
    private readonly ICountryRepository _countryRepository;
    private readonly CountryManager _countryManager;

    public CountriesAppService(ICountryRepository countryRepository,CountryManager countryManager)
    {
        _countryRepository = countryRepository;
        _countryManager= countryManager;
    }

    
        [Authorize(QuickSellPermissions.Countries.Create)]
    public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {

            var country = await _countryManager.CreateAsync(
                input.Code,
                input.Name,
            );
           
            
            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [Authorize(QuickSellPermissions.Countries.Create)]
    public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            var totalCount = await _countryRepository.GetCountAsync(input.FilterText, input.Code, input.Name);
            var items = await _countryRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Name
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< Country>, List<CountryDto>>(items)
            };
        }


   

    public virtual async Task< CountryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Country, CountryDto>(await _countryRepository.GetAsync(id));
        }


   
        [Authorize(QuickSellPermissions.Countries.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        [Authorize(QuickSellPermissions.Countries.Edit)]
     public virtual async Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input)
         {
    
            var country = await _countryManager.UpdateAsync(
                id,
                input.Code,
                input.Name,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<Country, CountryDto>(country);
         }
    



         

        
         

}
}