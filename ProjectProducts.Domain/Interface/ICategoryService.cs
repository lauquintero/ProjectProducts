using ProjectProducts.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryDTO category);

        Task<CategoryDTO> EditCategory(CategoryDTO category);

        Task DeleteCategory(int categoryId);

        Task<IEnumerable<CategoryDTO>> GetAllCategoryAsync();

        Task<CategoryDTO> GetCategoryByIdAsync(int id);
    }
}
