using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Implements
{
    public class CategoryDomain : ICategoryDomain
    {
        public void AddCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAllCategory()
        {
            throw new NotImplementedException();
        }
    }
}
