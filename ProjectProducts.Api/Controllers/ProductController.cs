using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectProducts.Api.Controllers
{
    /// <summary>
    /// Products
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : ApiController
    {
        private readonly IProductService service;

        public ProductController(IProductService productDomain)
        {
            service = productDomain;
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <returns>list of product</returns>
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var data = await service.GetAllProductsAsync();

            return Ok(data);
        }

        /// <summary>
        /// Get products by category
        /// </summary>
        /// <param name="category">category Id</param>
        /// <param name="page">number of page</param>
        /// <param name="size">size page </param>
        /// <param name="descProductName">swich true for desc product name filter </param>
        /// <param name="descCategoryName">swich true for desc category name filter </param>
        /// <returns>list of Product</returns>
        [HttpGet]
        [Route("GetProductByCategory")]
        public IHttpActionResult GetProductByCategory(int category, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = service.GetProductByCategory(category, page, size, descProductName, descCategoryName);

            return Ok(data);
        }

        /// <summary>
        /// get product by catgory name
        /// </summary>
        /// <param name="name">category name</param>
        /// <param name="page">number of page</param>
        /// <param name="size">size page </param>
        /// <param name="descProductName">swich true for desc product name filter </param>
        /// <param name="descCategoryName">swich true for desc category name filter </param>
        /// <returns>list of Product</returns>
        [HttpGet]
        [Route("GetProductByCategoryName")]
        public IHttpActionResult GetProductByCategoryName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = service.GetProductByCategoryName(name, page, size, descProductName, descCategoryName);

            return Ok(data);
        }

        /// <summary>
        /// get products by description
        /// </summary>
        /// <param name="description">product description</param>
        /// <param name="page">number of page</param>
        /// <param name="size">size page </param>
        /// <param name="descProductName">swich true for desc product name filter </param>
        /// <param name="descCategoryName">swich true for desc category name filter </param>
        /// <returns>list of Product</returns>
        [HttpGet]
        [Route("GetProductByDescription")]
        public IHttpActionResult GetProductByDescription(string description, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = service.GetProductByDescription(description, page, size, descProductName, descCategoryName);

            return Ok(data);
        }

        /// <summary>
        /// get a single product by id product
        /// </summary>
        /// <param name="product">Product id</param>
        /// <returns>a Product</returns>
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IHttpActionResult> GetProductById(int product)
        {
            var data = await service.GetProductByIdAsync(product);

            return Ok(data);
        }

        /// <summary>
        /// get products by product name
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="page">number of page</param>
        /// <param name="size">size page </param>
        /// <param name="descProductName">swich true for desc product name filter </param>
        /// <param name="descCategoryName">swich true for desc category name filter </param>
        /// <returns>list of Product</returns>
        [HttpGet]
        [Route("GetProductByName")]
        public IHttpActionResult GetProductByName(string name, string page, string size, bool? descProductName = null, bool? descCategoryName = null)
        {
            var data = service.GetProductByName(name, page, size, descProductName, descCategoryName);

            return Ok(data);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">ProductDTO object</param>
        /// <returns>if the object product is not ProductDTO type return bad request else return ok</returns>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IHttpActionResult> Post([FromBody] ProductDTO product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                try
                {
                    await service.AddProduct(product);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// edit a product
        /// </summary>
        /// <param name="product">ProductDTO object</param>
        /// <returns>if the object product is not ProductDTO type return bad request else return ok</returns>
        [HttpPut]
        [Route("EditProduct")]
        public async Task<IHttpActionResult> Put([FromBody] ProductDTO product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                try
                {
                    await service.EditProduct(product);
                    return Ok();
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// delete a product with the idProduct
        /// </summary>
        /// <param name="id">IdProduct</param>
        /// <returns>if can delete the register , return ok</returns>
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await service.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
