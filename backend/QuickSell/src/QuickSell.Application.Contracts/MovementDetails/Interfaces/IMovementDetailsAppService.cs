

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;


namespace QuickSell.MovementDetails

{
    public interface IMovementDetailsAppService: IApplicationService
    {
        

        Task<PagedResultDto< MovementDetailsDto >> GetListAsync(GetMovementDetailsInput input);

        Task<MovementDetailsDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MovementDetailsDto> CreateAsync(MovementDetailsCreateDto input);

        Task<MovementDetailsDto> UpdateAsync(Guid id, MovementDetailsUpdateDto input);

        
    }
}


