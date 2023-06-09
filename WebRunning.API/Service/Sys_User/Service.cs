using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using WebRunning.API.Infrastructure;
using WebRunning.API.Model;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Core;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Linq.Dynamic.Core;

namespace WebRunning.API.Service.Sys_User
{
    public class Service:RepositoryBase<Model.Sys_User>, Sys_User.IService
    {
        private readonly DomainDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;                
        public Service(DomainDbContext dbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService) :base(dbContext, dateTimeProvider, userService)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;            
        }
        public async Task<List<ViewModel.Sys_User.UsersWithRoleOrgan>> GetUsersWithRoleOrgan()
        {
            var items = await (from o in _dbContext.Sys_Users_Roles
                               join x in _dbContext.Sys_Users on o.UserId equals x.Id
                               join y in _dbContext.Sys_Roles on o.RoleId equals y.Id
                               join z in _dbContext.Sys_Organizations on o.OrganId equals z.Id
                               select new ViewModel.Sys_User.UsersWithRoleOrgan()
                               {
                                   Id = x.Id,
                                   UserName = x.UserName,
                                   RoleName = y.Name,
                                   OrganName = z.Name,
                                   Name = x.UserName + "-" + y.Name
                               }).ToListAsync();
            items = items.OrderBy(o => o.OrganName).ThenBy(o => o.RoleName).ThenBy(o => o.UserName).ToList();
            return items;
        }    
        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string UserName, string Email)
        {
            bool result = false;
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Sys_Users.Where(o => o.UserName == UserName || o.Email == Email).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Sys_Users.Where(o => o.UserName == UserName || o.Email == Email).ToListAsync();
                if (items.Count >= 1)
                {
                    if (items.Count == 1)
                    {
                        var item = items.FirstOrDefault(o => o.Id == Id);
                        if (item != null)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;

                    }
                }
                else
                {
                    result = false;
                }
            }
            return await Task.FromResult(result);
        }
        private void ValidateUserAsync(Guid Id, string Password, Guid? OrganId, Guid? RoleId)
        {
            if(Id == Guid.Empty && string.IsNullOrEmpty(Password))
            {
                throw new Exception(Sys_Const.Message.SERVICE_LOGIN_PASSWORD_EMPTY);
            }    
        }
        public async Task DeleteById(Guid Id)
        {                       
            var user = await _dbContext.Sys_Users.FirstOrDefaultAsync(o => o.Id == Id);
            if (user == null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_USERNAME_UNEXISTS);
            }
            _dbContext.Sys_Users.Remove(user);
            _dbContext.Sys_Users_Roles.RemoveRange(_dbContext.Sys_Users_Roles.Where(o => o.UserId == Id).ToList());
            await UnitOfWork.SaveAsync();
        }

        public async Task<ViewModel.Sys_User.Detail> GetDetailByIdAsync(Guid id)
        {
            var query = (from u in _dbContext.Sys_Users 
                         join ur in _dbContext.Sys_Users_Roles.Where(o => o.IsDefault == true) on u.Id equals ur.UserId
                            into sub_Sys_Users_Roles from urur in sub_Sys_Users_Roles.DefaultIfEmpty()
                         where u.Id == id
                         select new ViewModel.Sys_User.Detail()
                         {
                             Id = u.Id,
                             FullName = u.FullName,
                             UserName = u.UserName,
                             Email = u.Email,
                             Phone = u.Phone,
                             Address = u.Address,
                             IsActive = u.IsActive,
                             RoleId = urur != null ? urur.RoleId: null,
                             OrganId = urur != null ? urur.OrganId : null,
                         });
            return await query.FirstOrDefaultAsync();
        }
        public async Task<ViewModel.Sys_User.Detail> CreateAsync(Model.Sys_User user, Guid? organId, Guid? roleId)
        {
            try
            {
                UnitOfWork.CreateTransaction();
                ValidateUserAsync(user.Id, user.PassWord, organId, roleId);
                //add user                
                user.PassWord = Cryption.EncryptByKey(user.PassWord, Sys_Const.Security.key);
                user.IsAdmin = false;
                
                await AddEntityAsync(user);
                //add user and role
                Sys_User_Role userRoles = new Sys_User_Role();
                userRoles.UserId = user.Id;
                userRoles.OrganId = organId;
                userRoles.RoleId = roleId;
                userRoles.IsDefault = true;
                await _dbContext.Sys_Users_Roles.AddAsync(userRoles);
                //mapping
                ViewModel.Sys_User.Detail userDetail = new ViewModel.Sys_User.Detail();
                ObjectHelpers.Mapping<Model.Sys_User, ViewModel.Sys_User.Detail>(user, userDetail);
                userDetail.OrganId = userRoles.OrganId;
                userDetail.RoleId = userRoles.RoleId;
                await UnitOfWork.SaveAsync();
                UnitOfWork.Commit();
                return userDetail;
            }
            catch (Exception ex)
            {
                UnitOfWork.Roolback();
                throw new Exception(ex.Message);
            }
        }
        public async Task<ViewModel.Sys_User.Detail> UpdateAsync(Model.Sys_User user, Guid? organId, Guid? roleId)
        {
            try
            {
                UnitOfWork.CreateTransaction();
                ValidateUserAsync(user.Id, user.PassWord, organId, roleId);
                //add user
                var userOld = await _dbContext.Sys_Users.FirstOrDefaultAsync(o => o.Id == user.Id);
                userOld.FullName = user.FullName;
                if (!string.IsNullOrEmpty(user.PassWord))
                {
                    userOld.PassWord = Cryption.EncryptByKey(user.PassWord, Sys_Const.Security.key);
                }
                userOld.Email = user.Email;
                userOld.Phone = user.Phone;
                userOld.Address = user.Address;
                userOld.IsActive = user.IsActive;
                await AddEntityAsync(userOld);
                //add user and role
                Sys_User_Role userRoles = await _dbContext.Sys_Users_Roles.FirstOrDefaultAsync(o => o.UserId == user.Id && o.IsDefault == true);
                if(userRoles != null)
                {
                    userRoles.OrganId = organId;
                    userRoles.RoleId = roleId;
                }         
                else
                {
                    userRoles = new Sys_User_Role();
                    userRoles.UserId = user.Id;
                    userRoles.OrganId = organId;
                    userRoles.RoleId = roleId;
                    userRoles.IsDefault = true;
                    await _dbContext.Sys_Users_Roles.AddAsync(userRoles);
                }    
                //mapping
                ViewModel.Sys_User.Detail userDetail = new ViewModel.Sys_User.Detail();
                ObjectHelpers.Mapping<Model.Sys_User, ViewModel.Sys_User.Detail>(user, userDetail);
                if(userRoles != null)
                {
                    userDetail.OrganId = userRoles.OrganId;
                    userDetail.RoleId = userRoles.RoleId;
                }                    
                await UnitOfWork.SaveAsync();
                UnitOfWork.Commit();
                return userDetail;
            }
            catch (Exception ex)
            {
                UnitOfWork.Roolback();
                throw new Exception(ex.Message);
            }
        }
        public async Task<Paged<ViewModel.Sys_User.UserList>> GetListPagedByLoginNameAndIsActive(int page, int pageSize, int totalLimitItems, string search)
        {
            var query = from x in _dbContext.Sys_Users
                        join y in _dbContext.Sys_Users_Roles on x.Id equals y.UserId
                            into sub_Sys_Users_Roles
                        from yy in sub_Sys_Users_Roles.DefaultIfEmpty()
                        join z in _dbContext.Sys_Roles on yy.RoleId equals z.Id
                            into sub_Sys_Roles
                        from zz in sub_Sys_Roles.DefaultIfEmpty()
                        select new ViewModel.Sys_User.UserList()
                        {
                            Id = x.Id,
                            RoleName = zz != null ? zz.Name : "",
                            FullName = x.FullName,
                            UserName = x.UserName,
                            Email = x.Email,
                            Phone = x.Phone,
                            IsActive = x.IsActive
                        };
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(search);
            }
            Paged<ViewModel.Sys_User.UserList> result = new Paged<ViewModel.Sys_User.UserList>(query, page, pageSize, totalLimitItems);
            result.Items = await query.Paged(page, pageSize, totalLimitItems).ToListAsync();
            return result;
        }
        public async Task<List<ViewModel.Sys_User.ListByOrganId>> GetByOrganIdAsync(Guid OrganId)
        {
            var users = await (from ur in _dbContext.Sys_Users_Roles
                         join u in _dbContext.Sys_Users on ur.UserId equals u.Id
                         join r in _dbContext.Sys_Roles on ur.RoleId equals r.Id 
                            into sub_Sys_Roles from rr in sub_Sys_Roles.DefaultIfEmpty()
                         where ur.OrganId == OrganId && u.Type == Lib.Enums.UserType.Internal && ur.IsDefault == true
                         select new ViewModel.Sys_User.ListByOrganId()
                         {
                             Id = u.Id,
                             RoleName = rr != null ? rr.Name: "",
                             FullName = u.FullName,
                             UserName = u.UserName,
                             Email = u.Email,
                             Phone = u.Phone,
                             IsActive = u.IsActive
                         }).ToListAsync();
            return users;
        }
        public async Task<LoginResult> CheckUserLogin(string UserName, string Password, Lib.Enums.UserType Type)
        {            
            var obj = await (from a in _dbContext.Sys_Users
                             where (a.UserName == UserName || a.Email == UserName) && a.Type == Type
                             select new
                             {
                                 UserId = a.Id,
                                 UserName = a.UserName,
                                 Password = a.PassWord,
                                 IsActive = a.IsActive,
                                 IsAdmin = a.IsAdmin,
                             }).FirstOrDefaultAsync();
            if (obj == null)
            {
                throw new(Sys_Const.Message.SERVICE_USERNAME_UNEXISTS);
            }
            else
            {
                if (Cryption.DecryptByKey(obj.Password, Sys_Const.Security.key) != Password)
                {
                    throw new(Sys_Const.Message.SERVICE_PASS_INCORRECT);
                }
                if (!obj.IsActive)
                {
                    throw new(Sys_Const.Message.SERVICE_USERNAME_UNACTIVE);
                }
            }
            var roles = await (from x in _dbContext.Sys_Users_Roles
                               join y in _dbContext.Sys_Roles on x.RoleId equals y.Id
                               where x.UserId == obj.UserId
                               select y).ToListAsync();
            string roleName = "Chưa có vai trò";
            if(roles.Count > 0)
            {
                roleName = string.Join(" ", roles.Select(o => o.Name).ToArray()); 
            }    
            if(UserName == "admin" || obj.IsAdmin)
            {
                roleName = "Quản trị viên";
            }
            return new LoginResult() { UserId = obj.UserId, UserName = obj.UserName, RoleName = roleName, Roles = roles.Select(o => o.Code).ToArray() };
        }
        public async Task<LoginResult> CheckUserLogin(string Email)
        {
            var obj = await (from a in _dbContext.Sys_Users
                             where a.Email == Email
                             select new
                             {
                                 UserId = a.Id,
                                 UserName = a.UserName,
                                 IsActive = a.IsActive,
                                 IsAdmin = a.IsAdmin,
                             }).FirstOrDefaultAsync();
            var roles = await (from x in _dbContext.Sys_Users_Roles
                               join y in _dbContext.Sys_Roles on x.RoleId equals y.Id
                               join z in _dbContext.Sys_Users on x.UserId equals z.Id
                               where z.Email == Email
                               select y).ToListAsync();
            string roleName = "Chưa có vai trò";
            if (roles.Count > 0)
            {
                roleName = string.Join(" ", roles.Select(o => o.Name).ToArray());
            }
            if (Email == "admin@gmail.com" || obj.IsAdmin)
            {
                roleName = "Quản trị viên";
            }
            return new LoginResult() { UserId = obj.UserId, UserName = obj.UserName, RoleName = roleName, Roles = roles.Select(o => o.Code).ToArray() };
        }
        public async Task<bool> CheckUserNameExists(string UserName)
        {
            var usernameExists = await _dbContext.Sys_Users.Where(o => o.UserName == UserName).AnyAsync();
            return usernameExists;
        }
        public async Task<bool> CheckEmailExists(string Email)
        {
            var emailExists = await _dbContext.Sys_Users.Where(o => o.Email == Email).AnyAsync();
            return emailExists;
        }
        public async Task UserChangePassword(Guid UserId, string PassWord)
        {
            var oUser = _dbContext.Sys_Users.Single(o => o.Id == UserId);
            if (!string.IsNullOrEmpty(PassWord))
            {
                oUser.PassWord = Cryption.EncryptByKey(PassWord, Sys_Const.Security.key);
            }
            await UnitOfWork.SaveAsync();
        }
        public async Task<string> GetCodeByEmailAsync(string email)
        {
            string code = string.Empty;
            var user = await _dbContext.Sys_Users.Where(o => o.Email == email).FirstOrDefaultAsync();
            if (user != null)
            {
                code = Cryption.Base64Encode(Cryption.Base64Encode(email) + "_" + Cryption.Base64Encode(user.PassWord));
            }
            return code;
        }
        public async Task UserChangePasswordNew(string Code, string PassWordNew)
        {
            string deCode = Cryption.Base64Decode(Code);
            string[] splitResult = deCode.Split("_");
            string email = Cryption.Base64Decode(splitResult[0]);
            string password = Cryption.Base64Decode(splitResult[1]);
            var oUser = await _dbContext.Sys_Users.Where(o => o.Email == email).FirstOrDefaultAsync();
            if(oUser == null)
            {
                throw new(Sys_Const.Message.SERVICE_CHANGEPASSWORD_ERROR);
            }
            if(oUser.PassWord == password)
            {
                oUser.PassWord = Cryption.EncryptByKey(PassWordNew, Sys_Const.Security.key);
                await UnitOfWork.SaveAsync();
            }
            else
            {
                throw new(Sys_Const.Message.SERVICE_CODE_CHANGEPASSWORD_EXPIRE);
            }    
        }
        public async Task EditUserInfo(EditUserInfo userInfo)
        {
            var userCurrent = await _dbContext.Sys_Users.Where(o => o.UserName == userInfo.UserName).FirstOrDefaultAsync();
            if(userCurrent != null)
            {
                userCurrent.UserName = userInfo.UserName;
                userCurrent.Email = userInfo.Email;
                userCurrent.Phone = userInfo.Phone;
                userCurrent.Address = userInfo.Address;
            }
            await UnitOfWork.SaveAsync();
        }
        public async Task<UserInfo> GetUserInfo(string UserName)
        {
            UserInfo userInfo = new UserInfo();   
            var userCurrent = await _dbContext.Sys_Users.FirstOrDefaultAsync(o => o.UserName == UserName);
            ObjectHelpers.Mapping<Model.Sys_User, UserInfo>(userCurrent, userInfo);
            if (userCurrent != null)
            {
                userInfo.Roles = new List<string>();
                var roles = await (from x in _dbContext.Sys_Users_Roles
                                   join y in _dbContext.Sys_Roles on x.RoleId equals y.Id
                                   where x.UserId == userCurrent.Id
                                   select y.Code).ToListAsync();
                if (roles.Count != 0)
                {
                    userInfo.Roles.AddRange(roles);
                }
                if (userCurrent.UserName == "admin" && userCurrent.IsAdmin)
                {
                    userInfo.Roles.Add("admin");
                }
            }    
            return userInfo;
        }
        public async Task<LoginResult> CheckUserRefreshToken(string UserName)
        {
            var query = from x in _dbContext.Sys_Users
                        where x.UserName == UserName
                        select new LoginResult
                        {
                            UserId = x.Id,
                            UserName = x.UserName
                        };
            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> ActiveUserAsync(Guid UserId)
        {
            var user = await _dbContext.Sys_Users.Where(o => o.Id == UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_USERNAME_UNEXISTS);
            }
            if (user.IsActive == false)
            {
                user.IsActive = true;
                await _dbContext.SaveChangesAsync();
            }
            return user.IsActive;
        }
        public async Task<bool> UnActiveUserAsync(Guid UserId)
        {
            var user = await _dbContext.Sys_Users.Where(o => o.Id == UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_USERNAME_UNEXISTS);
            }
            if (user.IsActive == true)
            {
                user.IsActive = false;
                await _dbContext.SaveChangesAsync();
            }
            return user.IsActive;
        }
    }
}
