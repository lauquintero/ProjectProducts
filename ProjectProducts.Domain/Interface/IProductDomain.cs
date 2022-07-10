using ProjectProducts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Interface
{
    public interface IProductDomain
    {
        void AddProduct(ProductDTO product);

        void EditProduct(ProductDTO product);

        void DeleteProduct(int productId);

        IEnumerable<ProductDTO> GetAllProducts();

        Task<ProductDTO> GetProductById(int product);

        IEnumerable<ProductDTO> GetProductByName(string name, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<ProductDTO> GetProductByCategoryName(string name, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<ProductDTO> GetProductByDescription(string description, bool descProductName = false, bool descCategoryName = false);

        IEnumerable<ProductDTO> GetProductByCategory(int category, bool descProductName = false, bool descCategoryName = false);

    }
}
