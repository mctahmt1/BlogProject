using AutoMapper;
using BlogProject.Data.UnitOfWorks;
using BlogProject.Entity.DTOs.Users;
using BlogProject.Entity.Entities;
using BlogProject.Entity.Enums;
using BlogProject.Service.Extensions;
using BlogProject.Service.Helpers.Images;
using BlogProject.Service.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IHttpContextAccessor accessor;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork,IMapper mapper,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IHttpContextAccessor accessor, SignInManager<AppUser> signInManager, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.accessor = accessor;
            this.signInManager = signInManager;
            this.imageHelper = imageHelper;
            _user = accessor.HttpContext.User;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if(result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return (result,user.Email);
            else return (result, null);
        }

        public async Task<List<AppRole>> GetAllRoleAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var user in map)
            {
                var findUser = await userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                user.Role = role;
            }
            return map;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(userRole))
                {
                    await userManager.RemoveFromRoleAsync(user, userRole);
                }
                var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, i => i.Image);
            var map = mapper.Map<UserProfileDto>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;
            return map;
        }
        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            var useremail = _user.GetLoggedInEmail();
            var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, useremail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            return image.Id;
        } 
        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
            if (isVerified && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                    mapper.Map(userProfileDto, user);
                    user.ImageId = await UploadImageForUser(userProfileDto);
                    await userManager.UpdateAsync(user);
                    await unitOfWork.SaveAsync();
                    return true;
                }
                else
                    return false;
            }
            else if (isVerified && userProfileDto.Photo != null)
            {
                await userManager.UpdateSecurityStampAsync(user);
                mapper.Map(userProfileDto, user);
                user.ImageId = await UploadImageForUser(userProfileDto);
                await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();
                return true;
            } 
            else
                return false;
        }
        
    }
}
