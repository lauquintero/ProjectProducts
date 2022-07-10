using ProjectProducts.Data;
using ProjectProducts.Data.Repository.Implements;
using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Implements
{
    public class ProductDomain : IProductDomain
    {
        private readonly ProductRepository context = new ProductRepository(ProductDBContext.Create());

        public async void AddProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var data = context.GetAll();

            return Mapping(data.Result);
        }

        public IEnumerable<ProductDTO> GetProductByCategory(int category, bool descProductName = false, bool descCategoryName = false)
        {
            var data = context.GetProductsByCategory(category, descProductName, descCategoryName);

            return Mapping(data);
        }

        public IEnumerable<ProductDTO> GetProductByCategoryName(string name, bool descProductName = false, bool descCategoryName = false)
        {
            var data = context.GetProductsByCategoryName(name, descProductName, descCategoryName);

            return Mapping(data);
        }

        public IEnumerable<ProductDTO> GetProductByDescription(string description, bool descProductName = false, bool descCategoryName = false)
        {
            var data = context.GetProductsByDescription(description, descProductName, descCategoryName);

            return Mapping(data);
        }

        public async Task<ProductDTO> GetProductById(int product)
        {
            var _product = await context.GetById(product);

            return new ProductDTO()
            {
                ProductId = _product.Id_Product,
                ProductName = _product.NameProduct,
                ProductDescription = _product.ProductDescription,
                Category = new CategoryDTO()
                {
                    CategoryID = _product.Categories.Id_Category,
                    CategoryName = _product.Categories.NameCategory
                },
                Image = _product.image
            };
        }

        public IEnumerable<ProductDTO> GetProductByName(string name, bool descProductName = false, bool descCategoryName = false)
        {
            var data = context.GetProductsByProductName(name, descProductName, descCategoryName);

            return Mapping(data);
        }

        private IEnumerable<ProductDTO> Mapping(IEnumerable<Products> products)
        {

            List<ProductDTO> result = null;

            foreach (var item in products)
            {
                result.Add(new ProductDTO()
                {
                    ProductId = item.Id_Product,
                    ProductName = item.NameProduct,
                    ProductDescription = item.ProductDescription,
                    Category = new CategoryDTO()
                    {
                        CategoryID = item.Categories.Id_Category,
                        CategoryName = item.Categories.NameCategory
                    },
                    Image = item.image
                });
            }
            return result;
        }
    }
}
