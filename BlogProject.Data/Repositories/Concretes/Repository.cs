using BlogProject.Core.Entities;
using BlogProject.Data.Context;
using BlogProject.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogProject.Data.Repositories.Concretes
{
    public class Repository<T> :IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Tüm metodlarda Dbcontexti set etmek yerine burada Table adında bir metod oluşturuyoruz.
        private DbSet<T> Table { get => dbContext.Set<T>(); } 

        //Expression<Func<T,bool>> predicate = null = Burada bir fonksiyon oluşturacağımızı metoda bildiriyoruz ve bu fonksiyona bir entity değeri verip buradan Boolean bir değer dönmesini istiyoruz,Where komutu yazmak için.2.params Expression<Func<T, object>>[] includeProperties = Params isminde tekrar expression oluşturmak için seçenek ekliyoruz ve bize obje döndürmesini sağlıyoruz, include ile başka bir entityden bize değer döndermesini sağlayacağız.
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if(predicate != null)
                query = query.Where(predicate);
            if(includeProperties.Any())
                foreach(var item in includeProperties)
                    query = query.Include(item);
            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity)//Veri tabanına veri ekleme işlemi yapılan metod.
        {
            await Table.AddAsync(entity);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.SingleAsync();
        }
        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate is not null)
                return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }
    }
}
