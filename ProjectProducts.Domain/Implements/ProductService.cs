using AutoMapper;
using ProjectProducts.Data;
using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ProjectProducts.Data.Repository;

namespace ProjectProducts.Domain.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper Mapper;

        public ProductService(IProductRepository productRepository, IMapper _mapper)
        {
            _productRepository = productRepository;
            Mapper = _mapper;
        }

        public async Task<ProductDTO> AddProduct(ProductDTO product)
        {
            var _product = Mapper.Map<Products>(product);
            
            var result = await _productRepository.Insert(_product);

            return Mapper.Map<ProductDTO>(result);
        }

        public async Task DeleteProduct(int productId)
        {
            await _productRepository.Delete(productId);
        }

        public async Task<ProductDTO> EditProduct(ProductDTO product)
        {
            var _product = Mapper.Map<Products>(product);

            var result = await _productRepository.Update(_product);

            return Mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var data = await _productRepository.GetAll();

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public IEnumerable<ProductDTO> GetProductByCategory(int category, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByCategory(category, page, size, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public IEnumerable<ProductDTO> GetProductByCategoryName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByCategoryName(name, page, size, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public IEnumerable<ProductDTO> GetProductByDescription(string description, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByDescription(description, page, size, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public async Task<ProductDTO> GetProductByIdAsync(int product)
        {
            var _product = await _productRepository.GetById(product);

            return Mapper.Map<ProductDTO>(_product);
        }

        public IEnumerable<ProductDTO> GetProductByName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByProductName(name, page, size, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }
    }
}
