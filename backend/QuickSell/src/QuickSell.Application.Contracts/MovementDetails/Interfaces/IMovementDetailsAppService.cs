

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.MovementDetails

{
    public interface IMovementDetailsAppService: IApplicationService
    {
        Task<LoadResult> GetListMovementDetail(DataSourceLoadOptions loadOptions);
        Task<DxMovementDetailLookupDto?> GetMovementDetailByID(Guid? id);
        Task<MovementDetailDto> AddMovementDetail(MovementDetailDto input);
        Task<MovementDetailDto> UpdateMovementDetail(Guid id, IDictionary<string, object> input);
        Task DeleteMovementDetail(Guid id);

    }
}


