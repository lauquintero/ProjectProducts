using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Data.Repository
{
    public interface IProductRepository : IGenericRepository<Products>
    {
        IEnumerable<Products> ProductsOrder(IEnumerable<Products> products, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByProductName(string name, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByCategory(int category, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByDescription(string description, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByCategoryName(string category, bool? descProductName = null, bool? descCategoryName = null);
    }
}
