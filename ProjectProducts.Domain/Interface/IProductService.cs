using ProjectProducts.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Interface
{
    public interface IProductService
    {
        Task<ProductDTO> AddProduct(ProductDTO product);

        Task<ProductDTO> EditProduct(ProductDTO product);

        Task DeleteProduct(int productId);

        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int product);

        IEnumerable<ProductDTO> GetProductByName(string name,string page, string size, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<ProductDTO> GetProductByCategoryName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<ProductDTO> GetProductByDescription(string description, string page, string size, bool? descProductName = null, bool? descCategoryName = null);

        IEnumerable<ProductDTO> GetProductByCategory(int category, string page, string size, bool? descProductName = null, bool? descCategoryName = null);

    }
}
