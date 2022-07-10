using ProjectProducts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Interface
{
    public interface ICategoryDomain
    {
        void AddCategory(CategoryDTO category);

        void EditCategory(CategoryDTO category);

        void DeleteProduct(int categoryId);

        IEnumerable<CategoryDTO> GetAllCategory();
    }
}
