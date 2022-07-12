using AutoMapper;
using ProjectProducts.Data;
using ProjectProducts.Data.Repository.Implements;
using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using ProjectProducts.Domain.Mapper;
using System;
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

        public ProductService(IProductRepository productRepository,IMapper _mapper)
        {
            _productRepository = productRepository;
            Mapper = _mapper;
        }

        public async void AddProduct(ProductDTO product)
        {
            var _product = Mapper.Map<Products>(product);
            
            await _productRepository.Insert(_product);            
        }

        public async void DeleteProduct(int productId)
        {
           await _productRepository.Delete(productId);
        }

        public async void EditProduct(ProductDTO product)
        {
            var _product = Mapper.Map<Products>(product);

            await _productRepository.Update(_product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var data = await _productRepository.GetAll();

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public IEnumerable<ProductDTO> GetProductByCategory(int category, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByCategory(category, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public IEnumerable<ProductDTO> GetProductByCategoryName(string name, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByCategoryName(name, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public IEnumerable<ProductDTO> GetProductByDescription(string description, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByDescription(description, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }

        public async Task<ProductDTO> GetProductById(int product)
        {
            var _product = await _productRepository.GetById(product);

            return Mapper.Map<ProductDTO>(_product);
        }

        public IEnumerable<ProductDTO> GetProductByName(string name, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = _productRepository.GetProductsByProductName(name, descProductName, descCategoryName);

            return data.Select(x => Mapper.Map<ProductDTO>(x));
        }
    }
}
