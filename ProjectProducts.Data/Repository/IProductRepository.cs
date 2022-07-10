using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Data.Repository
{
    public interface IProductRepository : IGenericRepository<Products>
    {
        IEnumerable<Products> ProductsOrder(IEnumerable<Products> products, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<Products> GetProductsByProductName(string name, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<Products> GetProductsByCategory(int category, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<Products> GetProductsByDescription(string description, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<Products> GetProductsByCategoryName(string category, bool descProductName = false, bool descCategoryName = false);
    }
}
