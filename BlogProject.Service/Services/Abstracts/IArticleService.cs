using BlogProject.Entity.DTOs.Articles;

namespace BlogProject.Service.Services.Abstracts
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task CreateArticleAsync(ArticleAddDto articleDto);
        Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> DeleteArticleAsync(Guid articleId);
        Task<List<ArticleDto>> GetAllDeletedArticlesAsync();
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<ArticleDto> GetArticleWithCategoryDeletedAsync(Guid articleId);

    }
}
