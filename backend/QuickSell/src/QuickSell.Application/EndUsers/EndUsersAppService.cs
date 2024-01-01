using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using QuickSell.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Linq;
using Volo.Abp.Data;
using QuickSell.Localization;
using Microsoft.Extensions.Localization;

namespace QuickSell.EndUsers
{
    public class EndUsersAppService : ApplicationService, IEndUsersAppService
    {
        private readonly IEndUserRepository _endUserRepository;
        private readonly EndUserManager _endUserManager;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<QuickSellResource> _localizer;

        public EndUsersAppService(IEndUserRepository endUserRepository,
                                  EndUserManager endUserManager,
                                  IDataFilter dataFilter,
                                  IStringLocalizer<QuickSellResource> localizer)
        {
            _endUserRepository = endUserRepository;
            _endUserManager = endUserManager;
            _dataFilter = dataFilter;
            _localizer = localizer;
        }
        public async Task<LoadResult> GetListEndUser(DataSourceLoadOptions loadOptions)
        {
            var getEndUser = await _endUserRepository.GetQueryableAsync();

            var getJoinedData = from user in getEndUser
                                select new DxEndUserLookupDto
                                {
                                    Id = user.Id,
                                    UserName = user.UserName,
                                    Name = user.Name,
                                    SurName = user.SurName,
                                    EMail = user.EMail,
                                    PhoneNumber = user.PhoneNumber,
                                    Address = user.Address,
                                    Password = user.Password
                                };
            return await DataSourceLoader.LoadAsync(getJoinedData, loadOptions);
        }
        public async Task<DxEndUserLookupDto?> GetEndUserByID(Guid? id)
        {
            var dataFilter = _dataFilter.Disable<ISoftDelete>();
            using (dataFilter)
            {
                var getEndUser = (await _endUserRepository.GetQueryableAsync());
                var EndUsers = (from user in getEndUser
                               where user.Id == id
                               select new DxEndUserLookupDto
                               {
                                   Id = user.Id,
                                   UserName = user.UserName,
                                   Name = user.Name,
                                   SurName = user.SurName,
                                   EMail = user.EMail,
                                   PhoneNumber = user.PhoneNumber,
                                   Address = user.Address,
                                   Password = user.Password
                               }).FirstOrDefault();
                return EndUsers;
            }
        }
        public async Task<EndUserDto> AddEndUser(EndUserDto input)
        {
            var EndUser = await _endUserManager.CreateAsync(
              input.UserName,
              input.Name,
              input.SurName,
              input.EMail,
              input.PhoneNumber,
              input.Address,
              input.Password
              );
            return ObjectMapper.Map<EndUser, EndUserDto>(EndUser);
        }
        public async Task<EndUserDto> UpdateEndUser(Guid id, IDictionary<string, object> input)
        {
            var EndUser = await _endUserRepository.GetAsync(id);
            var EndUserDto = ObjectMapper.Map<EndUser, EndUserDto>(EndUser);
            await DevExtremeUpdate.Update(EndUserDto, input);

            return await BPUpdateEmployees(EndUserDto.Id, EndUserDto);
        }
        public async Task<EndUserDto> BPUpdateEmployees(Guid id, EndUserDto input)
        {
            var EndUser = await _endUserManager.UpdateAsync(
                id,
                input.UserName,
                input.Name,
                input.SurName,
                input.EMail,
                input.PhoneNumber,
                input.Address,
                input.Password
            );
            await _endUserRepository.UpdateAsync(EndUser);

            return ObjectMapper.Map<EndUser, EndUserDto>(EndUser);
        }
        public async Task DeleteEndUser(Guid id)
        {
            await _endUserRepository.DeleteAsync(id);
        }
    }
}