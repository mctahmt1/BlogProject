using BlogProject.Service.FluentValidations;
using BlogProject.Service.Helpers.Images;
using BlogProject.Service.Services.Abstracts;
using BlogProject.Service.Services.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace BlogProject.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageHelper, ImageHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                #region RegisterValidatorsFromAssemblyContaining comment
                //Bu yöntem, doğrulama işlemlerini kolaylaştırmak ve otomatik olarak doğrulama kurallarını uygulamak için kullanılabilir. Örneğin, bir web uygulamasında kullanılan bir doğrulama kütüphanesi, RegisterValidatorsFromAssemblyContaining yöntemini kullanarak doğrulayıcıları kaydedebilir ve ardından bu doğrulayıcıları otomatik olarak ilgili modellerin üzerinde uygulayabilir.
                #endregion
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true; // Propertyler üzerindeki [Key],[Required] gibi attribute leri kısıtlamak için kullanılır.
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
            return services;
        }
    }
}
