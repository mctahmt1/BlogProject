using BlogProject.Entity.DTOs.Categories;
using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services.Abstracts
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        public Task<string> CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<Category> GetCategoryByGuid(Guid categoryId);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task<string> DeleteCategoryAsync(Guid categoryId);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
        Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();

	}
}
