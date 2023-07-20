using AutoMapper;
using BlogProject.Entity.DTOs.Users;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Service.Services.Abstracts;
using BlogProject.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<AppUser> validator;
        private readonly IUserService userService;

        public UserController(IMapper mapper,IToastNotification toastNotification, IValidator<AppUser> validator,IUserService userService)
        {

            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.validator = validator;
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUsersWithRoleAsync();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRoleAsync();
            return View(new UserAddDto { Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validate = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRoleAsync();
            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Ekleme İşlemi Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validate.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);
            var roles = await userService.GetAllRoleAsync();
            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);
            if (user != null)
            {
                var roles = await userService.GetAllRoleAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validate = await validator.ValidateAsync(map);
                    if (validate.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Güncelleme İşlemi Başarılı!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);

                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validate.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await userService.DeleteUserAsync(userId);

            if (result.identityResult.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "Silme İşlemi Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();
            return View(profile); 
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            
            if (ModelState.IsValid)
            {
                var result = await userService.UserProfileUpdateAsync(userProfileDto);

                if (result)
                {
                    ToastrOptions toastOptions = new ToastrOptions { Title = "Başarılı!" };
                    toastNotification.AddSuccessToastMessage("Şifreniz ve Bilgileriniz Başarıyla Değiştirilmiştir.", toastOptions);
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    ToastrOptions toastOptions = new ToastrOptions { Title = "Hata!" };
                    toastNotification.AddErrorToastMessage("Bilgileriniz Güncellenirken Bir Hata Oluştu.", toastOptions);
                    return View(profile);
                }
            }
            else
                return NotFound();
        }
    }
}
