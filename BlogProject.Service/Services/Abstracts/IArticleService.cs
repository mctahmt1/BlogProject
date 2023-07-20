using BlogProject.Entity.DTOs.Articles;
using BlogProject.Entity.Entities;

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
		Task AddNewsLatterUser(NewsLatter newsLatter);
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
		Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

	}
}
