using Volo.Abp.AspNetCore.Mvc;
using QuickSell.EndUsers;


namespace QuickSell.Controllers.EndUsers
{
    public abstract class EndUsersController : AbpController, IEndUsersAppService
    {
        private readonly IEndUsersAppService _endUsersAppService;



        public EndUsersController(IEndUsersAppService endUsersAppService)
        {
            _endUsersAppService = endUsersAppService;
        }
    }
}
