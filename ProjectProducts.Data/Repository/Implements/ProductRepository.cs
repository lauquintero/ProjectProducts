using ProjectProducts.Data.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Data.Repository.Implements
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        private readonly ProductDBContext context = null;

        public ProductRepository(ProductDBContext productDBContext) : base(productDBContext)
        {
            context = productDBContext;
        }

        public IEnumerable<Products> GetProductsByCategory(int category, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.Categories.Id_Category == category)
                                       .OrderBy(PagerUtils.OrderByField(descProductName, descCategoryName))
                                       .Skip((PagerUtils.PageNumber(page) - 1) * PagerUtils.PageSize(size))
                                       .Take(PagerUtils.PageSize(size));

            return data;
        }

        public IEnumerable<Products> GetProductsByProductName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.NameProduct.Contains(name))
                                       .OrderBy(PagerUtils.OrderByField(descProductName, descCategoryName))
                                       .Skip((PagerUtils.PageNumber(page) - 1) * PagerUtils.PageSize(size))
                                       .Take(PagerUtils.PageSize(size));
            return data;
        } 
        
        public IEnumerable<Products> GetProductsByDescription(string description, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.ProductDescription.Contains(description))
                                       .OrderBy(PagerUtils.OrderByField(descProductName, descCategoryName))
                                       .Skip((PagerUtils.PageNumber(page) - 1) * PagerUtils.PageSize(size))
                                       .Take(PagerUtils.PageSize(size));
            return data;
        } 
        
        public IEnumerable<Products> GetProductsByCategoryName(string category, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.Categories.NameCategory.Contains(category))
                                       .OrderBy(PagerUtils.OrderByField(descProductName, descCategoryName))
                                       .Skip((PagerUtils.PageNumber(page) - 1) * PagerUtils.PageSize(size))
                                       .Take(PagerUtils.PageSize(size));

            return data;
        }          
    }
}
