using Volo.Abp.AspNetCore.Mvc;
using QuickSell.EndUsers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data.ResponseModel;
using QuickSell.Shared;
using System;
using System.Collections.Generic;

namespace QuickSell.Controllers.EndUsers
{
    public class EndUsersController : AbpController, IEndUsersAppService
    {
        private readonly IEndUsersAppService _endUsersAppService;

        public EndUsersController(IEndUsersAppService endUsersAppService)
        {
            _endUsersAppService = endUsersAppService;
        }
        [HttpPost]
        [Route("600101")]
        public async Task<EndUserDto> AddEndUser(EndUserDto input)
        {
            return await _endUsersAppService.AddEndUser(input);
        }
        [HttpGet]
        [Route("600104")]
        public async Task<LoadResult> GetListEndUser(DataSourceLoadOptions loadOptions)
        {
            return await _endUsersAppService.GetListEndUser(loadOptions);
        }
        [HttpGet]
        [Route("600105/{id}")]
        public async Task<DxEndUserLookupDto?> GetEndUserByID(Guid? id)
        {
            return await _endUsersAppService.GetEndUserByID(id);
        }
        [HttpDelete]
        [Route("600103/{id}")]
        public async Task DeleteEndUser(Guid id)
        {
            await _endUsersAppService.DeleteEndUser(id);
        }
        [HttpPut]
        [Route("600102/{id}")]
        public async Task<EndUserDto> UpdateEndUser(Guid id, IDictionary<string, object> input)
        {
            return await _endUsersAppService.UpdateEndUser(id, input);
        }
        [HttpGet]
        [Route("600106")]
        public async Task<bool> Login(string username, string password)
        {
            return await _endUsersAppService.Login(username, password);
        }
    }
}
