using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectCategorys.Api.Controllers
{
    /// <summary>
    /// Products
    /// </summary>
    [Route("api/[controller]")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService categoryDomain)
        {
            service = categoryDomain;
        }

        /// <summary>
        /// get all categorys
        /// </summary>
        /// <returns>list of category</returns>
        [HttpGet]
        [Route("GetAllCategorys")]
        public async Task<IHttpActionResult> GetAllCategorys()
        {
            var data = await service.GetAllCategoryAsync();

            return Ok(data);
        }

        /// <summary>
        /// get a single category by id category
        /// </summary>
        /// <param name="category">Category id</param>
        /// <returns>a Category</returns>
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IHttpActionResult> GetCategoryById(int category)
        {
            var data = await service.GetCategoryByIdAsync(category);

            return Ok(data);
        }

        /// <summary>
        /// Add a new category
        /// </summary>
        /// <param name="category">CategoryDTO object</param>
        /// <returns>if the object category is not CategoryDTO type return bad request else return ok</returns>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IHttpActionResult> Post([FromBody] CategoryDTO category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                try
                {
                    await service.AddCategory(category);
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
        /// edit a category
        /// </summary>
        /// <param name="category">CategoryDTO object</param>
        /// <returns>if the object category is not CategoryDTO type return bad request else return ok</returns>
        [HttpPut]
        [Route("EditCategory")]
        public async Task<IHttpActionResult> Put([FromBody] CategoryDTO category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                try
                {
                    await service.EditCategory(category);
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
        /// delete a category with the idCategory
        /// </summary>
        /// <param name="id">IdCategory</param>
        /// <returns>if can delete the register , return ok</returns>
        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await service.DeleteCategory(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}