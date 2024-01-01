

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;

namespace QuickSell.MovementHeaders

{
    public interface IMovementHeadersAppService: IApplicationService
    {
        Task<LoadResult> GetListMovementHeader(DataSourceLoadOptions loadOptions);
        Task<DxMovementHeaderLookupDto?> GetMovementHeaderByID(Guid? id);
        Task<MovementHeaderDto> AddMovementHeader(MovementHeaderDto input);
        Task<MovementHeaderDto> UpdateMovementHeader(Guid id, IDictionary<string, object> input);
        Task DeleteMovementHeader(Guid id);
        Task SaveMovement(MovementDTO input);
    }
}


