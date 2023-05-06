using AutoMapper;
using Shope.DAL;

namespace Shope.BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
        CreateMap<Categories, CategoriesDTO>();
        CreateMap<CategoriesDTO, Categories>();

    }
}
