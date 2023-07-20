using BlogProject.Data.UnitOfWorks;
using BlogProject.Entity.Entities;
using BlogProject.Service.Extensions;
using BlogProject.Service.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BlogProject.Service.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor accessor;
        private readonly ClaimsPrincipal user;

        public DashboardService(IUnitOfWork unitOfWork,IHttpContextAccessor accessor)
        {
            this.unitOfWork = unitOfWork;
            this.accessor = accessor;
            user = accessor.HttpContext.User;
        }
        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();
            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endDate).Count();
                datas.Add(data);
            }
            return datas;
        }
        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await unitOfWork.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await unitOfWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }
        public async Task<int> GetTotalUserArticlesCount()
        {
            var userId = user.GetLoggedInUserId();
            var userArticleCount = await unitOfWork.GetRepository<Article>().CountAsync(x=>x.UserId == userId);
            return userArticleCount;
        }
        public async Task<int> GetTotalUserCategoriesCount()
        {
            var userEmail = user.GetLoggedInEmail();
            var userCategoriesCount = await unitOfWork.GetRepository<Category>().CountAsync(x => x.CreatedBy == userEmail);
            return userCategoriesCount;
        }
        public async Task<string> LoginUserName()
        {
            var userId = user.GetLoggedInUserId();
            var userName = await unitOfWork.GetRepository<AppUser>().GetByGuidAsync(userId); 
            return $"{userName.FirstName}";
        }
    }
}
