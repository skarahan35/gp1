

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.MovementHeaders

{
    public interface IMovementHeadersAppService: IApplicationService
    {
        

        Task<PagedResultDto< MovementHeaderDto >> GetListAsync(GetMovementHeadersInput input);

        Task<MovementHeaderDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MovementHeaderDto> CreateAsync(MovementHeaderCreateDto input);

        Task<MovementHeaderDto> UpdateAsync(Guid id, MovementHeaderUpdateDto input);

        
    }
}


