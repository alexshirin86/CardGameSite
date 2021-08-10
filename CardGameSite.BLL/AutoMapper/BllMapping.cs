using AutoMapper;
using CardGameSite.BLL.DTO;
using CardGameSite.DAL.Entities;

namespace CardGameSite.BLL.AutoMapper
{
    public class BllMapping : Profile
    {
        public BllMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<CategoryProduct, CategoryProductDTO>(); 
            CreateMap<CategoryProductDTO, CategoryProduct>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

        }
    }
}
