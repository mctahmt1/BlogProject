using AutoMapper;
using BlogProject.Entity.DTOs.Categories;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Web.ResultMessages;
using BlogProject.Service.Services.Abstracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using BlogProject.Service.Services.Concrete;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Category> validator;
        private readonly IToastNotification toastNotification;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator, IToastNotification toastNotification)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
            await categoryService.CreateCategoryAsync(categoryAddDto);
            toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Ekleme İşlemi Başarılı!" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {

            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "Ekleme İşlemi Başarısız!" });
                return Json(result.Errors.First().ErrorMessage);
            }
            await categoryService.CreateCategoryAsync(categoryAddDto);
            toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Ekleme İşlemi Başarılı!" });
            return Json(Messages.Category.Add(categoryAddDto.Name));
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var categoryUpdateDto = mapper.Map<CategoryUpdateDto>(category);
            return View(categoryUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = mapper.Map<Category>(categoryUpdateDto);
            var result = await validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(categoryUpdateDto);
            }
            var name = await categoryService.UpdateCategoryAsync(categoryUpdateDto);
            toastNotification.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "Güncelleme İşlemi Başarılı!" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        public async Task<IActionResult> SafeDelete(Guid categoryId)
        {
            var name = await categoryService.SafeDeleteCategoryAsync(categoryId);
            toastNotification.AddSuccessToastMessage(Messages.Category.SafeDelete(name), new ToastrOptions { Title = "Silme İşlemi Başarılı!" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        public async Task<IActionResult> DeletedCategories()
        {
            var categories = await categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            var title = await categoryService.UndoDeleteCategoryAsync(categoryId);
            toastNotification.AddSuccessToastMessage(Messages.Category.UndoDelete(title), new ToastrOptions { Title = "Geri Yükleme İşlemi Başarılı!" });
            return RedirectToAction("DeletedCategories", "Category", new { Area = "Admin" });
            
        }
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var name = await categoryService.DeleteCategoryAsync(categoryId);
            toastNotification.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions { Title = "Silme İşlemi Başarılı!" });
            return RedirectToAction("DeletedCategories", "Category", new { Area = "Admin" });
        }
    }
}
