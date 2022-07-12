using ProjectProducts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Interface
{
    public interface IProductService
    {
        void AddProduct(ProductDTO product);

        void EditProduct(ProductDTO product);

        void DeleteProduct(int productId);

        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductById(int product);

        IEnumerable<ProductDTO> GetProductByName(string name, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<ProductDTO> GetProductByCategoryName(string name, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<ProductDTO> GetProductByDescription(string description, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<ProductDTO> GetProductByCategory(int category, bool? descProductName = null, bool? descCategoryName = null);

    }
}
