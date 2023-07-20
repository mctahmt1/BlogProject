using BlogProject.Entity.Entities;
using BlogProject.Service.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IDashboardService dashboardService;

        public HomeController(IArticleService articleService, IDashboardService dashboardService)
        {
            this.articleService = articleService;
            this.dashboardService = dashboardService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();

            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await dashboardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await dashboardService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await dashboardService.GetTotalCategoryCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalUserArticlesCount()
        {
            var count = await dashboardService.GetTotalUserArticlesCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalUserCategoriesCount()
        {
            var count = await dashboardService.GetTotalUserCategoriesCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> loginUserName()
        {
            var userName = await dashboardService.LoginUserName();
            return Json(userName);
        }
    }
}
