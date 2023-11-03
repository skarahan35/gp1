

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.Districts

{
    public interface IDistrictsAppService: IApplicationService
    {
        

        Task<PagedResultDto< DistrictDto >> GetListAsync(GetDistrictsInput input);

        Task<DistrictDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<DistrictDto> CreateAsync(DistrictCreateDto input);

        Task<DistrictDto> UpdateAsync(Guid id, DistrictUpdateDto input);

        
    }
}


