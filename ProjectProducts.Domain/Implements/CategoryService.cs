using AutoMapper;
using ProjectProducts.Data;
using ProjectProducts.Domain.DTOs;
using ProjectProducts.Domain.Interface;
using System.Collections.Generic;
using System.Linq;
using ProjectProducts.Data.Repository;
using System.Threading.Tasks;

namespace ProjectProducts.Domain.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper Mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper _mapper)
        {
            _categoryRepository = categoryRepository;
            Mapper = _mapper;
        }

        public async Task<CategoryDTO> AddCategory(CategoryDTO product)
        {
            var _product = Mapper.Map<Categories>(product);

            var result = await _categoryRepository.Insert(_product);

            return Mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoryAsync()
        {
            var data = await _categoryRepository.GetAll();

            return data.Select(x => Mapper.Map<CategoryDTO>(x));
        }
        
        public async Task DeleteCategory(int categoryId)
        {
            await _categoryRepository.Delete(categoryId);
        }

        public async Task<CategoryDTO> EditCategory(CategoryDTO category)
        {
            var _category = Mapper.Map<Categories>(category);

            var result = await _categoryRepository.Update(_category);

            return Mapper.Map<CategoryDTO>(result);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var _category = await _categoryRepository.GetById(id);

            return Mapper.Map<CategoryDTO>(_category);
        }
    }
}
