using BlogProject.Data.Context;
using BlogProject.Data.Repositories.Abstracts;
using BlogProject.Data.Repositories.Concretes;
using BlogProject.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProject.Data.Extensions
{
    public static class DataLayerExtension
    {
        //Burada service yapılarını farklı katmanda oluşturuyoruz. Çünkü program.cs dosyamızın olabildiğince temiz olmasını isteriz.
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services,IConfiguration config) 
        {
            //IRepository ye her istek yolladığımızda bize repository nesnesini getirmesini söyledik. Dependency Injection nesneleri farklı sınıflarda oluşturmaktan kaçınmak için kullanılır.
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
