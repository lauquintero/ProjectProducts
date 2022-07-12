using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Products> GetProductsByCategory(int category, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.Categories.Id_Category == category);

            return ProductsOrder(data, descProductName, descCategoryName);
        }

        public IEnumerable<Products> GetProductsByProductName(string name, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.NameProduct.Contains(name));

            return ProductsOrder(data, descProductName, descCategoryName);
        } 
        
        public IEnumerable<Products> GetProductsByDescription(string description, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.ProductDescription.Contains(description));

            return ProductsOrder(data, descProductName, descCategoryName);
        } 
        
        public IEnumerable<Products> GetProductsByCategoryName(string category, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = context.Products.Where(x => x.Categories.NameCategory.Contains(category));

            return ProductsOrder(data, descProductName, descCategoryName);
        }

        public IEnumerable<Products> ProductsOrder(IEnumerable<Products> products,bool? descProductName , bool? descCategoryName)
        {
            if (descProductName != null && descCategoryName != null)
            {
                if ((bool)descProductName && (bool)descCategoryName)
                {
                    return products.OrderByDescending(x => x.NameProduct).ThenByDescending(x => x.Categories.NameCategory);
                }
                else if (!(bool)descProductName && (bool)descCategoryName)
                {
                    return products.OrderBy(x => x.NameProduct).ThenByDescending(x => x.Categories.NameCategory);
                }
                else if ((bool)descProductName && (bool)!descCategoryName)
                {
                    return products.OrderByDescending(x => x.NameProduct).ThenBy(x => x.Categories.NameCategory);
                }
                else
                {
                    return products.OrderBy(x => x.NameProduct).ThenBy(x => x.Categories.NameCategory);
                }
            }
            else
            {
                if (descProductName != null)
                {
                    if ((bool)descProductName)
                    {
                        return products.OrderByDescending(x => x.NameProduct);
                    }
                    else
                    {
                        return products.OrderBy(x => x.NameProduct);
                    }
                }
                else if (descCategoryName != null)
                {
                    if ((bool)descCategoryName)
                    {
                        return products.OrderByDescending(x => x.Categories.NameCategory);
                    }
                    else
                    {
                        return products.OrderBy(x => x.Categories.NameCategory);
                    }
                }
                else
                {
                    return products;
                }
            }
        }
    }
}
