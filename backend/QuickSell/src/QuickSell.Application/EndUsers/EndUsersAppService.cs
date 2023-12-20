using Volo.Abp.Application.Services;
namespace QuickSell.EndUsers
{
    public abstract class EndUsersAppService : ApplicationService, IEndUsersAppService
    {
        private readonly IEndUserRepository _endUserRepository;
        private readonly EndUserManager _endUserManager;

        public EndUsersAppService(IEndUserRepository endUserRepository, EndUserManager endUserManager)
        {
            _endUserRepository = endUserRepository;
            _endUserManager = endUserManager;
        }


    }
}