using AutoMapper;
using BlogProject.Entity.DTOs.Articles;
using BlogProject.Entity.Entities;

namespace BlogProject.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            //ArticleDto istersek bize Article ile map işlemi yapacak, Article istersekte tam tersini yapacak.
            CreateMap<ArticleDto, Article>().ReverseMap();
        }
    }
}
