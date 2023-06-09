using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.Infrastructure;

namespace WebRunning.API.Service.Sys_User
{
    public interface IService: IRepositoryBase<Model.Sys_User>
    {        
        Task<LoginResult> CheckUserLogin(string UserName, string Password, Lib.Enums.UserType Type);
        Task<LoginResult> CheckUserLogin(string Email);
        Task<bool> CheckUserNameExists(string UserName);
        Task<bool> CheckEmailExists(string Email);
        Task UserChangePassword(Guid UserId, string PassWord);
        Task UserChangePasswordNew(string Code, string PassWordNew);
        Task<LoginResult> CheckUserRefreshToken(string UserName);
        Task<UserInfo> GetUserInfo(string UserName);
        Task EditUserInfo(EditUserInfo UserInfo);
        Task<string> GetCodeByEmailAsync(string Email);
        Task<List<ViewModel.Sys_User.ListByOrganId>> GetByOrganIdAsync(Guid OrganId);
        Task<ViewModel.Sys_User.Detail> GetDetailByIdAsync(Guid Id);
        Task<List<ViewModel.Sys_User.UsersWithRoleOrgan>> GetUsersWithRoleOrgan();
        Task<bool> IsDupicateAttributesAsync(Guid? Id, string UserName, string Email);
        Task<ViewModel.Sys_User.Detail> CreateAsync(Model.Sys_User user, Guid? OrganId, Guid? RoleId);
        Task<ViewModel.Sys_User.Detail> UpdateAsync(Model.Sys_User user, Guid? OrganId, Guid? RoleId);
        Task DeleteById(Guid Id);
        Task<Paged<ViewModel.Sys_User.UserList>> GetListPagedByLoginNameAndIsActive(int page, int pageSize, int totalLimitItems, string search);
        Task<bool> ActiveUserAsync(Guid UserId);
        Task<bool> UnActiveUserAsync(Guid UserId);
    }
}
