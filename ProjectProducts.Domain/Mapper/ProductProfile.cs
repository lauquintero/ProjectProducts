using AutoMapper;
using ProjectProducts.Data;
using ProjectProducts.Domain.DTOs;

namespace ProjectProducts.Domain.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductDTO>().ForMember(d=> d.ProductId , o=> o.MapFrom(s=> s.Id_Product))
                                             .ForMember(d => d.ProductName, o => o.MapFrom(s => s.NameProduct))
                                             .ForMember(d => d.Category, o => o.MapFrom(s => new CategoryDTO { Id_Category = s.Categories.Id_Category , NameCategory = s.Categories.NameCategory}))
                                             .ForMember(d => d.Image, o => o.MapFrom(s => s.image));
            CreateMap<ProductDTO, Products>().ForMember(d => d.Id_Product, o => o.MapFrom(s => s.ProductId))
                                             .ForMember(d => d.NameProduct, o => o.MapFrom(s => s.ProductName))
                                             .ForMember(d => d.Id_Category, o => o.MapFrom(s => s.Category.Id_Category))
                                             .ForMember(d => d.image, o => o.MapFrom(s => s.Image));
            //categories
            CreateMap<Categories, CategoryDTO>();
            CreateMap<CategoryDTO, Categories>();
        }
    }
}
