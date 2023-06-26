﻿using AutoMapper;
using BlogProject.Entity.DTOs.Articles;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Service.Services.Abstracts;
using BlogProject.Web.Consts;
using BlogProject.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toastNotification;

        public ArticleController(IArticleService articleService,ICategoryService categoryService,IMapper mapper,IValidator<Article> validator,IToastNotification toastNotification)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories});
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Article>(articleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title), new ToastrOptions { Title = "Ekleme İşlemi Başarılı!"});
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedArticleDetails(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryDeletedAsync(articleId);
            
            return View(article);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid articleId)
        {
                var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
                TempData["title"] = article.Title;
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
                articleUpdateDto.Categories = categories;
                return View(articleUpdateDto);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var map = mapper.Map<Article>(articleUpdateDto);
            var result = await validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(articleUpdateDto);
            }
            await articleService.UpdateArticleAsync(articleUpdateDto);
            toastNotification.AddSuccessToastMessage(Messages.Article.Update(TempData["title"].ToString()), new ToastrOptions { Title = "Güncelleme İşlemi Başarılı!"});
            return RedirectToAction("Index", "Article", new { Area = "Admin" });

        }
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> SafeDelete(Guid articleId)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.SafeDelete(title), new ToastrOptions { Title = "Silme İşlemi Başarılı!" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleService.DeleteArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions { Title = "Silme İşlemi Başarılı!" });
            return RedirectToAction("DeletedArticles", "Article", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> DeletedArticles()
        {
            var articles = await articleService.GetAllDeletedArticlesAsync();
            return View(articles);
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions { Title = "Geri Yükleme İşlemi Başarılı!" });
            return RedirectToAction("DeletedArticles", "Article", new { Area = "Admin" });
        }

    }
}
