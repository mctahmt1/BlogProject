using BlogProject.Entity.DTOs.Articles;

namespace BlogProject.Service.Services.Abstracts
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticleAsync();
    }
}
