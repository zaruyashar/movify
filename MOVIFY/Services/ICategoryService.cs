using MOVIFY.Model;
using System.Collections.Generic;

namespace MOVIFY.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        Category GetCategoryById(int id);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}