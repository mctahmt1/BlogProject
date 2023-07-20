using AutoMapper;
using BlogProject.Data.UnitOfWorks;
using BlogProject.Entity.DTOs.Articles;
using BlogProject.Entity.Entities;
using BlogProject.Entity.Enums;
using BlogProject.Service.Extensions;
using BlogProject.Service.Helpers.Images;
using BlogProject.Service.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BlogProject.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor accessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal user;

        public ArticleService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor accessor,IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.accessor = accessor;
            user = accessor.HttpContext.User;
            this.imageHelper = imageHelper;
        }
        public async Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, a => a.Category, i => i.Image,a=>a.User) :
                await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, a => a.CategoryId == categoryId && !a.IsDeleted,c=> c.Category, i => i.Image,a=>a.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1 * pageSize)).Take(pageSize).ToList() :
                articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1 * pageSize)).Take(pageSize).ToList();
            var map = mapper.Map<List<ArticleDto>>(sortedArticles);

            return new ArticleListDto
            {
                Articles = map,
                categoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
		}
        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            //var userId = Guid.Parse("5CA6B261-E32D-4D26-9719-A98781F37011");
            var userId = user.GetLoggedInUserId();
            var useremail = user.GetLoggedInEmail();

            var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName,articleAddDto.Photo.ContentType,useremail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);


            var article = new Article(articleAddDto.Title,articleAddDto.Content,userId,useremail,articleAddDto.CategoryId,image.Id);

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }
        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted,x=> x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category,x => x.Image,x=>x.User);
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var useremail = user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);

            if(articleUpdateDto.Photo != null)
            {
                if(article.Image != null && article.Image.FileName != null)
                {
                    imageHelper.Delete(article.Image.FileName);
                }
                else
                {
                    var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                    Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, useremail);
                    await unitOfWork.GetRepository<Image>().AddAsync(image);
                    article.ImageId = image.Id;
                }
            }
            mapper.Map(articleUpdateDto, article);
            
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = useremail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
            
        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var useremail = user.GetLoggedInEmail();

            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = useremail;
            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
            return article.Title;
        }
        public async Task<List<ArticleDto>> GetAllDeletedArticlesAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<string> DeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            await unitOfWork.GetRepository<Article>().DeleteAsync(article);
            await unitOfWork.SaveAsync();
            return article.Title;
        }
        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;
            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
            return article.Title;
        }
        public async Task<ArticleDto> GetArticleWithCategoryDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted && x.Id == articleId, x => x.Category, x => x.Image);
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
		public async Task AddNewsLatterUser(NewsLatter newsLatter)
		{
            var news = new NewsLatter(newsLatter.Mail);
			await unitOfWork.GetRepository<NewsLatter>().AddAsync(news);
			await unitOfWork.SaveAsync();
		}
		public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(
				a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)),
			a => a.Category, i => i.Image, u => u.User);

			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
			var map = mapper.Map<List<ArticleDto>>(sortedArticles);
			return new ArticleListDto
			{
				Articles = map,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending
			};
		}
	}
}
