using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Data.Repository
{
    public interface IProductRepository : IGenericRepository<Products>
    {
       IEnumerable<Products> GetProductsByProductName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByCategory(int category, string page, string size, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByDescription(string description, string page, string size, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<Products> GetProductsByCategoryName(string category, string page, string size, bool? descProductName = null, bool? descCategoryName = null);
    }
}
